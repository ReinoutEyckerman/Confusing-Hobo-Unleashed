using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI
{
    interface Window
    {
        void Draw(Position position, BaseColor backgroundColor, BaseColor foregroundColor, string text);
        void DrawTile(Position position, BaseColor tileColor);
        void DrawRectangle(Rectangle rectangle, BaseColor tileColor);
        void Clear();
        void Paint();
        int getWidthPosFromPercentage(double percentage);
        int getHeightPosFromPercentage(double percentage);
    }
}