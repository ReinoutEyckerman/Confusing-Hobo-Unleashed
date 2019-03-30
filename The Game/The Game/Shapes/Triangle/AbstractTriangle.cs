using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes.Triangle
{
    public abstract class AbstractTriangle : ShapeDecorator
    {
        protected AbstractTriangle(ShapeDecorator copy) : base(copy)
        {
        }

        protected AbstractTriangle(Shape decoratedShape, Pixel pixel, Position position, Rectangle boundingBox, Window window) : base(decoratedShape, pixel, position, boundingBox, window)
        {
        }
    }
}