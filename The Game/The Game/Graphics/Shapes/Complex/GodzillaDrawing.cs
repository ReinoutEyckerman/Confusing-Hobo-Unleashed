using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class GodzillaDrawing : GeneratedImage
    {
        //TODO Recoloring
        private static Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        private static Pixel h = new Pixel(BaseColor.Black, BaseColor.Black, ' ');
        private static Pixel g = new Pixel(BaseColor.DarkGreen, BaseColor.DarkGreen, ' ');
        private static Pixel l = new Pixel(BaseColor.DarkYellow, BaseColor.DarkYellow, ' ');
        private static Pixel r = new Pixel(BaseColor.Red, BaseColor.Red, ' ');


        public static Pixel[,] Zilla =
        {
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, h, h, h, h, h, h, h, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, h, h, h, h, h, h, h, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, h, h, h, h, h, h, h, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, h, h, h, h, h, h, h, h, h, h, h, h, h, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, r, r, g, g, g, g, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v, v, l, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v, l, l, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, g, g, g, g, v, v, g, g, g, g, g, g, g, l, l, l, l, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, l, l, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, v, v, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, g, g, g, v, v, g, g, g, g, g, g, g, g, g, v, v, v, l, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, l, l, l, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, l, l, l, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, l, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v, v, v, v, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v, v, l, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                g, l, g, l, l, l, l, l, l, l, l, l, l, g, g, g, g, g, g, g, g, g, g, g, g, g, g, l, l, l, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, l, v, l, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, l, l, l, v, v, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, l, v, v, v, l, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v, v, l, l, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, l, l, l, l, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, l, l, v, v, v,
                v, v, v, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, v, v,
                v, v, l, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g,
                l, l, l, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g,
                g, g, l, v, v, v, v, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g,
                g, g, g, g, v, v, l, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, v, v, v, v, v, l, l, l, l, l, g, g, g, g, g, g, g,
                g, g, g, g, g, l, l, v, v, v, v, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, v, v, v, v, v, l, l, l, l, l, l, v, v, v, g, g, g,
                g, g, g, g, g, g, g, v, v, v, l, v
            },
            {
                v, v, v, v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, v, v, v, v, l, l, l, l, l, l, l, v, v, v, v, v, v,
                v, g, g, g, g, g, g, g, g, l, l, v
            },
            {
                v, v, v, v, v, v, v, v, g, g, g, g, g, g, g, g, g, g, v, l, l, l, l, l, l, l, l, l, l, v, v, v, v, v, v,
                v, v, v, v, v, v, g, g, g, g, g, g
            }
        };

        public Image toImage()
        {
            throw new System.NotImplementedException();
        }
    }
}