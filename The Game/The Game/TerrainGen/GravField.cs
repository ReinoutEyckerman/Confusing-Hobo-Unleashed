using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.TerrainGen
{
    public class GravField
    {
        private readonly int[,] gravitationalField;

        public GravField(int defaultValue, int width, int height)
        {
            this.gravitationalField = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    this.gravitationalField[x, y] = defaultValue;
                }
            }
        }

        public int getGravity(Position position)
        {
            return this.gravitationalField[position.x, position.y];
        }
    }
}