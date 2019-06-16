using Confusing_Hobo_Unleashed.Enemies;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Fill
    {
        public static Entity[,] fill(Entity block, int width, int height)
        {
            Entity[,] grid = new Entity[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = block;//TODO Copy constructor?
                }
            }

            return grid;
        }
    }
}