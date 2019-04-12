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
    class Fire : ShapeDecorator
    {
        private Window window; //TODO

        private Random fireRandomizer;
        private int layers = 3;
        private Pixel outerFire;
        private Pixel middleFire;
        private Pixel coreFire;

        public Fire(Fire copy) : base(copy)
        {
            this.outerFire = new Pixel(copy.outerFire);
            this.middleFire = new Pixel(copy.middleFire);
            this.coreFire = new Pixel(copy.coreFire);
            this.fireRandomizer = new Random();
        }

        public Fire(Shape decoratedShape, Pixel pixel, Window window, Position position, int width, int height) : base(decoratedShape, pixel, window, position, width, height)
        {
            this.outerFire = outerFire;
            this.middleFire = middleFire;
            this.coreFire = coreFire;
            this.fireRandomizer = new Random();
        }

        public override Image toImage()
        {
            int width = this.getWidth();
            int height = getHeight();

            Pixel[,] grid = new Pixel[width, height];

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
                    grid[x, y] = coreFire;
                }
            }

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (grid[i, j].GetBackgroundColor() == BaseColor.Yellow && ((i - 1 >= 0 && grid[i - 1, j].GetBackgroundColor() != BaseColor.Red && grid[i - 1, j].GetBackgroundColor() != BaseColor.Yellow || i + 1 < grid.GetLength(0) && grid[i + 1, j].GetBackgroundColor() != BaseColor.Red && grid[i + 1, j].GetBackgroundColor() != BaseColor.Yellow) || i == 0 || i == grid.GetLength(0) - 1))
                        grid[i, j] = new Pixel(BaseColor.Red, grid[i, j].GetForegroundColor(), this.pixel.getCharacter());
                }
            }

            return base.toImage().addTopLayer(new Image(grid, this.position));
        }

        public override Shape Clone()
        {
            return new Fire(this);
        }

        private int getRandomDirection(int x)
        {
            int division = nextLargerNumber(x);
            int direction = 1;
            if (division > layers)
            {
                direction *= -1;
                division = layers + 1 - (division - 1) % layers;
            }

            return direction * fireRandomizer.Next(-1, division);
        }

        private int nextLargerNumber(int x)
        {
            for (int division = 1; division <= layers * 2; division++)
            {
                int largerNumber = getWidth() / division;
                if (x <= largerNumber)
                {
                    return division;
                }
            }

            return layers * 2;
        }
    }
}