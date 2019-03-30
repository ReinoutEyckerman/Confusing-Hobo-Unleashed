using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBuilder : ShapeBuilder
    {
        public override Shape Build()
        {
            Box box =  new Box(this.rootShape, this.pixel, this.position, new Rectangle(this.width, this.height), this.window);
            box.setOrientation(orientation);
            return box;
        }
    }
}