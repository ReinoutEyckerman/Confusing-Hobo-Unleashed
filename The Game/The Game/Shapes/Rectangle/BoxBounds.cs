using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBounds : ShapeDecorator
    {
        private Window window;//TODO
        private Pixel pixel;
        
        public BoxBounds(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
        {
            this.pixel = pixel;
        }

        public override void Draw()
        {
            base.Draw();
            for (int x = position.x; x < boundingBox.getWidth(); x++)
            {
                for (int y = position.y; y < boundingBox.getHeight(); y += boundingBox.getHeight() - 1)
                {
                    window.Draw(new Position(x,y),this.pixel ); 
                }
            }
            for (int y = position.y; y < boundingBox.getHeight(); y++)
            {
                for (int x = position.x; x < boundingBox.getWidth(); x += boundingBox.getWidth() - 1)
                {
                    window.Draw(new Position(x,y),this.pixel ); 
                }
            }
        }
    }
}