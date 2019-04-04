using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class TrapezeBorder : ShapeDecorator
    {
        public TrapezeBorder(TrapezeBorder copy) : base(copy)
        {
        }


        public TrapezeBorder(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
            this.pixel = pixel;
        }

        public override Image toImage()
        {
            Pixel[,] grid = new Pixel[this.getWidth(), this.getHeight()];
            var rico = Convert.ToDouble(height) / (width - 5);
            var x1 = width;
            short w = 1;
            for (short x = 0; x < width; x++)
            {
                if (x == width / 4)
                {
                    w = 0;
                }
                else if (x == width * 3 / 4)
                {
                    w = -1;
                    x1 = width * 3 / 4;
                }

                var y = Convert.ToInt16(w * rico * (x - x1) + height - 1);
                grid[x, y] = this.pixel;
            }

            return base.toImage().addTopLayer(new Image(grid, this.position));
        }

        public override Shape Clone()
        {
            return new TrapezeBorder(this);
        }
    }
}