using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class ComplexDrawer:ShapeDrawer
    {
        public ComplexDrawer(RegularShape shape, Pixel pixel) : base(shape, pixel)
        {
        }

        public override Image toImage()
        {
            throw new System.NotImplementedException();
        }
    }
}