using System;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class SeaTerrain
    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 8;
        public static void Sea(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight - Random.Next(5, 15);
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Lake(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight/4 + Random.Next(8);
            if (invert)
                ywall = map.Mapheight - ywall;
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, 0, Console.WindowWidth/4, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, -1,
                invert);
            TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, -1, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Island(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight - 2;
            if (invert)
                ywall = map.Mapheight - ywall;
            ywall = TerrainGenerationModules.SlowY(map, ywall, 0, Console.WindowWidth/4, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, -1,
                invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, 1,
                invert);
            TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, 1, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Cliff(CustomMap map, bool invert)
        {
            var ywall = Console.WindowHeight/2;
            if (invert)
                ywall = map.Mapheight - ywall;
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth*3/4, invert);
            TerrainGenerationModules.Cliff(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, -1, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void HillSide(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight*3/4 + Random.Next(-4, 4);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, -1,
                invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void HillSideInverted(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight/4 + Random.Next(8);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, 1,
                invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, 1, invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Beach(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight*2/4 + Random.Next(-4, 4);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth*3/4, -1,
                invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void BeachInverted(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight*2/4 + Random.Next(8);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth*3/4, 1, invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }
    }
}