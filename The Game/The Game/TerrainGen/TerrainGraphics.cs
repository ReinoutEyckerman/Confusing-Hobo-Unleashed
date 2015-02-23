using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class TerrainGraphics
    {
        private static int _moonX;

        private static readonly int[,] JungleTree1 =
        {
            {0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0},
            {0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0},
            {0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
            {0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
            {0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 2, 2, 2, 2, 1, 1, 1, 0, 0, 0, 0, 0},
            {2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 1, 0, 1, 1, 1, 2, 2, 2, 2, 0},
            {0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2},
            {0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0},
            {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0},
            {0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0}
        };

        private static readonly int[,] JungleTree2 =
        {
            {0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0},
            {0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0},
            {0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
            {0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0},
            {0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 0, 0, 2, 2, 2, 2, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 0, 2, 2, 2, 2, 2, 2, 2},
            {0, 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 0, 2, 2, 2, 2, 2, 2, 2},
            {0, 0, 0, 2, 2, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
            {0, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
            {2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            {2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 2, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 2, 2, 2, 0, 0, 0, 0},
            {0, 2, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 0, 0},
            {0, 2, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 0, 0},
            {0, 2, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 2, 1, 1, 0, 0, 0, 0},
            {0, 2, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 1, 1, 0, 0, 0, 0},
            {0, 2, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 1, 0, 0, 0, 0, 0},
            {0, 2, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 2, 0, 0, 0, 0, 0, 0},
            {0, 2, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 2, 0, 0, 0, 0, 0, 0},
            {0, 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 2, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0}
        };

        private static readonly Random Random = new Random();
        private static bool _copter;
        private static int _xCopter;
        public static bool CopterAnimation;

        public static void Overlay(CustomMap map, bool invert, int cloudHeight = 0)
        {
            switch (VarDatabase.CurrentLayer)
            {
                case Layers.Cave:
                    CaveOverlay(map);
                    break;
                case Layers.Earth:
                    GenGravField(map, invert);
                    if (map.Sea)
                        GenSea(map, invert);

                    if (Random.Next(2) == 0)
                        VarDatabase.Day = true;
                    GenerateDay(map);
                    GenTime(map);
                    GenClouds(map, cloudHeight);
                    if (map.Sea)
                        GenSeaWeed(map, invert);
                    else
                    {
                        if (Random.Next(15) == 0)
                            GenJungle(map, invert);
                        GenForest(map, invert);
                    }
                    break;
                case Layers.Sky:
                    GenerateDay(map);
                    GenTime(map);
                    GenClouds(map, cloudHeight);
                    if (Random.Next(15) == 0)
                        GenJungle(map, invert);
                    GenForest(map, invert);
                    break;
                case Layers.Space:
                    break;
            }
        }

        public static void GenGravField(CustomMap map, bool Invert)
        {
            short invert = 1;
            if (Invert)
                invert = -1;
            for (int i = 0; i < map.Mapheight; i++)
            {
                for (int j = 0; j < map.Mapwidth; j++)
                {
                    map.Grav[i, j] = Convert.ToInt16((short) GravFields.Normal*invert);
                }
            }
        }

        private static void GenSea(CustomMap map, bool invert)
        {
            for (int i = 0; i < map.Mapwidth; i++)
            {
                if (invert)
                    for (int j = map.Mapheight - VarDatabase.SeaLevel; j >= 0; j--)
                        map.Grav[j, i] = Convert.ToInt16((short) GravFields.Sea*-1);
                else
                    for (int j = VarDatabase.SeaLevel; j < map.Mapheight; j++)
                        map.Grav[j, i] = (short) GravFields.Sea;
            }
        }

        private static void CaveOverlay(CustomMap map)
        {
            for (int a = 0; a < map.Mapheight; a++)
                for (int b = 0; b < map.Mapwidth; b++)
                {
                    map.Layers[0].Characters[a, b] = ' ';
                    map.Layers[0].Background[a, b] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Gray;
                }
            map.PushtoArray(map.Layers[0].Background, map.Layers[0].Foreground, map.Layers[0].Colors);
            for (int a = 0; a < map.Mapheight; a++)
                for (int b = 0; b < map.Mapwidth; b++)
                {
                    if (map.Collision[a, b])
                        map.Layers[Maplayers.Collision].Characters[a, b] = ' ';
                    map.Layers[Maplayers.Collision].Background[a, b] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGray;
                }
        }

        private static void GenerateDay(CustomMap map)
        {
            Console.BackgroundColor = VarDatabase.Day ? VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Cyan : VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkBlue;
            for (int xwall = 0; xwall < map.Mapwidth; xwall++)
            {
                for (int ywall = 0; ywall < map.Mapheight; ywall++)
                {
                    if (map.Grav[ywall, xwall] == (short) GravFields.Sea || map.Grav[ywall, xwall] == Convert.ToInt16((short) GravFields.Sea*-1))
                    {
                        map.Layers[0].Background[ywall, xwall] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Blue;
                        if (VarDatabase.Bw)
                            map.Layers[0].Characters[ywall, xwall] = '.';
                        else map.Layers[0].Characters[ywall, xwall] = ' ';
                    }
                    else
                    {
                        map.Layers[0].Background[ywall, xwall] = Console.BackgroundColor;
                        map.Layers[0].Characters[ywall, xwall] = ' ';
                    }
                }
            }

            map.PushtoArray(map.Layers[0].Background, map.Layers[0].Foreground, map.Layers[0].Colors);
        }

        private static void GenTime(CustomMap map)
        {
            for (int xwall = 0; xwall < Console.WindowWidth; xwall++)
            {
                for (int ywall = 0; ywall < map.Mapheight; ywall++)
                {
                    if (ywall - 1 >= 0 && ywall + 1 < map.Mapheight && map.Collision[ywall, xwall] && (!map.Collision[ywall - 1, xwall] && map.Grav[ywall - 1, xwall] > 0 && map.Grav[ywall - 1, xwall] != (short) GravFields.Sea && ((ywall + 1 < map.Mapheight && map.Collision[ywall + 1, xwall]) || ywall + 1 == map.Mapheight) || (!map.Collision[ywall + 1, xwall] && map.Grav[ywall + 1, xwall] < 0 && map.Grav[ywall + 1, xwall] != Convert.ToInt16((short) GravFields.Sea*-1) && ((ywall - 1 > 0 && map.Collision[ywall - 1, xwall]) || ywall - 1 == 0))))
                    {
                        map.Layers[Maplayers.Collision].Background[ywall, xwall] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen;
                        map.Layers[Maplayers.Collision].Foreground[ywall, xwall] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Green;
                        map.Layers[Maplayers.Collision].Characters[ywall, xwall] = '"';
                    }
                    else if (map.Collision[ywall, xwall])
                    {
                        map.Layers[Maplayers.Collision].Background[ywall, xwall] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
                        if (VarDatabase.Bw)
                            map.Layers[Maplayers.Collision].Characters[ywall, xwall] = '#';
                        else map.Layers[Maplayers.Collision].Characters[ywall, xwall] = ' ';
                    }
                }
            }
        }

        public static void GenCyclus(CustomMap map, bool increment = false)
        {
            if (increment)
                _moonX++;
            if (_moonX >= Console.WindowWidth)
            {
                _moonX = 0;
                VarDatabase.Day = !VarDatabase.Day;
                GenerateDay(map);
            }
            int[,] moon =
            {
                {0, 0, 0, 0, 0, 1, 2, 1, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 1, 2, 2, 1, 1, 1, 0, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0},
                {0, 0, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 0, 0},
                {0, 0, 1, 1, 2, 2, 2, 1, 2, 2, 2, 2, 0, 0},
                {0, 1, 1, 2, 2, 2, 1, 1, 1, 2, 1, 2, 1, 0},
                {0, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                {0, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0},
                {0, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0},
                {0, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 2, 1, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0},
                {0, 0, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0}
            };
            var mooncolor = new ConsoleColor[moon.GetLength(0), moon.GetLength(1)];
            var moonattribute = new short[Console.WindowWidth, Console.WindowHeight];
            int moonY = Convert.ToInt32((Math.Pow(_moonX - 93, 2)/190) + 2);

            ConsoleColor color1;
            ConsoleColor color2;
            if (VarDatabase.Day)
            {
                color1 = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Red;
                color2 = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkYellow;
            }
            else
            {
                color1 = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Gray;
                color2 = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGray;
            }
            for (int x = 0; x < moon.GetLength(0); x++)
                for (int y = 0; y < moon.GetLength(1); y++)
                {
                    if (x + _moonX < map.Mapwidth && x + _moonX > 0 && y + moonY < map.Mapheight && moonY + y > 0)
                    {
                        if (moon[x, y] == 1)
                            mooncolor[x, y] = color1;
                        else if (moon[x, y] == 2)
                            mooncolor[x, y] = color2;
                    }
                }

            for (int i = 0; i < moon.GetLength(0); i++)
                for (int j = 0; j < moon.GetLength(1); j++)
                    if (i + _moonX < map.Mapwidth && i + _moonX > 0 && j + moonY < map.Mapheight && moonY + j > 0 && map.Layers[Maplayers.Air].Background[moonY + j, _moonX + i] != VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Blue)
                    {
                        moonattribute[i + _moonX, j + moonY] = Color.ColorsToAttribute(mooncolor[i, j], mooncolor[i, j]);
                        string charToString = Convert.ToString(' ');
                        Game.GameBuffer.Draw(charToString, i + _moonX, j + moonY, moonattribute[i + _moonX, j + moonY]);
                    }
        }

        private static void GenForest(CustomMap map, bool invert)
        {
            for (int xwall = 8; xwall < Console.WindowWidth - 2; xwall += Random.Next(3, 18))
                for (int ywal = 1; ywal < map.Mapheight; ywal++)
                    if (map.Collision[ywal, xwall] && ywal - 6 >= 0 && !invert || ywal - 1 >= 0 && ywal + 6 <= map.Mapheight && !map.Collision[ywal + 1, xwall] && invert)
                    {
                        DrawTree(map, xwall, ywal, invert);
                        break;
                    }
        }

        private static void DrawJungleTree(CustomMap map, int xpos, int ypos, bool Invert)
        {
            int invert = 1;
            if (Invert)
                invert = -1;

            int[,] array = Random.Next(2) == 0 ? JungleTree1 : JungleTree2;
            for (int x = 0; x < array.GetLength(1); x++)
                for (int y = 0; y < array.GetLength(0); y++)
                    if (((ypos + (-array.GetLength(0) + 8 + y))*invert >= 0 && ypos + (-array.GetLength(0) + 8 + y)*invert < map.Mapheight && xpos + x >= 0 && xpos + x < Console.WindowWidth))
                    {
                        if (array[y, x] == 1)
                        {
                            if (VarDatabase.Bw)
                                map.Layers[Maplayers.Destructible].Characters[ypos + (- array.GetLength(0) + 8 + y)*invert, xpos + x] = 'I';
                            else map.Layers[Maplayers.Destructible].Characters[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = ' ';
                            map.Destructible[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = true;
                            map.Layers[Maplayers.Destructible].Background[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
                        }
                        else if (array[y, x] == 2)
                        {
                            if (VarDatabase.Bw)
                                map.Layers[Maplayers.Destructible].Characters[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = '*';
                            else map.Layers[Maplayers.Destructible].Characters[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = ' ';
                            map.Layers[Maplayers.Destructible].Background[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen;
                            map.Destructible[ypos + (-array.GetLength(0) + 8 + y)*invert, xpos + x] = true;
                        }
                    }
        }

        private static void GenJungle(CustomMap map, bool invert)
        {
            for (int xwall = Random.Next(3, 18); xwall < Console.WindowWidth - 2; xwall += Random.Next(8, 24))
                for (int ywal = 0; ywal < map.Mapheight; ywal++)

                    if (map.Collision[ywal, xwall] && !invert || ywal + 1 < map.Mapheight && !map.Collision[ywal + 1, xwall] && invert)
                    {
                        DrawJungleTree(map, xwall, ywal, invert);
                        break;
                    }
        }

        private static void DrawTree(CustomMap map, int xpos, int ypos, bool invert)
        {
            int reverse = 1;
            if (invert)
                reverse = -1;
            for (int x = -1; x <= 1; x++)
            {
                map.Destructible[ypos - 5*reverse, xpos + x] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - 5*reverse, xpos + x] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen;
                if (VarDatabase.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - 5*reverse, xpos + x] = '*';
                else map.Layers[Maplayers.Destructible].Characters[ypos - 5*reverse, xpos + x] = ' ';
            }

            for (int x = -2; x <= 2; x++)
            {
                map.Destructible[ypos - 4*reverse, xpos + x] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - 4*reverse, xpos + x] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen;
                if (VarDatabase.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - 4*reverse, xpos + x] = '*';
                else map.Layers[Maplayers.Destructible].Characters[ypos - 4*reverse, xpos + x] = ' ';
            }

            for (int y = 1; y < 4; y++)
            {
                map.Destructible[ypos - y*reverse, xpos] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - y*reverse, xpos] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
                if (VarDatabase.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - y*reverse, xpos] = 'I';
                else map.Layers[Maplayers.Destructible].Characters[ypos - y*reverse, xpos] = ' ';
            }
        }

        private static void GenSeaWeed(CustomMap map, bool invert)
        {
            for (int xwall = 8; xwall < Console.WindowWidth - 2; xwall += Random.Next(3, 18))
                for (int ywal = 1; ywal < map.Mapheight; ywal++)
                    if ((ywal - 6 >= 0 && map.Grav[ywal - 6, xwall] == (short) GravFields.Sea && map.Collision[ywal, xwall] && !invert) || (ywal + 6 < map.Mapheight && map.Grav[ywal + 6, xwall] == (short) GravFields.Sea*-1 && map.Collision[ywal, xwall] && invert))
                    {
                        DrawWeed(map, xwall, ywal, invert);
                        break;
                    }
        }

        private static void DrawWeed(CustomMap map, int xpos, int ypos, bool Invert)
        {
            int invert = 1;
            if (Invert)
                invert = -1;

            bool[,] weed =
            {
                {false, true, true, true, true},
                {true, true, false, false, false},
                {false, true, true, false, false}
            };
            int negater = Random.Next(2);
            for (int x = 0; x <= 2; x++)
                for (int y = 4; y >= 0; y--)
                    if (weed[x, y])
                    {
                        int negX;
                        if (negater == 0)
                        {
                            negX = x*-1;
                        }
                        else negX = x;
                        if (!map.Collision[ypos - (y)*invert, xpos + negX])
                        {
                            map.Destructible[ypos - (y)*invert, xpos + negX] = true;
                            map.Layers[Maplayers.Destructible].Background[ypos - (y)*invert, xpos + negX] = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Green;
                            if (VarDatabase.Bw)
                                map.Layers[Maplayers.Destructible].Characters[ypos - (y)*invert, xpos + negX] = 'L';
                            else map.Layers[Maplayers.Destructible].Characters[ypos - (y)*invert, xpos + negX] = ' ';
                        }
                    }
        }

        private static void DrawCloud(CustomMap map, int xpos, int ypos, bool thunder)
        {
            bool[,] cloud1 =
            {
                {false, false, true, false, false, false, false, false, false, false, false},
                {false, true, true, true, true, true, true, true, true, false, false},
                {true, true, true, true, true, true, true, true, true, true, true},
                {true, true, true, true, true, true, false, false, false, false, false}
            };
            bool[,] cloud2 =
            {
                {false, false, false, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false},
                {false, false, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false},
                {true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true},
                {true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true},
                {false, false, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false}
            };

            bool[,] cloudarray;
            ConsoleColor cloudcolor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].White;
            if (thunder)
                cloudcolor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGray;

            if (Random.Next(2) == 1)
            {
                cloudarray = new bool[cloud1.GetLength(0), cloud1.GetLength(1)];
                Array.Copy(cloud1, cloudarray, cloud1.GetLength(0)*cloud1.GetLength(1));
            }
            else
            {
                cloudarray = new bool[cloud2.GetLength(0), cloud2.GetLength(1)];
                Array.Copy(cloud2, cloudarray, cloud2.GetLength(0)*cloud2.GetLength(1));
            }
            int negater = Random.Next(2);
            for (int x = 0; x < cloudarray.GetLength(1); x++)
            {
                for (int y = 0; y < cloudarray.GetLength(0); y++)
                {
                    if (cloudarray[y, x])
                    {
                        int negX;
                        if (negater == 0 && x - cloudarray.GetLength(1) > 0)
                        {
                            negX = x*-1;
                        }
                        else negX = x;
                        if (ypos + y < map.Mapheight && xpos + negX < map.Mapwidth && xpos + negX > 0)
                        {
                            map.Layers[Maplayers.Clouds].Background[ypos + y, xpos + negX] = cloudcolor;
                            if (VarDatabase.Bw)
                                map.Layers[Maplayers.Clouds].Characters[ypos + y, xpos + negX] = 'L';
                            else map.Layers[Maplayers.Clouds].Characters[ypos + y, xpos + negX] = ' ';
                        }
                    }
                }
            }
        }

        private static void GenClouds(CustomMap map, int maxHeight = 0, int randomizer = 12)
        {
            bool thunder = Random.Next(50) == 0;
            if (maxHeight == 0)
                maxHeight = Console.WindowHeight/3 - 4;

            for (int xwall = 0; xwall < Console.WindowWidth; xwall ++)
                if (Random.Next(randomizer) == 0)
                {
                    int ypos = Random.Next(5, maxHeight);
                    DrawCloud(map, xwall, ypos, thunder);
                }
        }

        public static void Copter(CustomMap map)
        {
            _xCopter++;
            if (_xCopter > map.Mapwidth)
            {
                _xCopter = 0;
                CopterAnimation = false;
                return;
            }
            char[,] copter1 =
            {
                {'R', 'O', 'F', 'L', ':', 'R', 'O', 'F', 'L', ':', 'L', 'O', 'L', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '^', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', '/', '-', '-', '-', '-', '-', '-', '-', ' ', ' '},
                {' ', 'L', 'O', 'L', '=', '=', '=', ' ', ' ', ' ', ' ', ' ', '[', ']', '\\', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\', '_', '_', '_', '_', '_', '_', '_', ']'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'I', ' ', ' ', ' ', ' ', 'I', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '/'}
            };
            char[,] copter2 =
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'L', 'O', 'L', 'R', 'O', 'F', 'L', ':', 'R', 'O', 'F', 'L'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '^', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', 'L', ' ', ' ', ' ', '/', '-', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', 'O', ' ', '=', '=', '=', ' ', ' ', ' ', ' ', ' ', '[', ']', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', 'L', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\', '_', '_', '_', '_', '_', '_', '_', ']', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'I', ' ', ' ', ' ', ' ', 'I', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '/', ' ', ' ', ' ', ' ', ' ', ' '}
            };
            char[,] copterArray;
            copterArray = !_copter ? copter1 : copter2;
            _copter = !_copter;
            for (int i = 0; i < copterArray.GetLength(1); i++)
                for (int j = 0; j < copterArray.GetLength(0); j++)
                    if (copterArray[j, i] != ' ')
                        if (_xCopter + i < map.Mapwidth && _xCopter + i >= 0)
                            Game.GameBuffer.Draw(Convert.ToString(copterArray[j, i]), _xCopter + i, 5 + j, 0);
        }
    }
}