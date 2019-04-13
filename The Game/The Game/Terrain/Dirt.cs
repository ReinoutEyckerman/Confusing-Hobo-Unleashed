using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Dirt : Block
    {
        private static Pixel pixel = new Pixel(BaseColor.DarkRed, BaseColor.DarkRed, ' ');
        private static int hp = 4;

        public Dirt(Block copy) : base(copy)
        {
        }

        public Dirt( Position position) : base(pixel, false, hp, position)
        {
        }
        
        public Dirt(bool invincible, Position position) : base(pixel, invincible, hp, position)
        {
        }
    }
}