using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class TextBlock:UIObject
    {

        public override void HandleAction(Input action)
        {
            return;
        }

        public TextBlock(Position position, Image image) : base(position, image)
        {
        }

        public TextBlock(Position position, Image activeImage, Image inactiveImage) : base(position, activeImage, inactiveImage)
        {
        }
    }
}