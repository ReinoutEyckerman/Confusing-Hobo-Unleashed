using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class Ellips : AbstractEllips
    {
        public Ellips(Ellips copy) : base(copy)
        {
        }

        public Ellips(Shape decoratedShape, Pixel pixel, Position position, Rectangle boundingBox,
            Window window) : base(decoratedShape, pixel, position, boundingBox, window)
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
                    if (isPointInEllips(x, y))
                    {
                        drawToWindow(new Position(x, y), pixel);
                    }
                }
            }
        }

        public override Shape Clone()
        {
            return new Ellips(this);
        }
    }
}