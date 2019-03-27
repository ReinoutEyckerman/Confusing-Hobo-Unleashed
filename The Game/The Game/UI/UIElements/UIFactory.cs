using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class UIFactory
    {
        public static Button createButton(TriggerEventHandler triggerEventHandler, Shape shape)
        {
            return new  Button(shape,triggerEventHandler);
        }

        public static Shape createBox(BoxBounds boxBounds = null)
        {
            Box box;
            if (boxBounds != null)
            {
                box = new Box(boxBounds); 
                
            }
        }
        
    }
}