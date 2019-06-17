using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Shapes.Complex
{
    public class Weed: GeneratedImage
    {
        private static readonly Pixel w = new Pixel(BaseColor.Green, BaseColor.Green, 'L');//TODO recolor bw?
        private static readonly Pixel v = new Pixel(BaseColor.Void, BaseColor.Void, ' ');
        private static readonly Pixel[,] weed =
        {
            {w, v, v, v, v},
            {v, v, w, w, w},
            {w, v, v, w, w}
        };

        public Image toImage()
        {
            throw new System.NotImplementedException();
        }
    }
}