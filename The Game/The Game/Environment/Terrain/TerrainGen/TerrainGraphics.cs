using System;
using Confusing_Hobo_Unleashed.Colors;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class TerrainGraphics
    {
        private static int _moonX;
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
            for (var i = 0; i < map.Mapheight; i++)
            {
                for (var j = 0; j < map.Mapwidth; j++)
                {
                    map.Grav[i, j] = Convert.ToInt16((short) GravFields.Normal * invert);
                }
            }
        }

        private static void GenSea(CustomMap map, bool invert)
        {
            for (var i = 0; i < map.Mapwidth; i++)
            {
                if (invert)
                    for (var j = map.Mapheight - VarDatabase.SeaLevel; j >= 0; j--)
                        map.Grav[j, i] = Convert.ToInt16((short) GravFields.Sea * -1);
                else
                    for (var j = VarDatabase.SeaLevel; j < map.Mapheight; j++)
                        map.Grav[j, i] = (short) GravFields.Sea;
            }
        }


        private static void GenerateDay(CustomMap map)
        {
            Console.BackgroundColor = VarDatabase.Day
                ? Painter.Instance.Paint(ConsoleColor.Cyan)
                : Painter.Instance.Paint(ConsoleColor.DarkBlue);
            for (var xwall = 0; xwall < map.Mapwidth; xwall++)
            {
                for (var ywall = 0; ywall < map.Mapheight; ywall++)
                {
                    if (map.Grav[ywall, xwall] == (short) GravFields.Sea ||
                        map.Grav[ywall, xwall] == Convert.ToInt16((short) GravFields.Sea * -1))
                    {
                        map.Layers[0].Background[ywall, xwall] = Painter.Instance.Paint(ConsoleColor.Blue);
                        if (Painter.Instance.Bw)
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

        private static void GenForest(CustomMap map, bool invert)
        {
            for (var xwall = 8; xwall < Console.WindowWidth - 2; xwall += Random.Next(3, 18))
            for (var ywal = 1; ywal < map.Mapheight; ywal++)
                if (map.Collision[ywal, xwall] && ywal - 6 >= 0 && !invert || ywal - 1 >= 0 &&
                    ywal + 6 <= map.Mapheight && !map.Collision[ywal + 1, xwall] && invert)
                {
                    DrawTree(map, xwall, ywal, invert);
                    break;
                }
        }


        private static void DrawTree(CustomMap map, int xpos, int ypos, bool invert)
        {
            var reverse = 1;
            if (invert)
                reverse = -1;
            for (var x = -1; x <= 1; x++)
            {
                map.Destructible[ypos - 5 * reverse, xpos + x] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - 5 * reverse, xpos + x] =
                    Painter.Instance.Paint(ConsoleColor.DarkGreen);
                if (Painter.Instance.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - 5 * reverse, xpos + x] = '*';
                else map.Layers[Maplayers.Destructible].Characters[ypos - 5 * reverse, xpos + x] = ' ';
            }

            for (var x = -2; x <= 2; x++)
            {
                map.Destructible[ypos - 4 * reverse, xpos + x] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - 4 * reverse, xpos + x] =
                    Painter.Instance.Paint(ConsoleColor.DarkGreen);
                if (Painter.Instance.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - 4 * reverse, xpos + x] = '*';
                else map.Layers[Maplayers.Destructible].Characters[ypos - 4 * reverse, xpos + x] = ' ';
            }

            for (var y = 1; y < 4; y++)
            {
                map.Destructible[ypos - y * reverse, xpos] = true;
                map.Layers[Maplayers.Destructible].Background[ypos - y * reverse, xpos] =
                    Painter.Instance.Paint(ConsoleColor.DarkRed);
                if (Painter.Instance.Bw)
                    map.Layers[Maplayers.Destructible].Characters[ypos - y * reverse, xpos] = 'I';
                else map.Layers[Maplayers.Destructible].Characters[ypos - y * reverse, xpos] = ' ';
            }
        }

        private static void GenSeaWeed(CustomMap map, bool invert)
        {
            for (var xwall = 8; xwall < Console.WindowWidth - 2; xwall += Random.Next(3, 18))
            for (var ywal = 1; ywal < map.Mapheight; ywal++)
                if ((ywal - 6 >= 0 && map.Grav[ywal - 6, xwall] == (short) GravFields.Sea &&
                     map.Collision[ywal, xwall] && !invert) ||
                    (ywal + 6 < map.Mapheight && map.Grav[ywal + 6, xwall] == (short) GravFields.Sea * -1 &&
                     map.Collision[ywal, xwall] && invert))
                {
                    DrawWeed(map, xwall, ywal, invert);
                    break;
                }
        }
    }
}