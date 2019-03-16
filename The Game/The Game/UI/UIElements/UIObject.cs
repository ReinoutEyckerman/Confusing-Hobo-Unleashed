using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    abstract class UIObject
    {
        private Shape shape;

        UIObject(Shape shape)
        {
            this.shape = shape;
        }

        public abstract bool IsActive();
        public abstract void HandleAction();

        public void Draw()
        {
            shape.Draw();
        }
    }
}
