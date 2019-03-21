using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.Shapes
{
    public class ShapeFactory
    {
        public Text createText(string text, Position position, ColorPoint color, Shape decoratedShape = null)
        {
            return new Text(text,position,color,decoratedShape);
        }
        
        public 
    }
}