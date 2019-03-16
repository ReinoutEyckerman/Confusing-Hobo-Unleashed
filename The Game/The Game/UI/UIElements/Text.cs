using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class Text: UIObject
    {
        protected Position position;
        protected readonly string text;
        protected ColorPoint color;
        protected Window window;//TODO
        
        public Text(string text, Position position, ColorPoint color)
        {
            this.position = position;
            this.text = text;
            this.color = color;
        }

        public virtual Text setText(string text)
        {
            return new Text(text, position, color);
        }
        
        public void centerText(Rectangle bounds)
        {
            if (bounds.getWidth() < text.Length)
            {
                throw new Exception();//TODO
            }

            int x = position.x + (bounds.getWidth() - text.Length) / 2;
            int y = position.y + bounds.getHeight() / 2;
            this.position = new Position(x, y);
        }
        
        public override bool IsActive()
        {
            return false;
        }

        public override void HandleAction()
        {
        }

        public override void Draw()
        {
            window.DrawText(this.position,  this.color, this.text);
        }
    }
}