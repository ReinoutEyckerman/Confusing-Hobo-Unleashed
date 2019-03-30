using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class EllipsBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            Ellips ellips =  new Ellips(this.rootShape, this.pixel, this.position, new Rectangle(this.width, this.height), this.window);
            ellips.setOrientation(orientation);
            return ellips;
        }
    }
}