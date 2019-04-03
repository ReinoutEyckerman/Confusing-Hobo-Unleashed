using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class Trapeze : ShapeDecorator
    {
        public Trapeze(Trapeze copy) : base(copy)
        {
        }


        public Trapeze(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
            this.pixel = pixel;
        }

        public override void Draw()
        {
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

                var ypos = Convert.ToInt16(w * rico * (x - x1) + height - 1);
            }

            for (int x = 0; x < width; x++) //TODO
            {
                for (int y = 0; y < height; y++)
                {
                    drawToWindow(new Position(x, y), this.pixel);
                }
            }
        }

        public override Shape Clone()
        {
            return new Trapeze(this);
        }
    }
}