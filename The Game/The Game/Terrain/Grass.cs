using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Grass : Block
    {
        private static Pixel pixel = new Pixel(BaseColor.DarkGreen, BaseColor.Green, '\'');
        private static int hp = 2;

        public Grass(Block copy) : base(copy)
        {
        }

        public Grass( Position position) : base(pixel, false, hp, position)
        {
        }
        
        public Grass(bool invincible, Position position) : base(pixel, invincible, hp, position)
        {
        }
    }
}