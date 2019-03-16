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
    class Fire: ShapeDecorator
    {

        private Window window; //TODO

        private Random fireRandomizer;
        private int layers = 3;
        private Pixel outerFire;
        private Pixel middleFire;
        private Pixel coreFire;

        public Fire(Shape decoratedShape, Position position, Rectangle boundingBox, Pixel outerFire, Pixel middleFire, Pixel coreFire) : base(decoratedShape, position, boundingBox)
        {
            this.outerFire = outerFire;
            this.middleFire = middleFire;
            this.coreFire = coreFire;
            this.fireRandomizer = new Random();
        }

        public void Draw()
        {
            int width = boundingBox.getHeight();
            int height = boundingBox.getHeight();
            
            Pixel[,] fire = new Pixel[width, height];
            
            var ycur = height;
            for (var x = 0; x < width; x++)
            {
                int verticalDirection = getRandomDirection(x);
                
       

                if (ycur >= height)
                {
                    verticalDirection = -2;
                }

                ycur += verticalDirection;
                if (ycur < 0)
                {
                    ycur = 0;
                }

                for (var y = ycur; y < height; y++)
                {
                    fire[x,y]=coreFire ;
                }
            }
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (fire[i, j] == BaseColor.Yellow && ((i - 1 >= 0 && fire1[i - 1, j] != BaseColor.Red && fire1[i - 1, j] != BaseColor.Yellow || i + 1 < fire1.GetLength(0) && fire1[i + 1, j] != BaseColor.Red && fire1[i + 1, j] != BaseColor.Yellow) || i == 0 || i == fire1.GetLength(0) - 1))
                        fire[i, j] = BaseColor.Red;
                    window.DrawTile(new Position(i+10, j), fire1[i, j]);
                }
            }
        }

        private int getRandomDirection(int x)
        {
            int division = nextLargerNumber(x);
            int direction = 1;
            if (division > layers)
            {
                direction *= -1;
                division = layers+1 - (division-1) % layers ;
            }

            return direction * fireRandomizer.Next(-1, division);
        }

        private int nextLargerNumber(int x)
        {
            for (int division = 1; division <= layers * 2; division++)
            {
                int largerNumber = boundingBox.getWidth() / division;
                if (x <= largerNumber)
                {
                    return division;
                }
            }

            return layers * 2;
        }
    }
}
