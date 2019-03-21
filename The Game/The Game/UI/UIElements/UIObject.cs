using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{

    public abstract class UIObject : Drawable
    {
        protected bool isActive;
        private Shape activeShape;
        protected Shape inactiveShape;


        protected UIObject(Shape shape):this(shape,shape)
        {
        }
        
        protected UIObject(Shape  activeShape, Shape inactiveShape)
        {
            this.activeShape = activeShape;
            this.inactiveShape = inactiveShape;
        }

        public virtual bool IsActive()
        {
            return this.isActive;
        }

        public virtual void Draw()
        {
            if (IsActive())
            {
                activeShape.Draw();
            }
            else
            {
                inactiveShape.Draw();
            }
        }

        public abstract void HandleAction(Input action);
    }
}