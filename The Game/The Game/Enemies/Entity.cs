using System.Net.Mime;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Entity:BoundingBox
    {
        protected int hp;
        protected bool invincible;

        protected Entity(BoundingBox copy) : base(copy)
        {
        }

        protected Entity(Position position, int width, int height) : base(position, width, height)
        {
        }

        protected Entity(int width, int height) : base(width, height)
        {
        }

        public void tryDamage()
        {
            if (!this.invincible)
            {
                this.Damage();
            }
        }

        protected abstract void Damage();
        
    }
}