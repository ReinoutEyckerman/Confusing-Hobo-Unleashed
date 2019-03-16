using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public abstract class Shape
    {
        protected Position position;
        protected Rectangle boundingBox;

        protected Shape(Position position, Rectangle boundingBox)
        {
            this.position = position;
            this.boundingBox = boundingBox;
        }

        public Position getPosition()
        {
            return this.position;
        }

        public Rectangle getBoundingBox()
        {
            return this.boundingBox;
        }

        public abstract void Draw();
    }
}