using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class VerticalList : UIObject
    {
        private Text inactiveTitle;
        private Text activeTitle;
        private Window _window; //todo

        private CircularList<UIObject> items;

        private int ringIndex = 0;
        
        protected VerticalList( Shape activeShape, Shape inactiveShape, string title): base(activeShape, inactiveShape)
        {
            this.activeTitle = new Text(title, activeShape.getPosition(), activeShape.);
            this.inactiveTitle = new Text(title, inactiveShape.getPosition(), inactiveShape);
        }

        public bool Value { get; set; }
        public List<int> VarChanger { get; set; }

        public void setText(string text)
        {
            this.activeText = this.activeText.setText(text);
            this.inactiveText = this.inactiveText.setText(text);
        }

        public void ChangeValue()
        {
            Value = !Value;
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void HandleAction(Input action)
        {
            if (isActive)
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
        
        private void switchActive()
        {
            this.isActive = !isActive;
        }

        public override void Draw()
        {
            if (IsActive())
            {
                activeShape.Draw();
            }
            else
            {
                inactiveShape.Draw();
            }
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