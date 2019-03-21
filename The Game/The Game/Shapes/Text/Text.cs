using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class Text:ShapeDecorator
    {
        private readonly string text;
        private ColorPoint color;
        private Window window;//TODO

        public Text(Text copy):this(copy.text,copy)
        {
        }
        
        private Text(string text, Text baseText):base(baseText.decoratedShape,baseText.position, baseText.boundingBox)
        {
            this.position = baseText.position;
            this.text = text;
            this.color = baseText.color;
        }
        
        public Text(string text,  Position position, ColorPoint color, Shape decoratedShape):base(decoratedShape, position, new Rectangle(position,text.Length,1))
        {
            this.position = position;
            this.text = text;
            this.color = color;
        }

        public virtual Text setText(string text)
        {
            return new Text(text,this);
        }
        
        public void centerText(Rectangle bounds)//TODO
        {
            if (bounds.getWidth() < text.Length)
            {
                throw new Exception();//TODO
            }

            int x = position.x + (bounds.getWidth() - text.Length) / 2;
            int y = position.y + bounds.getHeight() / 2;
            this.position = new Position(x, y);
        }

        public override void Draw()
        {
            window.DrawText(this.position,  this.color, this.text);
        }
    }
}