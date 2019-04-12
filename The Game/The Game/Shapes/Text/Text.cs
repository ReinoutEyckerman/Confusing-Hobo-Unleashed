using System;
using System.Net.Mime;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class Text : BoundingBox, GeneratedImage, ICloneable
    {
        private readonly string text;
        private ColorPoint colorPoint;

        public Text(Text copy) : base(copy)
        {
            this.text = copy.text;
            this.colorPoint = copy.colorPoint;
        }

        public Text(string text, ColorPoint colorPoint, Position position) : base(position, text.Length, 1)
        {
            this.text = text;
            this.colorPoint = colorPoint;
        }

        public void centerText(BoundingBox bounds) //TODO
        {
            if (bounds.getWidth() < text.Length)
            {
                throw new Exception(); //TODO
            }

            int x = position.x + (bounds.getWidth() - text.Length) / 2;
            int y = position.y + bounds.getHeight() / 2;
            this.position = new Position(x, y);
        }

        public Image toImage()
        {
            Pixel[,] grid = new Pixel[this.getWidth(), this.getHeight()];
            for (int x = 0; x < text.Length; x++)
            {
                grid[x, 0] = new Pixel(this.colorPoint.GetBackgroundColor(), this.colorPoint.GetForegroundColor(), text[x]);
            }

            return new Image(grid, this.position);
        }

        public object Clone()
        {
            return new Text(this);
        }
    }
}