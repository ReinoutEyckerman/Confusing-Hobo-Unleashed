using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class AbstractEllips : ShapeDecorator
    {
        private int xradius;
        private int yradius;

        public AbstractEllips(AbstractEllips copy) : base(copy)
        {
            double xradius = copy.xradius;
            double yradius = copy.yradius;
        }

        protected AbstractEllips(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
            this.xradius = (int) Math.Floor(Math.Pow(getWidth(), 2));
            this.yradius = (int) Math.Floor(Math.Pow(getHeight(), 2));
        }

        protected bool isBorderPoint(int x, int y)
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

        protected bool isPointInEllips(int x, int y)
        {
            double xx = Math.Pow(x, 2);
            double yy = Math.Pow(y, 2);
            double a = xx / xradius + yy / yradius;
            return a <= 1 ? true : false;
        }
    }
}