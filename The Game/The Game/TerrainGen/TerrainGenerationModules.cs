using System;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class TerrainGenerationModules
    {
        private static readonly Random Random = new Random();
        private static int _up;
        private static int _vertiCounter;
        private static int _horiCounter;

        public static int ExtremeY(CustomMap map, int ywall, int x1, int x2, int direction, bool invert)
        {
            for (var xwall = x1; xwall < x2; xwall++)
            {
                if (ywall <= 10 && direction == -1 || ywall >= map.Mapheight - 10 && direction == 1)
                    _up = 1;
                else _up = Random.Next(18);
                if (xwall > 0 && map.Collision[ywall, xwall - 1])
                {
                    _vertiCounter = 0;
                    _horiCounter++;
                    if (_horiCounter >= 5)
                    {
                        _up = 3;
                        _horiCounter = 0;
                    }
                }
                else
                {
                    _horiCounter = 0;
                    _vertiCounter++;
                    if (_vertiCounter >= 3)
                    {
                        _up = 1;
                        _vertiCounter = 0;
                    }
                }
                //Safety
                if (ywall < 10 && direction == -1 || ywall > map.Mapheight - 8 && direction == 1)
                    ywall -= direction + Random.Next(2);


                else if ((_up == 3 || _up == 6 || _up == 12) && ywall < map.Mapheight - 1)
                {
                    ywall += direction;
                }
                else if ((_up == 4 || _up == 5) && ywall < map.Mapheight - 1)
                {
                    ywall += direction*2;
                }
                else if (_up == 9 && ywall < map.Mapheight - 1)
                {
                    ywall += direction*3;
                }
                if (invert)
                {
                    for (var y = ywall; y >= 0; y--)
                    {
                        Game.CurrentLoadedMap.Collision[y, xwall] = true;
                    }
                }
                else
                {
                    for (var y = ywall; y <= map.Mapheight - 1; y++)
                    {
                        map.Collision[y, xwall] = true;
                    }
                }
            }
            return ywall;
        }

        public static int SlowY(CustomMap map, int ywall, int x1, int x2, int direction, bool invert)
        {
            for (var xwall = x1; xwall < x2; xwall++)
            {
                _up = Random.Next(13);
                if (xwall > 0 && map.Collision[ywall, xwall - 1])
                {
                    _vertiCounter = 0;
                    _horiCounter++;
                    if (_horiCounter >= 9)
                    {
                        _up = 7;
                        _horiCounter = 0;
                    }
                }
                else
                {
                    _horiCounter = 0;
                    _vertiCounter++;
                    if (_vertiCounter >= 2)
                    {
                        _up = 1;
                        _vertiCounter -= 1;
                    }
                }

                if (ywall < 10 && direction == -1 || ywall > map.Mapheight - 8 && direction == 1)
                    ywall -= direction;
                else if (_up == 7)
                {
                    ywall += direction;
                }
                if (invert)
                {
                    for (var x = ywall; x >= 0; x--)
                    {
                        map.Collision[x, xwall] = true;
                    }
                }
                else
                {
                    for (var x = ywall; x <= map.Mapheight - 1; x++)
                    {
                        map.Collision[x, xwall] = true;
                    }
                }
            }
            return ywall;
        }

        public static int Cliff(CustomMap map, int ywall, int xwall, int x2, int direction, bool invert)
        {
            xwall -= 1;
            var xwallStart = xwall;
            for (var y = ywall; y < map.Mapheight; y++)
            {
                _up = Random.Next(5);
                if (map.Collision[y - 1, xwall])
                {
                    _vertiCounter = 0;
                    _horiCounter++;
                    if (_horiCounter >= 3)
                    {
                        _up = 4;
                        _horiCounter = 0;
                    }
                }
                else
                {
                    _horiCounter = 0;
                    _vertiCounter++;
                    if (_vertiCounter >= 3)
                    {
                        _up = 1;
                        _vertiCounter = 0;
                    }
                }
                if (_up == 4)
                {
                    xwall += direction;
                }


                if (direction == 1)
                    for (var x = xwallStart; x <= xwall; x++)
                        map.Collision[y, x] = true;
                else
                    for (var x = xwall + 1; x <= xwallStart; x++)
                        map.Collision[y, x] = false;
            }
            return ywall;
        }

        public static int Flat(CustomMap map, int ywall, int x1, int x2, bool invert)
        {
            for (var xwall = x1; xwall < x2; xwall++)
            {
                if (xwall < map.Mapwidth)
                {
                    _up = Random.Next(15);
                    if (xwall > 0 && map.Collision[ywall, xwall - 1])
                    {
                        _vertiCounter = 0;
                        _horiCounter++;
                        if (_horiCounter >= 9)
                        {
                            _up = Random.Next(7, 9);
                            _horiCounter = 0;
                        }
                    }
                    else
                    {
                        _horiCounter = 0;
                        _vertiCounter++;
                        if (_vertiCounter >= 3)
                        {
                            _up = 1;
                            _vertiCounter = 0;
                        }
                    }


                    if (_up == 7 && ywall > 0)
                    {
                        ywall--;
                    }
                    else if (_up == 8 && ywall < map.Mapheight - 1)
                    {
                        ywall++;
                    }
                    if (invert)
                    {
                        for (var y = ywall; y >= 0; y--)
                            map.Collision[y, xwall] = true;
                    }
                    else
                    {
                        for (var y = ywall; y < map.Collision.GetLength(0); y++)
                            map.Collision[y, xwall] = true;
                    }
                }
            }
            return ywall;
        }

        public static void Detach(int xBegin, int xend, int horizontalCutoff, int ytopBegin, int ytopEnd,
            int verticalCutoff)
        {
            double x1 = (xBegin);
            double x2 = (xend - horizontalCutoff - xBegin)/6 + xBegin;
            double y1 = ytopBegin;
            double y3 = verticalCutoff;
            var y2 = (y3 - y1)*2/3 + y1;
            var y4 = (y3 - ytopEnd)*2/3 + ytopEnd;
            var severeSlope = (y1 - y2)/(x1 - x2);
            var timidSlope = (y2 - y3)/(x1 - x2);
            var severeSlopeReturn = (y4 - ytopEnd)/(x1 - x2);

            for (var x = xBegin; x < xend; x++)
            {
                if (x < Game.CurrentLoadedMap.Mapwidth)
                {
                    int ypos;
                    if ((x - xBegin) < (xend - xBegin)/6)
                    {
                        ypos = Convert.ToInt32(severeSlope*(x - x1) + y1);
                    }
                    else if ((x - xBegin) < (xend - xBegin)/3)
                    {
                        var xtemp = x - (xend - xBegin)/6;
                        ypos = Convert.ToInt32(timidSlope*(xtemp - x1) + y2);
                    }
                    else if ((x - xBegin) < (xend - xBegin)*2/3)
                    {
                        ypos = Convert.ToInt32(y3);
                    }
                    else if ((x - xBegin) < (xend - xBegin)*5/6)
                    {
                        var xtemp = x - (xend - xBegin)*2/3;
                        ypos = Convert.ToInt32(-timidSlope*(xtemp - x1) + y3);
                    }
                    else
                    {
                        var xtemp = x - (xend - xBegin)*5/6;
                        ypos = Convert.ToInt32(severeSlopeReturn*(xtemp - x1) + y4);
                    }
                    for (var y = ypos; y < Game.CurrentLoadedMap.Mapheight; y++)
                    {
                        Game.CurrentLoadedMap.Collision[y, x] = false;
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[y, x] = null;
                    }
                }
            }
        }

        public static void MakeDestructable(int chance)
        {
            for (var i = 0; i < Game.CurrentLoadedMap.Mapheight; i++)
            {
                for (var j = 0; j < Game.CurrentLoadedMap.Mapwidth; j++)
                {
                    if (Game.CurrentLoadedMap.Collision[i, j] && Random.Next(chance) == 0)
                        Game.CurrentLoadedMap.Destructible[i, j] = true;
                }
            }
        }

        public static void FillCollision()
        {
            for (var a = 0; a < Game.CurrentLoadedMap.Mapheight; a++)
                for (var b = 0; b < Game.CurrentLoadedMap.Mapwidth; b++)
                {
                    Game.CurrentLoadedMap.Destructible[a, b] = true;
                    Game.CurrentLoadedMap.Collision[a, b] = true;
                }
        }

        public static int HCave(int x1, int x2, int ywall1, int ywall2, bool layer = false)
        {
            var collision = new bool[Game.CurrentLoadedMap.Mapheight, Game.CurrentLoadedMap.Mapwidth];
            var horiCounter = 0;
            var vertiCounter = 0;
            for (var a = 0; a < 2; a++)
            {
                for (var xwall = x1; xwall < x2; xwall++)
                {
                    collision[ywall1, xwall] = true;
                    var up = Random.Next(15);
                    if (xwall > 0 && Game.CurrentLoadedMap.Collision[ywall1, xwall - 1])
                    {
                        vertiCounter = 0;
                        horiCounter++;
                        if (horiCounter >= 9)
                        {
                            up = Random.Next(7, 9);
                            horiCounter = 0;
                        }
                    }
                    else
                    {
                        horiCounter = 0;
                        vertiCounter++;
                        if (vertiCounter >= 3)
                        {
                            up = 1;
                            vertiCounter = 0;
                        }
                    }
                    if (up == 7 && ywall1 > 0)
                    {
                        ywall1--;
                    }
                    else if (up == 9 && ywall1 < Game.CurrentLoadedMap.Mapheight - 1)
                    {
                        ywall1++;
                    }
                }
                ywall1 = ywall2;
            }
            Carve(collision);
            return ywall1;
        }

        public static void VCave(int y1, int y2, int xwall1, int xwall2, bool layer = false)
        {
            var collision = new bool[Game.CurrentLoadedMap.Mapheight, Game.CurrentLoadedMap.Mapwidth];
            var horiCounter = 0;
            var vertiCounter = 0;
            for (var a = 0; a < 2; a++)
            {
                for (var ywall = y1; ywall < y2; ywall++)
                {
                    collision[ywall, xwall1] = true;
                    var up = Random.Next(15);
                    if (ywall > 0 && Game.CurrentLoadedMap.Collision[ywall - 1, xwall1])
                    {
                        vertiCounter = 0;
                        horiCounter++;
                        if (horiCounter >= 9)
                        {
                            up = Random.Next(7, 9);
                            horiCounter = 0;
                        }
                    }
                    else
                    {
                        horiCounter = 0;
                        vertiCounter++;
                        if (vertiCounter >= 3)
                        {
                            up = 1;
                            vertiCounter = 0;
                        }
                    }
                    if (up == 7 && xwall1 > 0)
                    {
                        xwall1--;
                    }
                    else if (up == 9 && xwall1 < Console.WindowWidth)
                    {
                        xwall1++;
                    }
                }
                xwall1 = xwall2;
            }
            Carve(collision, true);
        }

        private static void Carve(bool[,] collision, bool vertical = false)
        {
            var cut = false;
            if (vertical)
            {
                for (var a = 0; a < Game.CurrentLoadedMap.Mapheight; a++)
                    for (var b = 0; b < Game.CurrentLoadedMap.Mapwidth; b++)

                    {
                        if (collision[a, b])

                            cut = !cut;

                        if (cut)
                            Game.CurrentLoadedMap.Collision[a, b] = false;
                    }
            }
            else
            {
                for (var b = 0; b < Game.CurrentLoadedMap.Mapwidth; b++)
                    for (var a = 0; a < Game.CurrentLoadedMap.Mapheight; a++)
                    {
                        if (collision[a, b])
                            cut = !cut;
                        if (cut)
                            Game.CurrentLoadedMap.Collision[a, b] = false;
                    }
            }
        }

        public static void RandomCollision()
        {
            for (var xwall = 0; xwall < Console.WindowWidth; xwall++)
            {
                for (var ywall = 0; ywall <= Game.CurrentLoadedMap.Mapheight - 1; ywall++)
                {
                    if (Random.Next(12) == 7)
                    {
                        Game.CurrentLoadedMap.Collision[ywall, xwall] = true;
                        Game.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[ywall, xwall] = ' ';
                    }
                }
            }
        }
    }
}