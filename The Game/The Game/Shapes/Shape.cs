using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class Shape : Drawable
    {
        protected Position position;
        protected Rectangle boundingBox;
        private Window window;
        protected Pixel pixel;
        protected Orientation orientation;

        protected Shape(Shape copy)
        {
            this.window = copy.window;
            this.position = new Position(copy.position);
            this.boundingBox = new Rectangle(copy.boundingBox);
            this.pixel = new Pixel(copy.pixel);
        }

        protected Shape(Pixel pixel, Position position, Rectangle boundingBox, Window window)
        {
            this.position = position;
            this.boundingBox = boundingBox;
            this.window = window;
            this.pixel = pixel;
        }

        public Position getPosition()
        {
            return this.position;
        }

        public Pixel getPixel()
        {
            return this.pixel;
        }

        public Rectangle getBoundingBox()
        {
            return this.boundingBox;
        }

        public Orientation getOrientation()
        {
            return this.orientation;
        }

        public abstract void Draw();

        public abstract Shape Clone();

        public void setOrientation(Orientation orientation)
        {
            this.orientation = orientation;
        }

        protected void drawToWindow(Position position, Pixel pixel)
        {
            position = OrientationTransformation.transform(this.position, boundingBox.getWidth(), boundingBox.getHeight(), orientation);
            window.Draw(position.add(this.position), pixel);
        }
    }
}