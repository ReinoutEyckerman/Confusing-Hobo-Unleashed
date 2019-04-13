using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.UI.Windows;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class VerticalList : AbstractList
    {
        public VerticalList(CircularList<UIObject> items, int padding = 0) : base(items, padding)
        {
        }

        public VerticalList(CircularList<UIObject> items, Image image) : base(items, image)
        {
        }

        public VerticalList(CircularList<UIObject> items, Position position, Image image) : base(items, position, image)
        {
        }

        public VerticalList(CircularList<UIObject> items, Position position, Image activeImage, Image inactiveImage) : base(items, position, activeImage, inactiveImage)
        {
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void HandleAction(Input action)
        {
            if (this.isActive)
            {
                HandleActiveAction(action);
            }
            else
            {
                HandleInactiveAction(action);
            }
        }

        private void HandleActiveAction(Input action)
        {
            switch (action)
            {
                case Input.BACK:
                    this.isActive = false;
                    break;
                case Input.UP:
                    items.decrement();
                    break;
                case Input.DOWN:
                    items.increment();
                    break;
                default:
                    items.currentItem().HandleAction(action);
                    break;
            }
        }

        private void HandleInactiveAction(Input action)
        {
            switch (action)
            {
                case Input.A:
                    this.isActive = true;
                    break;
            }
        }
    }
}