using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class Moon
    {
        public static readonly Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        public static readonly Pixel g = new Pixel(BaseColor.Gray, BaseColor.Gray, ' ');
        public static readonly Pixel d = new Pixel(BaseColor.DarkGray, BaseColor.DarkGray, ' ');

        Pixel[,] moon =
        {
            {v, v, v, v, v, g, d, g, g, v, v, v, v, v},
            {v, v, v, g, g, g, d, d, g, g, g, v, v, v},
            {v, v, g, g, g, g, g, g, g, g, g, d, v, v},
            {v, v, g, g, g, d, g, g, g, g, d, d, v, v},
            {v, v, g, g, d, d, d, g, d, d, d, d, v, v},
            {v, g, g, d, d, d, g, g, g, d, g, d, g, v},
            {v, g, d, d, d, g, g, g, g, g, g, g, g, v},
            {v, g, g, d, d, d, g, g, g, g, g, g, g, v},
            {v, g, g, g, d, d, d, g, g, g, g, g, g, v},
            {v, g, g, g, g, d, d, g, g, g, d, d, g, v},
            {v, v, g, g, g, g, g, g, g, g, d, d, v, v},
            {v, v, g, g, g, g, g, g, g, g, g, d, v, v},
            {v, v, g, g, g, g, d, g, g, g, g, g, v, v},
            {v, v, v, g, g, g, g, g, g, g, g, v, v, v},
            {v, v, v, v, v, g, g, g, g, v, v, v, v, v}
        };
    }
}