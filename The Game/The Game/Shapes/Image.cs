using System;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class Image : Bounding, Drawable
    {
        private Pixel[,] imageGrid;
        private Window window;


        public Image(int width, int height) : base(new Position(0, 0), width, height)
        {
            this.imageGrid = new Pixel[width, height];
        }

        public Image(Pixel[,] imageGrid) : base(new Position(0, 0), imageGrid.GetLength(0), imageGrid.GetLength(1)) //TODO new pos
        {
            this.imageGrid = imageGrid;
        }

        public Image addTopLayer(Image topLayer)
        {
            Position topLeft = Position.getMinPosition(this.position, topLayer.position);
            Position bottomRight = Position.getMaxPosition(this.position.add(new Position(this.getWidth(), this.getHeight())), topLayer.position.add(new Position(topLayer.getWidth(), topLayer.getHeight())));
            Position dimensions = bottomRight.substract(topLeft);
            int width = dimensions.x;
            int height = dimensions.y;
            Pixel[,] imagegrid = new Pixel[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Pixel pixel = new Pixel();

                    Position currentPosition = topLeft.add(new Position(i, j));
                    if (this.isPointInside(currentPosition))
                    {
                        pixel.add(this.imageGrid[i, j]);
                    }

                    if (topLayer.isPointInside(currentPosition))
                    {
                        pixel.add(topLayer.imageGrid[i, j]);
                    }

                    imagegrid[i, j] = pixel;
                }
            }
            return new Image(imagegrid);
        }

        public void Draw()
        {
            for (int i = 0; i < this.getWidth(); i++)
            {
                for (int j = 0; j < this.getHeight(); j++)
                {
                    if (this.imageGrid[i, j] != null)
                    {
                        this.window.Draw(this.position.add(new Position(i, j)), this.imageGrid[i, j]);
                    }
                }
            }
        }
    }
}