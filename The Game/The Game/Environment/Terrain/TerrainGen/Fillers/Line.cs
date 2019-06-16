using System;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Line
    {
        public static Entity[,] fillLine(Orientation orientation, Entity block, int width, int height, int start, int stop)
        {
            switch (orientation)
            {
                case Orientation.EAST:
                    return line(block, height, width, start, stop); //TODO Rotate!
                case Orientation.WEST:
                    stop = width - stop;
                    start = width - start;
                    return line(block, height, width, start, stop); //TODO Rotate!
                case Orientation.NORTH:
                    stop = height - stop;
                    start = height - start;
                    return line(block, width, height, start, stop);
                case Orientation.SOUTH:
                    return line(block, width, height, start, stop);
            }
            throw new NotImplementedException();//TODO
        }

        private static Entity[,] line(Entity blocks, int width, int height, int startY, int endY)
        {
            Entity[,] grid = new Entity[width, height];
            double differential = (endY - startY) / (double) width;

            for (int x = 0; x < width; x++)
            {
                int start = (int) (differential * x) + startY;
                for (int y = start; y < height; y++)
                {
                    grid[x, y] = blocks;
                }
            }

            return grid;
        }
    }
}