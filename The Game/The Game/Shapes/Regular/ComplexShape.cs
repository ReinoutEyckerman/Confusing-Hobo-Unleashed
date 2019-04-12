using System.Collections.Generic;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class ComplexShape : RegularShape
    {
        private List<RegularShape> shapes;

        public ComplexShape(ComplexShape copy) : base(copy)
        {
            this.shapes = copy.shapes;
        }

        public ComplexShape(Position position, int width, int height) : base(position, width, height)
        {
            this.shapes = new List<RegularShape>();
        }

        public ComplexShape(Orientation orientation, Position position, int width, int height) : base(orientation, position, width, height)
        {
            this.shapes = new List<RegularShape>();
        }

        public override bool IsInsideShape(int x, int y)
        {
            foreach (RegularShape shape in this.shapes)
            {
                if (!shape.IsInsideShape(x, y))
                {
                    return false;
                }
            }

            return true; //TOOD check coordinates
        }

        public override bool IsOnBorder(int x, int y)
        {
            foreach (RegularShape shape in this.shapes)
            {
                if (!shape.IsOnBorder(x, y))
                {
                    return false;
                }
            }

            return true; //TOOD check coordinates
        }

        public override RegularShape Clone()
        {
            return new ComplexShape(this);
        }

        public void addShape(RegularShape shape)
        {
            this.shapes.Add(shape);
        }

        public void addShapes(List<RegularShape> shapes)
        {
            this.shapes.AddRange(shapes);
        }
    }
}