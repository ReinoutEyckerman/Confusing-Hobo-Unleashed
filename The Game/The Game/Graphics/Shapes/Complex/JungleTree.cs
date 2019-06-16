using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class JungleTree : GeneratedImage
    {
        private static Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        private static Pixel w = new Pixel(BaseColor.DarkRed, BaseColor.Void, ' ');
        private static Pixel l = new Pixel(BaseColor.DarkGreen, BaseColor.Void, ' ');

        private static readonly Pixel[,] JungleTreeSmall =
        {
            {v, v, v, v, l, l, l, l, l, v, v, v, v},
            {v, v, v, l, l, l, l, l, l, l, v, v, v},
            {v, v, l, l, l, l, l, l, l, l, l, v, v},
            {v, v, l, l, l, l, l, l, l, l, l, v, v},
            {v, v, v, v, v, w, w, w, v, v, v, v, v},
            {v, l, l, l, l, w, w, w, v, v, v, v, v},
            {l, l, l, l, l, l, w, w, v, v, v, v, v},
            {v, v, w, w, v, w, w, w, l, l, l, l, v},
            {v, v, w, w, w, w, w, l, l, l, l, l, l},
            {v, v, v, v, v, w, w, w, v, w, w, v, v},
            {v, v, v, v, v, w, w, w, w, w, w, v, v},
            {v, v, v, v, v, w, w, w, v, v, v, v, v},
            {v, v, v, v, v, w, w, w, v, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, v, v, v, v}
        };

        private static readonly Pixel[,] JungleTreeLarge =
        {
            {v, v, v, v, v, v, v, l, l, l, v, v, v, v, v, v, v, v, v},
            {v, v, v, v, v, l, l, l, l, l, l, l, v, v, v, v, v, v, v},
            {v, v, v, l, l, l, l, l, l, l, l, l, l, l, v, v, v, v, v},
            {v, v, l, l, l, l, l, l, l, l, l, l, l, l, l, l, v, v, v},
            {v, l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, v, v},
            {l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, v, v},
            {v, l, l, l, l, l, l, l, l, l, l, l, l, l, l, l, v, v, v},
            {v, v, v, l, l, l, l, l, l, l, l, l, l, l, v, l, l, v, v},
            {v, v, v, v, v, v, w, l, w, w, w, v, v, l, l, l, l, v, v},
            {v, v, v, v, v, v, w, l, w, w, w, v, l, l, l, l, l, l, l},
            {v, v, v, v, v, v, w, l, w, w, w, v, l, l, l, l, l, l, l},
            {v, v, v, l, l, v, w, w, w, w, w, v, v, v, w, w, w, v, v},
            {v, l, l, l, l, l, w, w, w, w, w, w, w, w, w, w, v, v, v},
            {l, l, l, l, l, l, l, w, w, w, w, w, w, w, v, v, v, v, v},
            {l, l, l, l, l, l, l, l, w, w, w, v, v, v, v, v, v, v, v},
            {v, l, v, w, w, v, w, w, w, w, w, v, l, l, l, v, v, v, v},
            {v, l, v, w, w, w, w, w, w, w, w, l, l, l, l, l, l, v, v},
            {v, l, v, w, w, w, w, w, w, w, w, l, l, l, l, l, l, v, v},
            {v, l, v, v, v, v, w, w, w, w, w, v, l, w, w, v, v, v, v},
            {v, l, v, v, v, v, w, w, w, w, w, w, l, w, w, v, v, v, v},
            {v, l, v, v, v, v, w, w, w, w, w, w, l, w, v, v, v, v, v},
            {v, l, v, v, v, v, w, w, w, w, w, v, l, v, v, v, v, v, v},
            {v, l, v, v, v, v, w, w, w, w, w, v, l, v, v, v, v, v, v},
            {v, l, v, v, v, w, w, w, w, w, w, v, l, v, v, v, v, v, v},
            {v, v, v, v, v, w, w, w, w, w, w, w, l, v, v, v, v, v, v},
            {v, v, v, v, w, w, w, w, w, w, w, w, l, v, v, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v},
            {v, v, w, w, w, w, w, w, w, w, w, w, w, w, w, v, v, v, v}
        };

        public Image toImage()
        {
            throw new System.NotImplementedException();
        }
    }
}