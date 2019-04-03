using System.Net.Mime;
using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class TextBuilder:ShapeBuilder
    {
        private string text;

        public TextBuilder():base()
        {
            this.text = "";
        }
        
        public TextBuilder setText(string text)
        {
            this.text = text;
            return this;
        }
        
        public override Shape Build()
        {
            Text textString =  new Text(text,this.rootShape, this.pixel, this.window,this.position);
            textString.setOrientation(this.orientation);
            return textString;
        }
    }
}