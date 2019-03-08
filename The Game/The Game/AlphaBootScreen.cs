using System;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed
{
    internal class AlphaBootScreen
    {
        public static void DrawAlphaSymbol(Window window)
        {
            BaseColor color = BaseColor.White;

            Position topleft = new Position(window.getWidthPosFromPercentage(0.25), window.getHeightPosFromPercentage(0.25));
            Position bottomright = new Position(window.getWidthPosFromPercentage(0.5), window.getHeightPosFromPercentage(0.35));
            Rectangle rectangle = new Rectangle(topleft, bottomright);
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.625));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.75));
            window.DrawRectangle(rectangle, color);

            topleft = new Position(window.getWidthPosFromPercentage(0.15), window.getHeightPosFromPercentage(0.35));
            bottomright = new Position(window.getWidthPosFromPercentage(0.35), window.getHeightPosFromPercentage(0.45));
            rectangle = new Rectangle(topleft, bottomright);
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.4));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.6));
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.525));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.725));
            window.DrawRectangle(rectangle, color);

            topleft = new Position(window.getWidthPosFromPercentage(0.05), window.getHeightPosFromPercentage(0.45));
            bottomright = new Position(window.getWidthPosFromPercentage(0.25), window.getHeightPosFromPercentage(0.55));
            rectangle = new Rectangle(topleft, bottomright);
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.5));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.625));
            window.DrawRectangle(rectangle, color);

            topleft = new Position(window.getWidthPosFromPercentage(0.15), window.getHeightPosFromPercentage(0.55));
            bottomright = new Position(window.getWidthPosFromPercentage(0.35), window.getHeightPosFromPercentage(0.65));
            rectangle = new Rectangle(topleft, bottomright);
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.4));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.6));
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.525));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.725));
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.425));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.625));
            window.DrawRectangle(rectangle, color);

            topleft = new Position(window.getWidthPosFromPercentage(0.25), window.getHeightPosFromPercentage(0.65));
            bottomright = new Position(window.getWidthPosFromPercentage(0.5), window.getHeightPosFromPercentage(0.75));
            rectangle = new Rectangle(topleft, bottomright);
            window.DrawRectangle(rectangle, color);

            rectangle.setTopX(window.getWidthPosFromPercentage(0.625));
            rectangle.setBottomX(window.getWidthPosFromPercentage(0.55));
            window.DrawRectangle(rectangle, color);

            BaseColor BackgroundColor = BaseColor.Black;
            BaseColor ForegroundColor = BaseColor.White;
            int y = window.getHeightPosFromPercentage(0.85);
            Position position = new Position(0, y);
            window.Draw(position, BackgroundColor, ForegroundColor, "Confusing Hobo Unleashed".PadLeft(window.getWidthPosFromPercentage(0.5) + 12));
            position = new Position(0, y + 1);
            window.Draw(position, BackgroundColor, ForegroundColor, "By Oliver Hofkens & Reinout Eyckerman".PadLeft(window.getWidthPosFromPercentage(0.5) + 18));
            position = new Position(0, y + 3);
            window.Draw(position, BackgroundColor, ForegroundColor, "A Team Alpha Production".PadLeft(window.getWidthPosFromPercentage(0.5) + 11));
            window.Paint();
        }
    }
}