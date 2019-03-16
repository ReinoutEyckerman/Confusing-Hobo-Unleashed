using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Box : ShapeDecorator
    {
        private Rectangle rectangle;
        private Window window; //todo
        private readonly Pixel pixel;
        
        public Box(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
        {
            this.rectangle = boundingBox;
            this.pixel = pixel;
        }

        public override void Draw()
        {
            base.Draw();
            for (int x = position.x; x < rectangle.getWidth(); x++)
            {
                for (int y = position.y; y < rectangle.getHeight(); y++)
                {
                    window.Draw(new Position(x,y), pixel);
                }
                
            }
        }
    }
}