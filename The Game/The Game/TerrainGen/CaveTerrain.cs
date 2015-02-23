using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class CaveTerrain
    {
        private static readonly Random Random = new Random();
        public static int MapAmount = 14;

        public static void Redirect(CustomMap map, int terrain)
        {
            TerrainGenerationModules.FillCollision();
            switch (terrain)
            {
                case 0:
                    HLineCave();
                    break;
                case 1:
                    VLineCave();
                    break;
                case 2:
                    TCave();
                    break;
                case 3:
                    InvertTCave();
                    break;
                case 4:
                    TLeftCave();
                    break;
                case 5:
                    TRightCave();
                    break;
                case 6:
                    UpLeftQuarterCave();
                    break;
                case 7:
                    UpRightQuarterCave();
                    break;
                case 8:
                    DownLeftQuarterCave();
                    break;
                case 9:
                    DownRightQuarterCave();
                    break;
                case 10:
                    DeadEndEastCave();
                    break;
                case 11:
                    DeadEndNorthCave();
                    break;
                case 12:
                    DeadEndSouthCave();
                    break;
                case 13:
                    DeadEndWestCave();
                    break;
            }
            TerrainGraphics.Overlay(map, false);
        }

        private static void HLineCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void VLineCave()
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void TCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void InvertTCave()
        {
            TerrainGenerationModules.VCave(0, Console.WindowHeight/2, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void TLeftCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void TRightCave()
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void UpRightQuarterCave()
        {
            int y = TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void UpLeftQuarterCave()
        {
            int y = TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void DownRightQuarterCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));

            TerrainGenerationModules.HCave(Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void DownLeftQuarterCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth*3/4 + Random.Next(-5, 5), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void DeadEndEastCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void DeadEndWestCave()
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private static void DeadEndNorthCave()
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight/2, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private static void DeadEndSouthCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }
    }
}