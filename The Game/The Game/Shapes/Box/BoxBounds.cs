using System.Net.Mime;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class BoxBounds : ShapeDecorator
    {
        public BoxBounds(BoxBounds copy) : base(copy)
        {
        }


        public BoxBounds(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
        }

        public override Image toImage()
        {
            Pixel[,] grid  = new Pixel[this.getWidth(),this.getHeight()];
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y = 0; y < getHeight(); y +=getHeight() - 1)
                {
                    grid[x,y]= pixel;
                }
            }

            for (int y = 0; y < getHeight(); y++)
            {
                for (int x = 0; x < getWidth(); x += getWidth() - 1)
                {
                    grid[x,y]= pixel;
                }
            }
            return base.toImage().addTopLayer(new Image(grid,this.position));
        }

        public override Shape Clone()
        {
            return new BoxBounds(this);
        }
    }
}