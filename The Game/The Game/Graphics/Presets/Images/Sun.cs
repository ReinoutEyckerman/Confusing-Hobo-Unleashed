using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class Sun
    {
        public static readonly Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        public static readonly Pixel r = new Pixel(BaseColor.Red, BaseColor.Red, ' ');
        public static readonly Pixel d = new Pixel(BaseColor.DarkYellow, BaseColor.DarkYellow, ' ');

        Pixel[,] sun =
        {
            {v, v, v, v, v, r, d, r, r, v, v, v, v, v},
            {v, v, v, r, r, r, d, d, r, r, r, v, v, v},
            {v, v, r, r, r, r, r, r, r, r, r, d, v, v},
            {v, v, r, r, r, d, r, r, r, r, d, d, v, v},
            {v, v, r, r, d, d, d, r, d, d, d, d, v, v},
            {v, r, r, d, d, d, r, r, r, d, r, d, r, v},
            {v, r, d, d, d, r, r, r, r, r, r, r, r, v},
            {v, r, r, d, d, d, r, r, r, r, r, r, r, v},
            {v, r, r, r, d, d, d, r, r, r, r, r, r, v},
            {v, r, r, r, r, d, d, r, r, r, d, d, r, v},
            {v, v, r, r, r, r, r, r, r, r, d, d, v, v},
            {v, v, r, r, r, r, r, r, r, r, r, d, v, v},
            {v, v, r, r, r, r, d, r, r, r, r, r, v, v},
            {v, v, v, r, r, r, r, r, r, r, r, v, v, v},
            {v, v, v, v, v, r, r, r, r, v, v, v, v, v}
        };
    }
}