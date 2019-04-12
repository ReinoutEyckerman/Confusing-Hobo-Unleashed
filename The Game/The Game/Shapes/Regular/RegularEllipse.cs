using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class RegularEllipse : RegularShape
    {
        private int xradius;
        private int yradius;

        public RegularEllipse(RegularEllipse copy) : base(copy)
        {
            this.xradius = copy.xradius;
            this.yradius = copy.yradius;
        }

        protected RegularEllipse(Position position, int width, int height) : base(position, width, height)
        {
            this.xradius = (int) Math.Floor(Math.Pow(getWidth(), 2));
            this.yradius = (int) Math.Floor(Math.Pow(getHeight(), 2));
        }

        protected RegularEllipse(Orientation orientation, Position position, int width, int height) : base(orientation, position, width, height)
        {
            this.xradius = (int) Math.Floor(Math.Pow(getWidth(), 2));
            this.yradius = (int) Math.Floor(Math.Pow(getHeight(), 2));
        }

        public override bool IsOnBorder(int x, int y)
        {
            if (this.IsInsideShape(x, y))
            {
                for (int i = x - 1; i <= x + 1; i += 2)
                {
                    for (int j = y - 1; i <= y + 1; i += 2)
                    {
                        if (this.IsInsideShape(x, y))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public override bool IsInsideShape(int x, int y)
        {
            double xx = Math.Pow(x, 2);
            double yy = Math.Pow(y, 2);
            double a = xx / xradius + yy / yradius;
            return a <= 1 ? true : false;
        }

        public override RegularShape Clone()
        {
            return new RegularEllipse(this);
        }
    }
}