using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class RegularShape : BoundingBox
    {
        protected Orientation orientation;

        protected RegularShape(RegularShape copy) : base(copy)
        {
            this.orientation = copy.orientation;
        }

        protected RegularShape(Position position, int width, int height) : base(position, width, height)
        {
        }

        protected RegularShape(Orientation orientation, Position position, int width, int height) : this(position, width, height)
        {
            this.orientation = orientation;
        }

        public Orientation getOrientation()
        {
            return this.orientation;
        }

        public void setOrientation(Orientation orientation)
        {
            this.orientation = orientation;
        }

        public bool IsInsideShape(Position point)
        {
            return this.IsInsideShape(point.x, point.y);
        }

        public abstract bool IsInsideShape(int x, int y);

        public bool IsOnBorder(Position point)
        {
            return this.IsOnBorder(point.x, point.y);
        }

        public abstract bool IsOnBorder(int x, int y);

        public abstract RegularShape Clone();
    }
}