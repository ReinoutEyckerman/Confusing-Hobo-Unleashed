﻿using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    internal abstract class Button : UIObject
    {
        private Shape inactiveShape;
        private Shape activeShape;
        private Text inactiveText;
        private Text activeText;
        private Window _window; //todo

        protected Button( Shape activeShape, Shape inactiveShape, string text): base()
        {
            this.activeShape = activeShape;
            this.inactiveShape = inactiveShape;
            this.activeText = new Text(text, activeShape.getPosition(), activeShape.);
            this.inactiveText = new Text(text, inactiveShape.getPosition(), inactiveShape);
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
        }
    }
}