using System;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class RegularRectangle : RegularShape
    {
        public RegularRectangle(RegularShape copy) : base(copy)
        {
        }

        public RegularRectangle(Position position, int width, int height) : base(position, width, height)
        {
        }

        public RegularRectangle(Orientation orientation, Position position, int width, int height) : base(orientation, position, width, height)
        {
        }

        public override bool IsInsideShape(int x, int y)
        {
            return this.isPointInside(x, y);
        }

        public override bool IsOnBorder(int x, int y)
        {
            if ((x.Equals(this.position.x) || x.Equals(this.position.x + this.getWidth())) && (y.Equals(this.position.y) || y.Equals(this.position.y + this.getHeight())))
            {
                return true;
            }

            return false;
        }

        public override RegularShape Clone()
        {
            return new RegularRectangle(this);
        }
    }
}