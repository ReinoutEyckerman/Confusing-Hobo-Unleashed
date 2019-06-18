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
            //TODO Mana regen
        }
        //TODO
        public virtual void SetSpawn()
        {
            int X = 0;
            int Y = 0;
            for (var xpos = Convert.ToInt16(Map.Mapwidth - 1); xpos >= 0; xpos--)
            {
                for (short ypos = 0; ypos < Map.Mapheight; ypos++)
                {
                    if (Map.Grav[ypos, xpos] >= 0)
                    {
                        if (ypos + 1 < Map.Mapheight && !Map.Collision[ypos, xpos] && Map.Collision[ypos + 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                    }
                    else if (Map.Grav[ypos, xpos] < 0)
                        if (ypos - 1 > 0 && !Map.Collision[ypos, xpos] && Map.Collision[ypos - 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                }
                if (X != 0 || Y != 0)
                    break;
            }
        }
}
}