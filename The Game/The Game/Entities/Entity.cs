using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Entity
    {
        protected BoundingBox bounds;
        protected int currentHp;

        protected bool invincible;

        protected int maxHp;

        protected Entity(Entity copy)
        {
            maxHp = copy.maxHp;
            currentHp = copy.currentHp;
            invincible = copy.invincible;
            bounds = new BoundingBox(copy.bounds);
        }

        protected Entity(int maxHp, BoundingBox bounds, bool invincible = false)
        {
            this.maxHp = maxHp;
            currentHp = currentHp;
            this.bounds = bounds;
            this.invincible = invincible;
        }

        public void tryDamage()
        {
            if (!invincible) Damage();
        }

        protected abstract void Damage();
    }
}