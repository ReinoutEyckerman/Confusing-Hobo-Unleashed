using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    public abstract class AbstractList : UIObject
    {
        protected CircularList<UIObject> items;

        private int ringIndex = 0;
        
        protected AbstractList( CircularList<UIObject> items, Shape shape): base(shape)
        {
            this.items = items;
        }
        
        protected AbstractList(CircularList<UIObject> items, Shape activeShape, Shape inactiveShape): base(activeShape,inactiveShape)
        {
            this.items = items;
        }

        public override void Draw()
        {
            base.Draw();
            DrawItems();
        }

        private void DrawItems()
        {
            foreach (UIObject uiObject in items)
            {
                uiObject.Draw();
            }
        }
    }
}