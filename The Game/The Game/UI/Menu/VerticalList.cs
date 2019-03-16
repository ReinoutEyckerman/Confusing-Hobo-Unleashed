using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class VerticalList : UIObject
    {
        private Shape inactiveShape;
        private Shape activeShape;
        private Text inactiveTitle;
        private Text activeTitle;
        private Window _window; //todo

        private List<UIObject> items;

        protected VerticalList( Shape activeShape, Shape inactiveShape, string text): base()
        {
            this.activeShape = activeShape;
            this.inactiveShape = inactiveShape;
            this.activeTitle = new Text(text, activeShape.getPosition(), activeShape.);
            this.inactiveTitle = new Text(text, inactiveShape.getPosition(), inactiveShape);
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

        public override void HandleAction()
        {
            throw new NotImplementedException();
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