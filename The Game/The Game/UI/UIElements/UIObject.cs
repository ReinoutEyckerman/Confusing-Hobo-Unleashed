using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public abstract class UIObject : Drawable
    {
        public abstract bool IsActive();
        public abstract void HandleAction();

        public abstract void Draw();
    }
}
