using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class ShapeBuilder
    {
        protected Window window;

        protected int width;
        protected int height; //TODO Bounding box
        protected Shape rootShape;
        protected Position position;
        protected Pixel pixel;
        protected Orientation orientation;

        public ShapeBuilder()
        {
            this.width = 0;
            this.height = 0;
            this.rootShape = null;
            this.position = new Position(0, 0);
            this.pixel = new Pixel(BaseColor.Void, BaseColor.Void, '');
            this.orientation = Orientation.NORTH;
        }

        public void inheritFromRoot()
        {
            if (this.rootShape == null)
            {
                return;
            }

            this.width = this.rootShape.getWidth();
            this.height = this.rootShape.getHeight();
            this.position = this.rootShape.getPosition();
            this.pixel = this.rootShape.getPixel();
            this.orientation = this.rootShape.getOrientation();
        }

        public ShapeBuilder setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public ShapeBuilder setHeight(int height)
        {
            this.height = height;
            return this;
        }

        public ShapeBuilder setWidthPercentageOfScreen(double widthPercentage)
        {
            this.width = window.getWidthPosFromPercentage(widthPercentage);
            return this;
        }

        public ShapeBuilder setHeigthPercentageOfScreen(double heightPercentage)
        {
            this.height = window.getHeightPosFromPercentage(heightPercentage);
            return this;
        }

        public ShapeBuilder setRootShape(Shape shape)
        {
            this.rootShape = shape;
            return this;
        }

        public ShapeBuilder setPosition(Position position)
        {
            this.position = position;
            return this;
        }

        public ShapeBuilder setPositionRelative(Position position, Shape shape)
        {
            this.position = position.add(shape.getPosition());
            return this;
        }

        public ShapeBuilder setOrientation(Orientation orientation)
        {
            this.orientation = orientation;
            return this;
        }

        public ShapeBuilder setPixel(Pixel pixel)
        {
            this.pixel = pixel;
            return this;
        }

        public abstract Shape Build();
    }
}