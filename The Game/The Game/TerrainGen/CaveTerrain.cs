using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    internal class CaveTerrain
    {

        private static readonly Random Random = new Random();
        public static int MapAmount = 14;

        public  void Redirect(CustomMap map, int terrain)
        {
            TerrainGenerationModules.FillCollision();
            TerrainGraphics.Overlay(map, false);
        }

        private  void HLineCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void VLineCave()
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void TCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void InvertTCave()
        {
            TerrainGenerationModules.VCave(0, Console.WindowHeight/2, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void TLeftCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void TRightCave()
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void UpRightQuarterCave()
        {
            int y = TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void UpLeftQuarterCave()
        {
            int y = TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
            TerrainGenerationModules.VCave(0, y, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void DownRightQuarterCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));

            TerrainGenerationModules.HCave(Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void DownLeftQuarterCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
            TerrainGenerationModules.HCave(0, Console.WindowWidth*3/4 + Random.Next(-5, 5), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void DeadEndEastCave()
        {
            TerrainGenerationModules.HCave(0, Console.WindowWidth/2, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void DeadEndWestCave()
        {
            TerrainGenerationModules.HCave(Console.WindowWidth/2, Console.WindowWidth, Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(25, 35), Game.CurrentLoadedMap.Mapheight - 1 - Random.Next(5, 12));
        }

        private  void DeadEndNorthCave()
        {
            TerrainGenerationModules.VCave(0, Game.CurrentLoadedMap.Mapheight/2, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }

        private  void DeadEndSouthCave()
        {
            TerrainGenerationModules.VCave(Game.CurrentLoadedMap.Mapheight/2, Game.CurrentLoadedMap.Mapheight, Console.WindowWidth/4 + Random.Next(-5, 5), Console.WindowWidth*3/4 + Random.Next(-5, 5));
        }
    }
}