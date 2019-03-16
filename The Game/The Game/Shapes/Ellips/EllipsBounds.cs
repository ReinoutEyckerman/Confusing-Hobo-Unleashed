using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class EllipsBounds : ShapeDecorator
    {
        private Window window; //todo
        private readonly Pixel pixel;
        private int xradius;
        private int yradius;
        
        public EllipsBounds(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
        {
            double xradius = Math.Pow(boundingBox.getWidth(), 2);
            double yradius = Math.Pow(boundingBox.getHeight(), 2);
            this.pixel = pixel;
        }

        public override void Draw()
        {
            base.Draw();
            Position center = boundingBox.getGeometricCenter();
            for (int x = position.x; x < boundingBox.getWidth(); x++)
            {
                for (int y = position.y; y < boundingBox.getHeight(); y++)
                {
                    if (isEdgePoint(x, y))
                    {
                        window.Draw(new Position(x, y), pixel);
                    }
                }
            }

        }

        private bool isEdgePoint(int x, int y)
        {
            if (isPointInEllips(x, y))
            {
                for (int i = x - 1; i <= x + 1; i += 2)
                {
                    for (int j = y - 1; i <= y + 1; i += 2)
                    {
                        if (isPointInEllips(x - 1, y))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool isPointInEllips(int x, int y)
        {
            double xx = Math.Pow(x, 2);
            double yy = Math.Pow(y, 2);
            double a = xx / xradius + yy / yradius;
            return a <= 1 ? true : false;
        }
    }
}