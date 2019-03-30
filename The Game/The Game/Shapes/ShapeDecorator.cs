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

        protected ShapeDecorator(Shape decoratedShape, Pixel pixel, Position position, Rectangle boundingBox,
            Window window) : base(pixel, position, boundingBox, window)
        {
            this.decoratedShape = decoratedShape;
        }

        public override void Draw()
        {
            decoratedShape.Draw();
        }
    }
}