using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Grass : Block
    {
        private static readonly Pixel pixel = new Pixel(BaseColor.DarkGreen, BaseColor.Green, '\'');
        private static readonly int maxHp = 2;

        public Grass(Block copy) : base(copy)
        {
        }

        public Grass(Position position) : base(pixel, maxHp, new BoundingBox(position, 1, 1))
        {
        }
    }
}