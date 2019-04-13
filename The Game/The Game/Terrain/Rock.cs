using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Rock : Block
    {
        private static Pixel pixel = new Pixel(BaseColor.DarkGray, BaseColor.Gray, ' ');
        private static int hp = 10;

        public Rock(Block copy) : base(copy)
        {
        }

        public Rock( Position position) : base(pixel, false, hp, position)
        {
        }
        
        public Rock(bool invincible, Position position) : base(pixel, invincible, hp, position)
        {
        }
    }
}