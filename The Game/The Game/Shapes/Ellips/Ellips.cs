using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class Ellips: ShapeDecorator
    {
        private Window window; //todo
        private readonly Pixel pixel;
        private int xradius;
        private int yradius;
        
        public Ellips(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
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
                    if (isPointInEllips(x, y))
                    {
                        window.Draw(new Position(x, y), pixel);
                    }
                }
            }

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
