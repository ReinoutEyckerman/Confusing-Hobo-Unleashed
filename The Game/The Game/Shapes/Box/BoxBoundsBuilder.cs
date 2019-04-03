using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBoundsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            BoxBounds boxBounds =  new BoxBounds(this.rootShape, this.pixel,this.window, this.position,this.width, this.height);
            boxBounds.setOrientation(orientation);
            return boxBounds;
        }
    }
}