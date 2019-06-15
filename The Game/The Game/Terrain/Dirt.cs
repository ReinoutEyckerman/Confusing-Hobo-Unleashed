using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Dirt : Block
    {
        private static readonly Pixel pixel = new Pixel(BaseColor.DarkRed, BaseColor.DarkRed, ' ');
        private static readonly int maxHp = 4;

        public Dirt(Block copy) : base(copy)
        {
        }

        public Dirt(Position position) : base(pixel, maxHp, new BoundingBox(position, 1, 1))
        {
        }
    }
}