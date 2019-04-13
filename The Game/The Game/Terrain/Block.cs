using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Block
    {
        private Position position;
        private Pixel pixel;
        private bool invincible;
        private int hp;

        public Block(Block copy)
        {
            this.position = copy.position;
            this.pixel = copy.pixel;
            this.invincible = copy.invincible;
            this.hp = copy.hp;
        }

        public Block(Pixel pixel, bool invincible, int hp, Position position)
        {
            this.pixel = pixel;
            this.invincible = invincible;
            this.hp = hp;
            this.position = position;
        }
    }
}