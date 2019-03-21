using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class TextBlock:UIObject
    {
        public TextBlock(Shape shape) : base(shape)
        {
            
        }

        public TextBlock(Shape activeShape, Shape inactiveShape) : base(activeShape, inactiveShape)
        {
            
        }

        public override void HandleAction(Input action)
        {
            return;
        }
    }
}