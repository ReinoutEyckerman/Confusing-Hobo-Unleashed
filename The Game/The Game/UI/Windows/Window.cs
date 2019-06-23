using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI
{
    public interface Window
    {
        void Draw(Position position, Pixel pixel);
        void DrawText(Position position, ColorPoint color, string text);

        void Clear();
        void Paint();
        int getWidth();
        int getHeight();
        int getWidthPosFromPercentage(double percentage);
        int getHeightPosFromPercentage(double percentage);
        void setColorScheme(ColorSchemes colorScheme);
    }
}