using System;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class LandTerrain
    {
        public static int MapAmount = 7;
        private static readonly Random Random = new Random();

        public static void Mountain(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight - 10;

            ywall = TerrainGenerationModules.SlowY(map, ywall, 0, Console.WindowWidth/4, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, -1,
                invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, 1,
                invert);
            TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, 1, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Valley(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight/4 + Random.Next(8);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, 0, Console.WindowWidth/4, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, -1,
                invert);
            TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, -1, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Forest(CustomMap map, bool invert)
        {
            var ywall = Game.CurrentLoadedMap.Mapheight -
                        Random.Next(Game.CurrentLoadedMap.Mapheight/3, Game.CurrentLoadedMap.Mapheight/2);
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
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

        public static void Flat(CustomMap map, bool invert)
        {
            var ywall = map.Mapheight - 8;
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.SlowY(map, ywall, 0, Console.WindowWidth, 0, invert);
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
    }
}