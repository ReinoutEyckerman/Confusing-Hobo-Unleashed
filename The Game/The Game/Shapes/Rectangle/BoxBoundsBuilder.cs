using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBoundsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            BoxBounds boxBounds =  new BoxBounds(this.rootShape, this.pixel, this.position, new Rectangle(this.width, this.height), this.window);
            boxBounds.setOrientation(orientation);
            return boxBounds;
        }
    }
}