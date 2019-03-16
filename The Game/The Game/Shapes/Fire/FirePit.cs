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
    class FirePit : ShapeDecorator
    {
        private Window window; //TODO
        private Pixel pixel;
        
        public FirePit(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
        {
            this.pixel = pixel;
        }
        
        public override void Draw()
        {
            int width = boundingBox.getWidth();
            int height = boundingBox.getHeight();
            var rico = Convert.ToDouble(height)/(width- 5);

            var x1 = width;
            short w = 1;
            for (short x = 0; x < width; x++)
            {
                if (x == width/4)
                {
                    w = 0;
                }
                else if (x == width*3/4)
                {
                    w = -1;
                    x1 = width * 3 / 4;
                }
                var ypos = Convert.ToInt16(w*rico*(x - x1) + height - 1);
            }
            for(int x=0; x<width; x++)
            {
                for(int y=0; y<height; y++)
                {
                    window.Draw(new Position(position.x + x, position.y + y), this.pixel);
                }
            }
        }

    }
}
