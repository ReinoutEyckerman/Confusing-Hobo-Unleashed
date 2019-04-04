using System.Net.Mime;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class ShapeDecorator : Shape
    {
        protected Shape decoratedShape;

        protected ShapeDecorator(ShapeDecorator copy) : base(copy)
        {
            this.decoratedShape = copy.decoratedShape.Clone();
        }

        protected ShapeDecorator(Shape decoratedShape, Pixel pixel, Window window,Position position, int width, int height) : base(pixel, window, position, width, height)
        {
            this.decoratedShape = decoratedShape;
        }

        public override Image toImage()
        {
            return decoratedShape.toImage();
        }
    }
}