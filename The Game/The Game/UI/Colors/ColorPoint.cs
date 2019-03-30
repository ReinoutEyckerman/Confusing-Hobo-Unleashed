using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.Colors
{
    public class ColorPoint
    {
        private readonly BaseColor backgroundColor;
        private readonly BaseColor foregroundColor;

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
    }
}