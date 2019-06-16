using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.TerrainGen.Fillers
{
    public class Triangle
    {
        public static Entity[,] fillTriangle(Orientation orientation, Entity block, int width, int height)
        {
            return Line.fillLine(orientation, block, width, height, height, 0);
        }
    }
}