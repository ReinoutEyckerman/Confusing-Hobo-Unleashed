using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class SkyTerrain
    {
        public static int MapAmount = 4;
        private static readonly Random Random = new Random();

        public static void Redirect(CustomMap map, int selected, bool invert = false)
        {
            map.DayNightEnabled = true;
            map.CloudsEnabled = true;

            switch (selected)
            {
                case 0:
                    Island(map, invert);
                    break;
                case 1:
                    Islands(map, invert);
                    break;
                case 2:
                    RandomIslands(map, invert);
                    break;
                case 3:
                    Clouds(map, invert);
                    break;
            }
            TerrainGraphics.Overlay(map, invert, map.Mapheight);
        }

        private static void Island(CustomMap map, bool invert)
        {
            int ywall = 25;
            if (invert)
                ywall = map.Mapheight - ywall;
            int ywallEnd = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
            TerrainGenerationModules.Detach(0, Console.WindowWidth, 10, ywall, ywallEnd, ywall + 8);
        }

        private static void Islands(CustomMap map, bool invert)
        {
            int ywall = 8;
            if (invert)
                ywall = map.Mapheight - ywall;
            int ywallEnd = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            TerrainGenerationModules.Detach(0, Console.WindowWidth/4, 4, ywall, ywallEnd, 8);
            ywall += 4;
            ywallEnd = TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/5, Console.WindowWidth*4/5, invert);
            TerrainGenerationModules.Detach(Console.WindowWidth*3/5, Console.WindowWidth*4/5, 8, ywall, ywallEnd, ywall + 8);
            ywall = Console.WindowHeight*3/5;
            ywallEnd = TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*2/5, Console.WindowWidth*4/5, invert);
            TerrainGenerationModules.Detach(Console.WindowWidth*2/5, Console.WindowWidth*4/5, 4, ywall, ywallEnd, ywall + 8);
        }

        private static void RandomIslands(CustomMap map, bool invert)
        {
            int detach = 0;
            for (int y = 8; y < Game.CurrentLoadedMap.Mapheight; y++)
            {
                int xend = 0;
                if (y >= detach + 3)
                    for (int x = -10; x < Game.CurrentLoadedMap.Mapwidth; x += 3)
                    {
                        if (Random.Next(20) == 0 && x > xend + 5)
                        {
                            int d = y + Random.Next(6, Game.CurrentLoadedMap.Mapheight/5);
                            if (d > detach)
                                detach = d;
                            xend = x + Random.Next(Game.CurrentLoadedMap.Mapwidth/6, Game.CurrentLoadedMap.Mapwidth/3);
                            int horizontalCutoff = Random.Next(7);
                            if (x - ((xend - horizontalCutoff - x)/6 + x) == 0)
                                break;
                            int ywallEnd = TerrainGenerationModules.Flat(map, y, x, xend, invert);
                            TerrainGenerationModules.Detach(x, xend, horizontalCutoff, y, ywallEnd, d);
                        }
                    }
            }
        }

        private static void Clouds(CustomMap map, bool invert)
        {
            TerrainGraphics.Overlay(map, invert);
        }
    }
}