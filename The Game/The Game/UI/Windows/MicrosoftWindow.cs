using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI.Colors;
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

        private ColorScheme colorScheme;

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
            colorScheme = new ColorScheme();
        }

        public void DrawText(Position position, ColorPoint color, string text)
        {
            short encodedColor = ColorsToAttribute(color);
            buffer.Draw(text, position.x, position.y, encodedColor);
        }
        
        public void Draw(Position position, Pixel pixel)
        {
            short encodedColor = ColorsToAttribute(pixel);
            buffer.Draw(pixel.getCharacter().ToString(), position.x, position.y, encodedColor);
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

        public void setColorScheme(ColorSchemes colorScheme)
        {
            this.colorScheme.setColorScheme(colorScheme);
        }

        private int getPercentage(int baseNumber, double percentage)
        {
            percentage = Math.Min(Math.Max(0, percentage), 1);
            int x = Convert.ToInt32(Convert.ToDouble(baseNumber) * percentage);
            return x;
        }

        private ConsoleColor getConsoleColor(BaseColor drawColor)
        {
            ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), drawColor.ToString());
            return consoleColor;
        }

        private short ColorsToAttribute(ColorPoint colorPoint)
        {
            ColorPoint translatedColor = colorScheme.translateColor(colorPoint);
            ConsoleColor backgroundColor = getConsoleColor(translatedColor.GetBackgroundColor());
            ConsoleColor foregroundColor = getConsoleColor(translatedColor.GetForegroundColor());
            var bgValue = (byte)(backgroundColor);
            var fgValue = (byte)(foregroundColor);
            var attribute = Convert.ToInt16((bgValue) * 16 + fgValue);
            return attribute;
        }
    }
}
