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

        public EllipsBounds(Shape decoratedShape, Pixel pixel, Position position, Rectangle boundingBox, Window window)
            : base(decoratedShape, pixel, position, boundingBox, window)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Position center = boundingBox.getGeometricCenter();
            for (int x = 0; x < boundingBox.getWidth(); x++)
            {
                for (int y = 0; y < boundingBox.getHeight(); y++)
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