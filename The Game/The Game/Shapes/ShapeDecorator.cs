using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class ShapeDecorator: Shape
    {
        protected Shape decoratedShape;

        protected ShapeDecorator(Shape decoratedShape, Position position, Rectangle boundingBox): base(position,boundingBox)
        {
            this.decoratedShape = decoratedShape;
        }

        public override void Draw()
        {
            decoratedShape.Draw();
        }
    }
}