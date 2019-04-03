using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class EllipsBounds : AbstractEllips
    {
        public EllipsBounds(EllipsBounds copy) : base(copy)
        {
        }


        public EllipsBounds(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Position center = getGeometricCenter();
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y = 0; y < getHeight(); y++)
                {
                    if (isBorderPoint(x, y))
                    {
                        drawToWindow(new Position(x, y), pixel);
                    }
                }
            }
        }

        public override Shape Clone()
        {
            return new EllipsBounds(this);
        }
    }
}