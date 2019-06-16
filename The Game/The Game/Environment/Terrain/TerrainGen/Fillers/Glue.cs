using System;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Glue
    {
        public static Entity[,] glue(Entity[,] main, Entity[,] addition, Orientation orientation, int glueDistance)
        {
            if (main.GetLength(1) != addition.GetLength(1) || main.GetLength(0) != addition.GetLength(0))
            {
                throw new NotImplementedException(); //TODO
            }

            if (glueDistance > main.GetLength(1) && glueDistance > main.GetLength(0))
            {
                throw new NotImplementedException(); //TODO
            }

            int width = main.GetLength(0) + addition.GetLength(0);
            int height = main.GetLength(1) + addition.GetLength(1);
            switch (orientation)
            {
                case Orientation.EAST:
                    width -= glueDistance;
                    break;
                case Orientation.WEST:
                    width -= glueDistance;
            }

            Entity[,] grid = new Entity[main,];
            for
        }

        private static Entity[,] baseGlue(Entity[,] main, Entity[,] addition, int glueDistance)
        {
            int width = main.GetLength(0) + addition.GetLength(0) - glueDistance;

            int height = main.GetLength(1);

            Entity[,] grid = new Entity[width, height];
            for (int x = 0; x < main.GetLength(0); x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = main[x, y];
                }
            }

            for (int x = glueDistance; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y] == null)
                    {
                        grid[x, y] = addition[x - glueDistance, y];
                    }
                }
            }

            return grid;
        }

        public static Entity[,] crack(Entity[,] main, Entity[,] addition, Orientation orientation, int glueDistance)
        {
            
        }
        private static Entity[,] crack(Entity[,] main, Entity[,] addition, int glueDistance)
        {
            int width = main.GetLength(0) + addition.GetLength(0) - glueDistance;

            int height = main.GetLength(1);

            Entity[,] grid = new Entity[width, height];
            for (int x = 0; x < main.GetLength(0); x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = main[x, y];
                }
            }

            for (int x = glueDistance; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y] != null && addition[x-glueDistance,y]==null)
                    {
                        grid[x, y] = null;
                    }
                }
            }

            return grid;
        }
    }
}