using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI
{
    class MicrosoftWindow : Window
    {
        public const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        public static IntPtr MyConsole = GetConsoleWindow();

        private Buffer buffer;
        private int width;
        private int height;

        public MicrosoftWindow()
        {
            Console.CursorVisible = false;
            SetWindowPos(MyConsole, 0, 0, 0, 0, 0, SWP_NOSIZE);
            width = Console.LargestWindowWidth - 2;
            height = Console.LargestWindowHeight - 1;
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.Title = "Confusing Hobo Unleashed";

            buffer = new Buffer(width, height, width, height);
            buffer.SetDrawCord(0, 0);
        }

        public void Draw(Position position, BaseColor backgroundColor, BaseColor foregroundColor, string text)
        {
            ConsoleColor bg = getConsoleColor(backgroundColor);
            ConsoleColor fg = getConsoleColor(foregroundColor);
            short encodedColor = ColorsToAttribute(bg,fg);
            buffer.Draw(text, position.x, position.y, encodedColor);
        }

        public void DrawTile(Position position, BaseColor tileColor)
        {
            ConsoleColor color = getConsoleColor(tileColor);
            short encodedColor = ColorsToAttribute(color,color);
            setCursorPosition(position);
            buffer.Draw(" ", position.x, position.y, encodedColor);
        }

        public void DrawRectangle(Rectangle rectangle, BaseColor tileColor)
        {
            ConsoleColor color = getConsoleColor(tileColor);
            short encodedColor = ColorsToAttribute(color,color);
            for(int x = rectangle.topleft.x; x<rectangle.bottomright.x; x++)
            {
                for(int y = rectangle.topleft.y; y<rectangle.bottomright.y; y++)
                {
                    buffer.Draw(" ",x, y, encodedColor);
                }
            }
        }

        public void Clear()
        {
            buffer.Clear();
        }

        public void Paint()
        {
            buffer.Print();
        }

        public int getWidthPosFromPercentage(double percentage)
        {
            return getPercentage(width, percentage);
        }

        public int getHeightPosFromPercentage(double percentage)
        {
            return getPercentage(height, percentage);
        }

        private int getPercentage(int baseNumber, double percentage)
        {
            percentage = Math.Min(Math.Max(0, percentage), 1);
            int x = Convert.ToInt32(Convert.ToDouble(baseNumber) * percentage);
            return x;
        }

        private void setBackgroundColor(BaseColor drawColor)
        {
            ConsoleColor color = getConsoleColor(drawColor);
            Console.BackgroundColor = Painter.Instance.Paint(color);
        }

        private void setForegroundColor(BaseColor drawColor)
        {
            ConsoleColor color = getConsoleColor(drawColor);
            Console.ForegroundColor = Painter.Instance.Paint(color);
        }

        private ConsoleColor getConsoleColor(BaseColor drawColor)
        {
            ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), drawColor.ToString());
            return consoleColor;
        }

        private void setCursorPosition(Position position)
        {
            Console.SetCursorPosition(position.x, position.y);
        }
        private short ColorsToAttribute(ConsoleColor bg, ConsoleColor fg)
        {
            var bgValue = (byte)(bg);
            var fgValue = (byte)(fg);
            var attribute = Convert.ToInt16((bgValue) * 16 + fgValue);
            return attribute;
        }
    }
}
