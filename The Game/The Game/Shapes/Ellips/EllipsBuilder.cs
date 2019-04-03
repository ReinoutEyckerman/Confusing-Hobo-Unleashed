using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class EllipsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            Ellips ellips =  new Ellips(this.rootShape, this.pixel,this.window, this.position, this.width, this.height);
            ellips.setOrientation(orientation);
            return ellips;
        }
    }
}