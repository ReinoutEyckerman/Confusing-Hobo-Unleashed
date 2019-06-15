using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Rock : Block
    {
        private static readonly Pixel pixel = new Pixel(BaseColor.DarkGray, BaseColor.Gray, ' ');
        private static readonly int maxHp = 10;

        public Rock(Block copy) : base(copy)
        {
        }

        public Rock(Position position) : base(pixel, maxHp, new BoundingBox(position, 1, 1))
        {
        }
    }
}