using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class FilledShapeDrawer : ShapeDrawer
    {
        private RegularShape shape;
        private Pixel pixel;

        public FilledShapeDrawer(RegularShape shape, Pixel pixel):base(shape,pixel)
        {
            this.shape = shape;
            this.pixel = pixel;
        }

        public override Image toImage()
        {
            Pixel[,] grid = new Pixel[this.shape.getWidth(), this.shape.getHeight()];
            for (int x = 0; x < shape.getWidth(); x++)
            {
                for (int y = 0; y < shape.getHeight(); y++)
                {
                    if (this.shape.IsInsideShape(x, y))
                        grid[x, y] = this.pixel;
                }
            }

            return AbstractUIFactory.getInstance().buildImage(grid, this.shape.getPosition());
        }
    }
}