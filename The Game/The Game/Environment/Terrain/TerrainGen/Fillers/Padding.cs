using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Padding
    {
        public void PadAll(Entity[,] terrain, int thickness, Entity padder, Orientation orientation)
        {
        }

        public void PadFirst(Entity[,] terrain, int thickness, Entity padder, Orientation orientation)
        {
        }

        private void padTopDown(Entity[,] terrain, int thickness, Entity padder, bool First)
        {
            for (int x = 0; x < terrain.GetLength(0); x++)
            {
                for (int y = 1; y < terrain.GetLength(1); y++)
                {
                    if (terrain[x, y] != null && terrain[x, y - 1] == null)
                    {
                        for (int fillY = y - 1; fillY >= y - thickness && fillY >= 0; fillY--)
                        {
                            if (terrain[x, fillY] != null)
                            {
                                break;
                            }

                            terrain[x, fillY] = padder;
                        }

                        if (First)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}