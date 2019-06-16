using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Entity:Updateable
    {
        protected RegularShape shape;

        protected int currentHp;
        protected int maxHp;

        protected bool invincible;


        public Entity(Entity copy)
        {
            maxHp = copy.maxHp;
            currentHp = copy.currentHp;
            invincible = copy.invincible;
            //TODO bounds = new BoundingBox(copy.bounds);
        }

        public Entity(int maxHp, BoundingBox bounds, bool invincible = false)
        {
            this.maxHp = maxHp;
            currentHp = currentHp;
       //TODO     this.bounds = bounds;
            this.invincible = invincible;
        }

        public void tryDamage()
        {
            if (!invincible) Damage();
        }

        protected abstract void Damage();

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
}
}