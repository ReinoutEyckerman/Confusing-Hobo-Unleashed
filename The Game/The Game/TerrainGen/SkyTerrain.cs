using System;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class SkyTerrain
    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 4;
        public static void Island(CustomMap map, bool invert)
        {
            var ywall = 25;
            if (invert)
                ywall = map.Mapheight - ywall;
            var ywallEnd = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
            TerrainGenerationModules.Detach(0, Console.WindowWidth, 10, ywall, ywallEnd, ywall + 8);
            TerrainGraphics.Overlay(map, invert, map.Mapheight);
        }

        public static void Islands(CustomMap map, bool invert)
        {
            var ywall = 8;
            if (invert)
                ywall = map.Mapheight - ywall;
            var ywallEnd = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            TerrainGenerationModules.Detach(0, Console.WindowWidth/4, 4, ywall, ywallEnd, 8);
            ywall += 4;
            ywallEnd = TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/5, Console.WindowWidth*4/5,
                invert);
            TerrainGenerationModules.Detach(Console.WindowWidth*3/5, Console.WindowWidth*4/5, 8, ywall, ywallEnd,
                ywall + 8);
            ywall = Console.WindowHeight*3/5;
            ywallEnd = TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*2/5, Console.WindowWidth*4/5,
                invert);
            TerrainGenerationModules.Detach(Console.WindowWidth*2/5, Console.WindowWidth*4/5, 4, ywall, ywallEnd,
                ywall + 8);
            TerrainGraphics.Overlay(map, invert, map.Mapheight);
        }

        public static void RandomIslands(CustomMap map, bool invert)
        {
            var detach = 0;
            for (var y = 8; y < Game.CurrentLoadedMap.Mapheight; y++)
            {
                var xend = 0;
                if (y >= detach + 3)
                    for (var x = -10; x < Game.CurrentLoadedMap.Mapwidth; x += 3)
                    {
                        if (Random.Next(20) == 0 && x > xend + 5)
                        {
                            var d = y + Random.Next(6, Game.CurrentLoadedMap.Mapheight/5);
                            if (d > detach)
                                detach = d;
                            xend = x + Random.Next(Game.CurrentLoadedMap.Mapwidth/6, Game.CurrentLoadedMap.Mapwidth/3);
                            var horizontalCutoff = Random.Next(7);
                            if (x - ((xend - horizontalCutoff - x)/6 + x) == 0)
                                break;
                            var ywallEnd = TerrainGenerationModules.Flat(map, y, x, xend, invert);
                            TerrainGenerationModules.Detach(x, xend, horizontalCutoff, y, ywallEnd, d);
                        }
                    }
            }
            TerrainGraphics.Overlay(map, invert, map.Mapheight);
        }

        public static void Clouds(CustomMap map, bool invert)
        {
            TerrainGraphics.Overlay(map, invert);
        }
    }
}