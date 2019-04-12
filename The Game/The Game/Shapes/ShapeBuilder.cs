using System;
using System.Reflection;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class ShapeBuilder
    {
        protected Window window;

        protected int width;
        protected int height; //TODO Bounding box
        protected Position position;
        protected Orientation orientation;
        protected Type type;

        public ShapeBuilder()
        {
            this.width = 0;
            this.height = 0;
            this.position = new Position(0, 0);
            this.orientation = Orientation.NORTH;
            this.type = typeof(RegularRectangle);
        }

        public void inheritFrom(RegularShape regularShape)
        {
            if (regularShape == null)
            {
                return;
            }

            this.width = regularShape.getWidth();
            this.height = regularShape.getHeight();
            this.position = regularShape.getPosition();
            this.orientation = regularShape.getOrientation();
            this.type = typeof(RegularShape);
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

        public ShapeBuilder setPosition(Position position)
        {
            this.position = position;
            return this;
        }

        public ShapeBuilder setPositionPercentageOfScreen(double x, double y)
        {
            this.position = new Position(this.window.getWidthPosFromPercentage(x), this.window.getHeightPosFromPercentage(y));
            return this;
        }

        public ShapeBuilder setPositionRelative(Position position, BoundingBox boundingBox) //Todo ?
        {
            this.position = position.add(boundingBox.getPosition());
            return this;
        }

        public ShapeBuilder setOrientation(Orientation orientation)
        {
            this.orientation = orientation;
            return this;
        }

        public ShapeBuilder setType(Type type)
        {
            this.type = type;
            return this;
        }

        public RegularShape Build()
        {
            ConstructorInfo ctor = type.GetConstructor(new[] {typeof(Orientation), typeof(Position), typeof(int), typeof(int)});
            return (RegularShape) ctor.Invoke(new object[] {this.orientation, this.position, this.width, this.height});
        }
    }
}