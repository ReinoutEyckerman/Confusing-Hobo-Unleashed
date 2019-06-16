using System;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Entity:Updateable//TODO: Teams (of hostility)
    {
        protected ShapedImage shape;

        protected int currentHp;
        protected int maxHp;

        protected bool invincible;


        public Entity(Entity copy)
        {
            maxHp = copy.maxHp;
            currentHp = copy.currentHp;
            invincible = copy.invincible;
            this.shape = copy.shape;
        }

        public Entity(int maxHp, ShapedImage shape, bool invincible = false)
        {
            this.maxHp = maxHp;
            currentHp = currentHp;
            this.shape = shape;
            this.invincible = invincible;
        }

        public void tryDamage(int damage)
        {
            if (!invincible) Damage(damage);
        }

        protected virtual void Damage(int damage)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
}
}