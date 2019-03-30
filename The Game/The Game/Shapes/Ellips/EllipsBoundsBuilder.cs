using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class EllipsBoundsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            EllipsBounds ellipsBounds =  new EllipsBounds(this.rootShape, this.pixel, this.position, new Rectangle(this.width, this.height), this.window);
            ellipsBounds.setOrientation(orientation);
            return ellipsBounds;
        }
    }
}