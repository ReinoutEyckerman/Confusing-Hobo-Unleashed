using System;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class CaveTerrain
    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 14;

        public static void HLineCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void VLineCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void TCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void InvertTCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(0, Console.WindowHeight/2, Console.WindowWidth/4 + Random.Next(-5, 5),
                Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void TLeftCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void TRightCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void UpRightQuarterCave(CustomMap map, bool invert)
        {
            var y = TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5),
                Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void UpLeftQuarterCave(CustomMap map, bool invert)
        {
            var y = TerrainGenerationModules.HCave(0, Console.WindowWidth/2,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5),
                Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DownRightQuarterCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));

            TerrainGenerationModules.HCave(Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DownLeftQuarterCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth*3/4 + Random.Next(-5, 5),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DeadEndEastCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DeadEndWestCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth,
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35),
                Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DeadEndNorthCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight/2,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }

        public static void DeadEndSouthCave(CustomMap map, bool invert)
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight,
                Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGraphics.Overlay(map, false);
        }
    }
}