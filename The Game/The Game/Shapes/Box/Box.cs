using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Box : ShapeDecorator
    {
        public Box(Box copy) : base(copy)
        {
        }

        public Box(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
        }

        public override void Draw()
        {
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y = 0; y <getHeight(); y++)
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