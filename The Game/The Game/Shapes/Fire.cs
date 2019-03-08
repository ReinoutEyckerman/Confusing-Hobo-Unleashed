using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confusing_Hobo_Unleashed.Shapes
{
    class Fire
    {

        private Position position;
        private Window window; //TODO
        private int height;
        private int width;

        public Fire(Window window, Position position,int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.window = window;

        }

        public void DrawFire()
        {
            var fire1 = new BaseColor[width, height];
            var random = new Random();

            var ycur = height;
            for (var x = 0; x < width; x++)
            {
                int direction;
                if (x < width/6)
                    direction = -2;
                else if (x < width/3)
                    direction = 1;
                else if (x < width*1/2)
                    direction = -3;
                else if (x < width*2/3)
                    direction = 3;
                else if (x < width*5/6)
                    direction = -1;
                else
                    direction = 2;
                if (ycur >= height)
                    direction = -2;
                ycur += random.Next(-1, 2) + direction;
                if (ycur < 0)
                    ycur = 0;
                for (var y = ycur; y < height; y++)
                {
                    fire1[x, y] = BaseColor.Yellow;
                }
            }
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (fire1[i, j] == BaseColor.Yellow && ((i - 1 >= 0 && fire1[i - 1, j] != BaseColor.Red && fire1[i - 1, j] != BaseColor.Yellow || i + 1 < fire1.GetLength(0) && fire1[i + 1, j] != BaseColor.Red && fire1[i + 1, j] != BaseColor.Yellow) || i == 0 || i == fire1.GetLength(0) - 1))
                        fire1[i, j] = BaseColor.Red;
                    window.DrawTile(new Position(i+10, j), fire1[i, j]);
                }
            }
        }
    }
}
