using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Box : ShapeDecorator
    {
        public Box(Box copy) : base(copy)
        {
        }

        public Box(Shape shape, Pixel pixel, Position position, Rectangle boundingBox, Window window) : base(shape, pixel, position, boundingBox, window)
        {
        }

        public override void Draw()
        {
            for (int x = 0; x < boundingBox.getWidth(); x++)
            {
                for (int y = 0; y < boundingBox.getHeight(); y++)
                {
                    drawToWindow(new Position(x, y), pixel);
                }
            }
        }

        public override Shape Clone()
        {
            return new Box(this);
        }
    }
}