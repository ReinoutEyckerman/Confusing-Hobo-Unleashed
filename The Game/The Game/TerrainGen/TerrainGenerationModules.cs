using System;
using Confusing_Hobo_Unleashed.Geometry;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class TerrainGenerationModules //TODO: Wiskundige formules, implementeer naar < /\ > \/
    {
        private static readonly Random Random = new Random();
        private static int _up;
        private static int _vertiCounter;
        private static int _horiCounter;

        public static bool[,] straight(bool[,] terrain, int startY, int endY, bool topDown)
        {
            int width = terrain.GetLength(0);
            int height = terrain.GetLength(1);

            double differential = (endY - startY) / (double) width;

            for (int borderX = 0; borderX < width; borderX++)
            {
                int borderY = (int) Math.Floor(borderX * differential);

                if (topDown)
                {
                    for (int y = borderY; y >= 0; y--)
                    {
                        terrain[borderX, borderY] = true;
                    }
                }
                else
                {
                    for (int y = borderY; y <= height - 1; y++)
                    {
                        terrain[borderX, borderY] = true;
                    }
                }
            }
        }

        public static bool[,] convexEllipsOutside(bool[,] terrain, int centerY, bool topDown)
        {
            int width = terrain.GetLength(0);
            int height = terrain.GetLength(1) - centerY;

            int xradius = Ellips.radiusFromDimensionSize(width);
            int yradius = Ellips.radiusFromDimensionSize(height);


            for (int borderX = 0; borderX < width; borderX++)
            {
                for (int borderY = 0; borderY < height; borderY++) //TODO Coordinatenstelsels nakijken
                {
                    if (!Ellips.isPointInEllips(borderX, borderY, xradius, yradius)) ;
                    {
                        if (topDown && Ellips.isPointInEllips(borderX, borderY + 1, xradius, yradius))
                        {
                            for (int y = borderY; y >= 0; y--)
                            {
                                terrain[borderX, borderY] = true;
                            }

                            break;
                        }
                        else if (!topDown && Ellips.isPointInEllips(borderX, borderY - 1, xradius, yradius))
                        {
                            for (int y = borderY; y <= height - 1; y++)
                            {
                                terrain[borderX, borderY] = true;
                            }

                            break;
                        }
                    }
                }
            }
        }

        public static bool[,] convexEllipsInside(bool[,] terrain, int centerY)
        {
            int width = terrain.GetLength(0);
            int height = terrain.GetLength(1) - centerY;

            int xradius = Ellips.radiusFromDimensionSize(width);
            int yradius = Ellips.radiusFromDimensionSize(height);


            for (int borderX = 0; borderX < width; borderX++)
            {
                for (int borderY = 0; borderY < height; borderY++) //TODO Coordinatenstelsels nakijken
                {
                    if (Ellips.isPointInEllips(borderX, borderY, xradius, yradius)) ;
                    {
                        terrain[borderX, borderY] = true;
                    }
                }
            }
        }

        public static void Detach(int xBegin, int xend, int horizontalCutoff, int ytopBegin, int ytopEnd, int verticalCutoff)
        {
            double x1 = (xBegin);
            double x2 = (xend - horizontalCutoff - xBegin) / 6 + xBegin;
            double y1 = ytopBegin;
            double y3 = verticalCutoff;
            var y2 = (y3 - y1) * 2 / 3 + y1;
            var y4 = (y3 - ytopEnd) * 2 / 3 + ytopEnd;
            var severeSlope = (y1 - y2) / (x1 - x2);
            var timidSlope = (y2 - y3) / (x1 - x2);
            var severeSlopeReturn = (y4 - ytopEnd) / (x1 - x2);

            for (var x = xBegin; x < xend; x++)
            {
                if (x < MainGame.CurrentLoadedMap.Mapwidth)
                {
                    int ypos;
                    if ((x - xBegin) < (xend - xBegin) / 6)
                    {
                        ypos = Convert.ToInt32(severeSlope * (x - x1) + y1);
                    }
                    else if ((x - xBegin) < (xend - xBegin) / 3)
                    {
                        var xtemp = x - (xend - xBegin) / 6;
                        ypos = Convert.ToInt32(timidSlope * (xtemp - x1) + y2);
                    }
                    else if ((x - xBegin) < (xend - xBegin) * 2 / 3)
                    {
                        ypos = Convert.ToInt32(y3);
                    }
                    else if ((x - xBegin) < (xend - xBegin) * 5 / 6)
                    {
                        var xtemp = x - (xend - xBegin) * 2 / 3;
                        ypos = Convert.ToInt32(-timidSlope * (xtemp - x1) + y3);
                    }
                    else
                    {
                        var xtemp = x - (xend - xBegin) * 5 / 6;
                        ypos = Convert.ToInt32(severeSlopeReturn * (xtemp - x1) + y4);
                    }

                    for (var y = ypos; y < MainGame.CurrentLoadedMap.Mapheight; y++)
                    {
                        MainGame.CurrentLoadedMap.Collision[y, x] = false;
                        MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Characters[y, x] = null;
                    }
                }
            }
        }

        public static void MakeDestructable(bool[,] map, int chance)
        {
            for (int x = 0; x < MainGame.CurrentLoadedMap.Mapheight; i++)
            {
                for (int j = 0; j < MainGame.CurrentLoadedMap.Mapwidth; j++)
                {
                    if (MainGame.CurrentLoadedMap.Collision[i, j] && Random.Next(chance) == 0)
                        MainGame.CurrentLoadedMap.Destructible[i, j] = true;
                }
            }
        }

        public static void FillCollision()
        {
            for (var a = 0; a < MainGame.CurrentLoadedMap.Mapheight; a++)
            for (var b = 0; b < MainGame.CurrentLoadedMap.Mapwidth; b++)
            {
                MainGame.CurrentLoadedMap.Destructible[a, b] = true;
                MainGame.CurrentLoadedMap.Collision[a, b] = true;
            }
        }

        public static int HCave(int x1, int x2, int ywall1, int ywall2, bool layer = false)
        {
            var collision = new bool[MainGame.CurrentLoadedMap.Mapheight, MainGame.CurrentLoadedMap.Mapwidth];
            var horiCounter = 0;
            var vertiCounter = 0;
            for (var a = 0; a < 2; a++)
            {
                for (var xwall = x1; xwall < x2; xwall++)
                {
                    collision[ywall1, xwall] = true;
                    var up = Random.Next(15);
                    if (xwall > 0 && MainGame.CurrentLoadedMap.Collision[ywall1, xwall - 1])
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

                        Carve(collision, true);
                    }

                    private static void Carve(bool[,] collision, bool vertical = false)
                    {
                        var cut = false;
                        if (vertical)
                        {
                            for (var a = 0; a < MainGame.CurrentLoadedMap.Mapheight; a++)
                            for (var b = 0; b < MainGame.CurrentLoadedMap.Mapwidth; b++)

                            {
                                if (collision[a, b])

                                    cut = !cut;

                                if (cut)
                                    MainGame.CurrentLoadedMap.Collision[a, b] = false;
                            }
                        }
                        else
                        {
                            for (var b = 0; b < MainGame.CurrentLoadedMap.Mapwidth; b++)
                            for (var a = 0; a < MainGame.CurrentLoadedMap.Mapheight; a++)
                            {
                                if (collision[a, b])
                                    cut = !cut;
                                if (cut)
                                    MainGame.CurrentLoadedMap.Collision[a, b] = false;
                            }
                        }
                    }
                }
            }
        }
    }
}