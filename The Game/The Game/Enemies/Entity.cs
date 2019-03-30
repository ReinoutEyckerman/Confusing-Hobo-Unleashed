using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class Entity:Drawable
    {
        protected Shape shape;
        protected Position position;
        protected int hp;

        public abstract void Attack();
        public abstract void Move();

        public abstract void Hit();//TODO

        public virtual void Draw()
        {
            if (hp > 0)
            {
                shape.Draw();
            }
        }
    }
}