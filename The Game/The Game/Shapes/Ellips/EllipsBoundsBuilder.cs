using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class EllipsBoundsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            EllipsBounds ellipsBounds =  new EllipsBounds(this.rootShape, this.pixel,this.window, this.position, this.width, this.height);
            ellipsBounds.setOrientation(orientation);
            return ellipsBounds;
        }
    }
}