using System;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Graphics.Image
{
    public class Interpolator
    {
        //TODO Test this code
        public static Image interpolateCatmullRom(Image image, int targetWidth, int targetHeight)
        {
            Pixel[,] imageGrid = image.ImageGrid;
            double xScaling = targetWidth / (double) imageGrid.GetLength(0);
            double yScaling = targetHeight / (double) imageGrid.GetLength(1); //TODO check Dimension correctness
            double[,] doubleGrid = toDoubles(imageGrid);
        }

        private static double[,] toDoubles(Pixel[,] pixelGrid)
        {
            double[,] doubleGrid = new double[pixelGrid.GetLength(0), pixelGrid.GetLength(1)];
            double enumSize =Enum.GetNames(typeof(BaseColor)).Length;
            for (int x = 0; x < pixelGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pixelGrid.GetLength(1); y++)
                {
                    if (pixelGrid[x, y] == null)
                    {
                        doubleGrid[x, y] = (int) BaseColor.Void / enumSize;
                    }
                    else
                    {
                        doubleGrid[x, y] = (int) pixelGrid[x,y].GetBackgroundColor() / enumSize;
                    }
                }
            }

            return doubleGrid;
        }

        private static Pixel[,] toPixels(double[,] doubleGrid)
        {
            Pixel[,] pixelGrid = new Pixel[doubleGrid.GetLength(0),doubleGrid.GetLength(1)];
            double enumSize =Enum.GetNames(typeof(BaseColor)).Length;
            for (int x = 0; x < pixelGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pixelGrid.GetLength(1); y++)
                {
                    pixelGrid[x, y] = new Pixel((BaseColor)(int)(doubleGrid[x,y] * enumSize), BaseColor.Void,'');
                }
            }

            return pixelGrid;
        }

        public static double CatmullRom(double[] p, double scaling) //TODO check if actually is Catmull-Rom
        {
            return p[1] + 0.5 * scaling *
                   (p[2] - p[0] + scaling *
                    (2.0 * p[0] - 5.0 * p[1] + 4.0 * p[2] - p[3] + scaling *
                     (3.0 * (p[1] - p[2]) + p[3] - p[0])));
        }

        public double CubicCatmullRom(double[][] p, double xScaling, double yScaling) //TODO check if actually catmull
        {
            double[] arr = new double[4];
            arr[0] = CatmullRom(p[0], yScaling);
            arr[1] = CatmullRom(p[1], yScaling);
            arr[2] = CatmullRom(p[2], yScaling);
            arr[3] = CatmullRom(p[3], yScaling);
            return CatmullRom(arr, xScaling);
        }

        public Pixel[,] nearestNeighbour(Pixel[,] pixels, int targetWidth, int targetHeight)
        {
            Pixel[,] temp = new Pixel[targetWidth, targetHeight];
            double x_ratio = pixels.GetLength(0) / targetWidth;
            double y_ratio = pixels.GetLength(1) / targetHeight; //TODO check and ensure correct dimension selection
            int px, py;
            for (int i = 0; i < targetHeight; i++)
            {
                for (int j = 0; j < targetWidth; j++)
                {
                    px = (int) Math.Floor(j * x_ratio);
                    py = (int) Math.Floor(i * y_ratio);
                    temp[j, i] = pixels[py, px];
                }
            }

            return temp;
        }
    }
}