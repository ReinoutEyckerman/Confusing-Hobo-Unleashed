using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.Graphics.Image
{
    public class ShapedImage
    {
        private Image Image;
        private RegularShape _shape;

        public ShapedImage(Image image, RegularShape shape)
        {
            this.Image = image;
            this._shape = shape;
        }
        
    }
}