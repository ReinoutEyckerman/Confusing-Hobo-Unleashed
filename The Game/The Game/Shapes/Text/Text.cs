using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class Text : ShapeDecorator
    {
        private readonly string text;

        public Text(Text copy) : base(copy)
        {
            this.text = copy.text;
        }


        public Text(string text, Shape decoratedShape, ColorPoint colorPoint, Window window, Position position) : base(decoratedShape, new Pixel(colorPoint.GetBackgroundColor(), colorPoint.GetForegroundColor(), ' '), window, position, text.Length, 1)
        {
            this.position = position;
            this.text = text;
        }

        public void centerText(Bounding bounds) //TODO
        {
            if (bounds.getWidth() < text.Length)
            {
                throw new Exception(); //TODO
            }

            int x = position.x + (bounds.getWidth() - text.Length) / 2;
            int y = position.y + bounds.getHeight() / 2;
            this.position = new Position(x, y);
        }

        public override void Draw()
        {
            for (int x = 0; x < text.Length; x++)
            {
                drawToWindow(new Position(x, 0), new Pixel(this.pixel.GetBackgroundColor(), this.pixel.GetForegroundColor(), text[x]));
            }
        }

        public override Shape Clone()
        {
            return new Text(this);
        }
    }
}