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


        public Ellips(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
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