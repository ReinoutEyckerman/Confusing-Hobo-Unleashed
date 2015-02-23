using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class LandTerrain
    {
        public static int MapAmount = 7;

        private static readonly Random Random = new Random();

        public static void Redirect(CustomMap map, int selected, bool invert = false)
        {
            if (map.Invertrate == 1)
                invert = true;
            map.DayNightEnabled = true;
            map.CloudsEnabled = true;
            switch (selected)
            {
                case 0:
                    Mountain(map, invert);
                    break;
                case 1:
                    Valley(map, invert);
                    break;
                case 2:
                    Forest(map, invert);
                    break;
                case 3:
                    Cliff(map, invert);
                    break;
                case 4:
                    Flat(map, invert);
                    break;
                case 5:
                    HillSide(map, invert);
                    break;
                case 6:
                    HillSideInverted(map, invert);
                    break;
            }
            TerrainGraphics.Overlay(map, invert);
            if (map.Invertrate == 2 && !invert)
                Redirect(map, selected, true);
        }

        private static void Mountain(CustomMap map, bool invert)
        {
            int ywall = Game.CurrentLoadedMap.Mapheight - 10;

            ywall = TerrainGenerationModules.SlowY(map, ywall, 0, Console.WindowWidth/4, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, 1, invert);
            TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, 1, invert);
        }

        private static void Valley(CustomMap map, bool invert)
        {
            int ywall = Game.CurrentLoadedMap.Mapheight/4 + Random.Next(8);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, 0, Console.WindowWidth/4, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, -1, invert);
            TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, -1, invert);
        }

        private static void Forest(CustomMap map, bool invert)
        {
            int ywall = Game.CurrentLoadedMap.Mapheight - Random.Next(Game.CurrentLoadedMap.Mapheight/3, Game.CurrentLoadedMap.Mapheight/2);
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
        }

        private static void Cliff(CustomMap map, bool invert)
        {
            int ywall = Console.WindowHeight/2;
            if (invert)
                ywall = map.Mapheight - ywall;
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth*3/4, invert);
            TerrainGenerationModules.Cliff(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, -1, invert);
        }

        private static void Flat(CustomMap map, bool invert)
        {
            int ywall = map.Mapheight - 8;
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.SlowY(map, ywall, 0, Console.WindowWidth, 0, invert);
        }

        private static void HillSide(CustomMap map, bool invert)
        {
            int ywall = Game.CurrentLoadedMap.Mapheight*3/4 + Random.Next(-4, 4);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, -1, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, -1, invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
        }

        private static void HillSideInverted(CustomMap map, bool invert)
        {
            int ywall = Game.CurrentLoadedMap.Mapheight/4 + Random.Next(8);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth/4, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth/4, Console.WindowWidth/2, 1, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth/2, Console.WindowWidth*3/4, 1, invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth*3/4, Console.WindowWidth, invert);
        }
    }
}