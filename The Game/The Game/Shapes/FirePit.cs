using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class FirePit
    {
        private BaseColor[,] _firepits;
        private Position position;
        private Window window; //TODO
        private int height;
        private int width;

        public FirePit(Window window, Position position,int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.window = window;

        }
        public void DrawFirePits()
        {
            _firepits = new BaseColor[width, height];
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
                for (short y = 0; y <= ypos; y++)
                {
                    _firepits[x, y] = y == ypos ? BaseColor.DarkGray : BaseColor.Gray;
                }
            }
            for(int x=0; x<width; x++)
            {
                for(int y=0; y<height; y++)
                {
                    window.DrawTile(new Position(position.x + x, position.y + y), _firepits[x, y]);
                }
            }
        }
    }
}
