using System;
using System.Collections.Generic;
using System.Threading;

namespace Confusing_Hobo_Unleashed
{
    public class ColorList
    {
        public ConsoleColor Black { get; set; }
        public ConsoleColor Green { get; set; }
        public ConsoleColor DarkGreen { get; set; }
        public ConsoleColor Blue { get; set; }
        public ConsoleColor DarkBlue { get; set; }
        public ConsoleColor Yellow { get; set; }
        public ConsoleColor DarkYellow { get; set; }
        public ConsoleColor Red { get; set; }
        public ConsoleColor DarkRed { get; set; }
        public ConsoleColor Cyan { get; set; }
        public ConsoleColor DarkCyan { get; set; }
        public ConsoleColor Magenta { get; set; }
        public ConsoleColor DarkMagenta { get; set; }
        public ConsoleColor Gray { get; set; }
        public ConsoleColor DarkGray { get; set; }
        public ConsoleColor White { get; set; }
    }

    public class ColorSchemes
    {
        public ColorSchemes()
        {
            BackGroundList = new List<ColorList>
            {
                new ColorList //Normal
                {
                    Black = ConsoleColor.Black,
                    Green = ConsoleColor.Green,
                    DarkGreen = ConsoleColor.DarkGreen,
                    Blue = ConsoleColor.Blue,
                    DarkBlue = ConsoleColor.DarkBlue,
                    Red = ConsoleColor.Red,
                    DarkRed = ConsoleColor.DarkRed,
                    Yellow = ConsoleColor.Yellow,
                    DarkYellow = ConsoleColor.DarkYellow,
                    Cyan = ConsoleColor.Cyan,
                    DarkCyan = ConsoleColor.DarkCyan,
                    Magenta = ConsoleColor.Magenta,
                    DarkMagenta = ConsoleColor.DarkMagenta,
                    Gray = ConsoleColor.Gray,
                    DarkGray = ConsoleColor.DarkGray,
                    White = ConsoleColor.White
                },
                new ColorList // Black/White
                {
                    Black = ConsoleColor.Black,
                    Green = ConsoleColor.Black,
                    DarkGreen = ConsoleColor.Black,
                    Blue = ConsoleColor.Black,
                    DarkBlue = ConsoleColor.Black,
                    Red = ConsoleColor.Black,
                    DarkRed = ConsoleColor.Black,
                    Yellow = ConsoleColor.Black,
                    DarkYellow = ConsoleColor.Black,
                    Cyan = ConsoleColor.Black,
                    DarkCyan = ConsoleColor.Black,
                    Magenta = ConsoleColor.Black,
                    DarkMagenta = ConsoleColor.Black,
                    Gray = ConsoleColor.Black,
                    DarkGray = ConsoleColor.Black,
                    White = ConsoleColor.Black
                },
                new ColorList //4 Shades of Gray
                {
                    Black = ConsoleColor.Black,
                    Green = ConsoleColor.Gray,
                    DarkGreen = ConsoleColor.DarkGray,
                    Blue = ConsoleColor.Gray,
                    DarkBlue = ConsoleColor.DarkGray,
                    Red = ConsoleColor.Gray,
                    DarkRed = ConsoleColor.Black,
                    Yellow = ConsoleColor.Gray,
                    DarkYellow = ConsoleColor.Gray,
                    Cyan = ConsoleColor.Gray,
                    DarkCyan = ConsoleColor.White,
                    Magenta = ConsoleColor.Gray,
                    DarkMagenta = ConsoleColor.DarkGray,
                    Gray = ConsoleColor.Gray,
                    DarkGray = ConsoleColor.DarkGray,
                    White = ConsoleColor.White
                },
                new ColorList //4 Shades of Gray Inverted
                {
                    Black = ConsoleColor.White,
                    Green = ConsoleColor.DarkGray,
                    DarkGreen = ConsoleColor.Gray,
                    Blue = ConsoleColor.DarkGray,
                    DarkBlue = ConsoleColor.Gray,
                    Red = ConsoleColor.DarkGray,
                    DarkRed = ConsoleColor.White,
                    Yellow = ConsoleColor.DarkGray,
                    DarkYellow = ConsoleColor.DarkGray,
                    Cyan = ConsoleColor.DarkGray,
                    DarkCyan = ConsoleColor.Black,
                    Magenta = ConsoleColor.DarkGray,
                    DarkMagenta = ConsoleColor.Gray,
                    Gray = ConsoleColor.DarkGray,
                    DarkGray = ConsoleColor.Gray,
                    White = ConsoleColor.Black
                },
                new ColorList //Random
                {
                    Black = Color.RandomColor(),
                    Green = Color.RandomColor(),
                    DarkGreen = Color.RandomColor(),
                    Blue = Color.RandomColor(),
                    DarkBlue = Color.RandomColor(),
                    Red = Color.RandomColor(),
                    DarkRed = Color.RandomColor(),
                    Yellow = Color.RandomColor(),
                    DarkYellow = Color.RandomColor(),
                    Cyan = Color.RandomColor(),
                    DarkCyan = Color.RandomColor(),
                    Magenta = Color.RandomColor(),
                    DarkMagenta = Color.RandomColor(),
                    Gray = Color.RandomColor(),
                    DarkGray = Color.RandomColor(),
                    White = Color.RandomColor()
                }
            };
            ForeGroundList = new List<ColorList>
            {
                new ColorList //Normal
                {
                    Black = ConsoleColor.Black,
                    Green = ConsoleColor.Green,
                    DarkGreen = ConsoleColor.DarkGreen,
                    Blue = ConsoleColor.Blue,
                    DarkBlue = ConsoleColor.DarkBlue,
                    Red = ConsoleColor.Red,
                    DarkRed = ConsoleColor.DarkRed,
                    Yellow = ConsoleColor.Yellow,
                    DarkYellow = ConsoleColor.DarkYellow,
                    Cyan = ConsoleColor.Cyan,
                    DarkCyan = ConsoleColor.DarkCyan,
                    Magenta = ConsoleColor.Magenta,
                    DarkMagenta = ConsoleColor.DarkMagenta,
                    Gray = ConsoleColor.Gray,
                    DarkGray = ConsoleColor.DarkGray,
                    White = ConsoleColor.White
                },
                new ColorList // Black/White
                {
                    Black = ConsoleColor.White,
                    Green = ConsoleColor.White,
                    DarkGreen = ConsoleColor.White,
                    Blue = ConsoleColor.White,
                    DarkBlue = ConsoleColor.White,
                    Red = ConsoleColor.White,
                    DarkRed = ConsoleColor.White,
                    Yellow = ConsoleColor.White,
                    DarkYellow = ConsoleColor.White,
                    Cyan = ConsoleColor.White,
                    DarkCyan = ConsoleColor.White,
                    Magenta = ConsoleColor.White,
                    DarkMagenta = ConsoleColor.White,
                    Gray = ConsoleColor.White,
                    DarkGray = ConsoleColor.White,
                    White = ConsoleColor.White
                },
                new ColorList //4 Shades of Gray
                {
                    Black = ConsoleColor.Black,
                    Green = ConsoleColor.Gray,
                    DarkGreen = ConsoleColor.DarkGray,
                    Blue = ConsoleColor.Gray,
                    DarkBlue = ConsoleColor.DarkGray,
                    Red = ConsoleColor.Gray,
                    DarkRed = ConsoleColor.Black,
                    Yellow = ConsoleColor.Gray,
                    DarkYellow = ConsoleColor.DarkGray,
                    Cyan = ConsoleColor.Gray,
                    DarkCyan = ConsoleColor.DarkGray,
                    Magenta = ConsoleColor.Gray,
                    DarkMagenta = ConsoleColor.DarkGray,
                    Gray = ConsoleColor.Gray,
                    DarkGray = ConsoleColor.DarkGray,
                    White = ConsoleColor.White
                },
                new ColorList //4 Shades of Gray Inverted
                {
                    Black = ConsoleColor.White,
                    Green = ConsoleColor.DarkGray,
                    DarkGreen = ConsoleColor.Gray,
                    Blue = ConsoleColor.DarkGray,
                    DarkBlue = ConsoleColor.Gray,
                    Red = ConsoleColor.DarkGray,
                    DarkRed = ConsoleColor.White,
                    Yellow = ConsoleColor.DarkGray,
                    DarkYellow = ConsoleColor.Gray,
                    Cyan = ConsoleColor.DarkGray,
                    DarkCyan = ConsoleColor.Gray,
                    Magenta = ConsoleColor.DarkGray,
                    DarkMagenta = ConsoleColor.Gray,
                    Gray = ConsoleColor.DarkGray,
                    DarkGray = ConsoleColor.Gray,
                    White = ConsoleColor.Black
                },
                new ColorList //Random
                {
                    Black = Color.RandomColor(),
                    Green = Color.RandomColor(),
                    DarkGreen = Color.RandomColor(),
                    Blue = Color.RandomColor(),
                    DarkBlue = Color.RandomColor(),
                    Red = Color.RandomColor(),
                    DarkRed = Color.RandomColor(),
                    Yellow = Color.RandomColor(),
                    DarkYellow = Color.RandomColor(),
                    Cyan = Color.RandomColor(),
                    DarkCyan = Color.RandomColor(),
                    Magenta = Color.RandomColor(),
                    DarkMagenta = Color.RandomColor(),
                    Gray = Color.RandomColor(),
                    DarkGray = Color.RandomColor(),
                    White = Color.RandomColor()
                }
            };
        }

        public List<ColorList> ForeGroundList { get; set; }
        public List<ColorList> BackGroundList { get; set; }
    }

    internal class Color
    {
        /*
         * Class to convert Colors to the attribute format and vice-versa.
         * - by Oliver 
         */

        public static Array Kleuren = Enum.GetValues(typeof (ConsoleColor));

        public static ConsoleColor RandomColor()
        {
            var random = new Random();
            var randomgetal = random.Next(0, Kleuren.Length);
            Thread.Sleep(4);
            return (ConsoleColor) Kleuren.GetValue(randomgetal);
        }

        public static short ColorsToAttribute(ConsoleColor bg, ConsoleColor fg)
        {
            var bgValue = ColorToValue(bg);
            var fgValue = ColorToValue(fg);

            var attribute = Convert.ToInt16((bgValue)*16 + fgValue);

            return attribute;
        }

        public static ConsoleColor BackgroundFromAttribute(short attribute)
        {
            var bgvalue = Convert.ToInt16(attribute/16);
            return ValueToColor(bgvalue);
        }

        public static ConsoleColor ForegroundFromAttribute(short attribute)
        {
            var fgvalue = Convert.ToInt16(attribute%16);
            return ValueToColor(fgvalue);
        }

        public static short ColorToValue(ConsoleColor color)
        {
            short value = 0;
            switch (color)
            {
                case ConsoleColor.Black:
                    value = 0;
                    break;
                case ConsoleColor.DarkBlue:
                    value = 1;
                    break;
                case ConsoleColor.DarkGreen:
                    value = 2;
                    break;
                case ConsoleColor.DarkCyan:
                    value = 3;
                    break;
                case ConsoleColor.DarkRed:
                    value = 4;
                    break;
                case ConsoleColor.DarkMagenta:
                    value = 5;
                    break;
                case ConsoleColor.DarkYellow:
                    value = 6;
                    break;
                case ConsoleColor.Gray:
                    value = 7;
                    break;
                case ConsoleColor.DarkGray:
                    value = 8;
                    break;
                case ConsoleColor.Blue:
                    value = 9;
                    break;
                case ConsoleColor.Green:
                    value = 10;
                    break;
                case ConsoleColor.Cyan:
                    value = 11;
                    break;
                case ConsoleColor.Red:
                    value = 12;
                    break;
                case ConsoleColor.Magenta:
                    value = 13;
                    break;
                case ConsoleColor.Yellow:
                    value = 14;
                    break;
                case ConsoleColor.White:
                    value = 15;
                    break;
            }
            return value;
        }

        public static ConsoleColor ValueToColor(short value)
        {
            var color = ConsoleColor.Black;

            switch (value)
            {
                case 0:
                    color = ConsoleColor.Black;
                    break;
                case 1:
                    color = ConsoleColor.DarkBlue;
                    break;
                case 2:
                    color = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    color = ConsoleColor.DarkCyan;
                    break;
                case 4:
                    color = ConsoleColor.DarkRed;
                    break;
                case 5:
                    color = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    color = ConsoleColor.DarkYellow;
                    break;
                case 7:
                    color = ConsoleColor.Gray;
                    break;
                case 8:
                    color = ConsoleColor.DarkGray;
                    break;
                case 9:
                    color = ConsoleColor.Blue;
                    break;
                case 10:
                    color = ConsoleColor.Green;
                    break;
                case 11:
                    color = ConsoleColor.Cyan;
                    break;
                case 12:
                    color = ConsoleColor.Red;
                    break;
                case 13:
                    color = ConsoleColor.Magenta;
                    break;
                case 14:
                    color = ConsoleColor.Yellow;
                    break;
                case 15:
                    color = ConsoleColor.White;
                    break;
            }
            return color;
        }
    }
}