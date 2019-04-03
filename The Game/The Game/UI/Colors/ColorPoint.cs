using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.Colors
{
    public class ColorPoint
    {
        private readonly BaseColor backgroundColor;
        private readonly BaseColor foregroundColor;

        public ColorPoint()
        {
            this.backgroundColor = BaseColor.Void;
            this.foregroundColor = BaseColor.Void;
        }
        
        public ColorPoint(ColorPoint copy)
        {
            this.backgroundColor = copy.backgroundColor;
            this.foregroundColor = copy.foregroundColor;
        }

        public ColorPoint(BaseColor backgroundColor, BaseColor foregroundColor)
        {
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
        }

        public BaseColor GetBackgroundColor()
        {
            return backgroundColor;
        }

        public BaseColor GetForegroundColor()
        {
            return foregroundColor;
        }

        public virtual ColorPoint add(ColorPoint colorPoint)//TODO Check if this works
        {
            BaseColor bg = colorPoint.backgroundColor == BaseColor.Void ? this.backgroundColor : colorPoint.backgroundColor;
            BaseColor fg = colorPoint.foregroundColor == BaseColor.Void ? this.foregroundColor : colorPoint.foregroundColor;
            return new ColorPoint(bg,fg);
        }
    }
}