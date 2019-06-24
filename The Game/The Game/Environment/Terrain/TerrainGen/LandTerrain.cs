using System;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.TerrainGen.Fillers;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class LandTerrain
    {
        public static int MapAmount = 7;
        private static readonly Random Random = new Random();

        public Entity[,] Mountain(Orientation orientation, int width, int height, int startY, int endY)
        {
            int length = width / 4;
            int slowVar = height / 6;
            int fastVar = height / 3;
            Entity[,] g1 = Line.fillLine(orientation, null, length, height, startY, startY - slowVar);
            Entity[,] g2 = Line.fillLine(orientation, null, length, height, startY - slowVar,
                startY - slowVar - fastVar);
            Entity[,] g3 = Line.fillLine(orientation, null, length, height, startY - slowVar - fastVar,
                startY - slowVar);
            Entity[,] g4 = Line.fillLine(orientation, null, length, height, startY - slowVar, startY);
            Entity[,] gl1 = Glue.glue(g2, g1, orientation, length);
            Entity[,] gl2 = Glue.glue(g3, gl1, orientation, length*2);
            return Glue.glue(g4, gl2, orientation, length*3);
        }
        public Entity[,] Valley(Orientation orientation, int width, int height, int startY, int endY)
        {
            int length = width / 4;
            int slowVar = height / 6;
            int fastVar = height / 3;
            Entity[,] g1 = Line.fillLine(orientation, null, length, height, startY, startY + fastVar);
            Entity[,] g2 = Line.fillLine(orientation, null, length, height, startY + fastVar,
                startY + slowVar + fastVar);
            Entity[,] g3 = Line.fillLine(orientation, null, length, height, startY + slowVar + fastVar,
                startY + fastVar);
            Entity[,] g4 = Line.fillLine(orientation, null, length, height, startY + fastVar, startY);
            Entity[,] gl1 = Glue.glue(g2, g1, orientation, length);
            Entity[,] gl2 = Glue.glue(g3, gl1, orientation, length*2);
            return Glue.glue(g4, gl2, orientation, length*3);
        }

        public static void Forest(CustomMap map, bool invert)
        {
            var ywall = MainGame.CurrentLoadedMap.Mapheight - Random.Next(MainGame.CurrentLoadedMap.Mapheight / 3,
                            MainGame.CurrentLoadedMap.Mapheight / 2);
            if (invert)
                ywall = map.Mapheight - ywall;
            TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void Cliff(CustomMap map, bool invert)
        {
            var ywall = Console.WindowHeight / 2;
            if (invert)
                ywall = map.Mapheight - ywall;
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth * 3 / 4, invert);
            TerrainGenerationModules.Cliff(map, ywall, Console.WindowWidth * 3 / 4, Console.WindowWidth, -1, invert);
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
            var ywall = MainGame.CurrentLoadedMap.Mapheight * 3 / 4 + Random.Next(-4, 4);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth / 4, invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth / 4, Console.WindowWidth / 2, -1,
                invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth / 2, Console.WindowWidth * 3 / 4,
                -1, invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth * 3 / 4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }

        public static void HillSideInverted(CustomMap map, bool invert)
        {
            var ywall = MainGame.CurrentLoadedMap.Mapheight / 4 + Random.Next(8);
            ywall = TerrainGenerationModules.Flat(map, ywall, 0, Console.WindowWidth / 4, invert);
            ywall = TerrainGenerationModules.ExtremeY(map, ywall, Console.WindowWidth / 4, Console.WindowWidth / 2, 1,
                invert);
            ywall = TerrainGenerationModules.SlowY(map, ywall, Console.WindowWidth / 2, Console.WindowWidth * 3 / 4, 1,
                invert);
            TerrainGenerationModules.Flat(map, ywall, Console.WindowWidth * 3 / 4, Console.WindowWidth, invert);
            TerrainGraphics.Overlay(map, invert);
        }
    }
}