using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class ImageFrame:UIObject
    {
        public ImageFrame(Position position, Image image) : base(position, image)
        {
        }

        public ImageFrame(Position position, Image activeImage, Image inactiveImage) : base(position, activeImage, inactiveImage)
        {
        }

        public override void HandleAction(Input action)
        {
            throw new System.NotImplementedException();
        }
    }
}