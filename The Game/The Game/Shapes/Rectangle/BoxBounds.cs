using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBounds : ShapeDecorator
    {
        public BoxBounds(BoxBounds copy) : base(copy)
        {
        }

        public BoxBounds(Shape shape, Pixel pixel, Position position, Rectangle boundingBox, Window window)
            : base(shape, pixel, position, boundingBox, window)
        {
        }

        public override void Draw()
        {
            for (int x = 0; x < boundingBox.getWidth(); x++)
            {
                for (int y = 0; y < boundingBox.getHeight(); y += boundingBox.getHeight() - 1)
                {
                    drawToWindow(new Position(x, y), pixel);
                }
            }

            for (int y = 0; y < boundingBox.getHeight(); y++)
            {
                for (int x = 0; x < boundingBox.getWidth(); x += boundingBox.getWidth() - 1)
                {
                    drawToWindow(new Position(x, y), pixel);
                }
            }
        }

        public override Shape Clone()
        {
            return new BoxBounds(this);
        }
    }
}