using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class FirePitBorder:ShapeDecorator
    {
        private Pixel pixel;
        private Window _window;//TODO
        
        public FirePitBorder(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel pixel) : base(decoratedShape, position, boundingBox)
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
                var y = Convert.ToInt16(w*rico*(x - x1) + height - 1);
                _window.Draw(new Position(x,y), this.pixel);
            }
        }
    }
}