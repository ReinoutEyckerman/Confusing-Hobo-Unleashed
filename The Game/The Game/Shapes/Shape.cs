using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class Shape :Bounding, Drawable
    {
        private Window window;
        protected Pixel pixel;
        protected Orientation orientation;

        protected Shape(Shape copy):base(copy)
        {
            this.window = copy.window;
            this.pixel = new Pixel(copy.pixel);
        }

        protected Shape(Pixel pixel, Window window,Position position, int width, int height):base(position,width,height)
        {
            this.window = window;
            this.pixel = pixel;
        }

        public Pixel getPixel()
        {
            return this.pixel;
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
            position = OrientationTransformation.transform(this.position, getWidth(),getHeight(), orientation);
            window.Draw(position.add(this.position), pixel);
        }
    }
}