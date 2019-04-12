using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public abstract class ShapeDrawer : GeneratedImage
    {
        protected RegularShape shape;
        protected Pixel pixel;

        public ShapeDrawer(RegularShape shape, Pixel pixel)
        {
            this.shape = shape;
            this.pixel = pixel;
        }

        public abstract Image toImage();
    }
}