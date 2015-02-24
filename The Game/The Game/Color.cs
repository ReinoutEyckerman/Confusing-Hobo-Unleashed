using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;

namespace Confusing_Hobo_Unleashed
{
   
    public class ColorSchemes
    {
        public void Refresh()
        {
            BackGroundList = new Dictionary<ColorScheme,Dictionary<ConsoleColor, ConsoleColor>>
            {
                {ColorScheme.Normal, new Dictionary<ConsoleColor, ConsoleColor> //Normal
                {
                    {ConsoleColor.Black , ConsoleColor.Black},
                    {ConsoleColor.Green , ConsoleColor.Green},
                    {ConsoleColor.DarkGreen , ConsoleColor.DarkGreen},
                    {ConsoleColor.Blue , ConsoleColor.Blue},
                    {ConsoleColor.DarkBlue , ConsoleColor.DarkBlue},
                    {ConsoleColor.Red , ConsoleColor.Red},
                    {ConsoleColor.DarkRed , ConsoleColor.DarkRed},
                    {ConsoleColor.Yellow , ConsoleColor.Yellow},
                    {ConsoleColor.DarkYellow , ConsoleColor.DarkYellow},
                    {ConsoleColor.Cyan, ConsoleColor.Cyan},
                    {ConsoleColor.DarkCyan , ConsoleColor.DarkCyan},
                    {ConsoleColor.Magenta , ConsoleColor.Magenta},
                    {ConsoleColor.DarkMagenta , ConsoleColor.DarkMagenta},
                    {ConsoleColor.Gray , ConsoleColor.Gray},
                    {ConsoleColor.DarkGray , ConsoleColor.DarkGray},
                    {ConsoleColor.White , ConsoleColor.White}
                }},
                {ColorScheme.BlackWhite, new Dictionary<ConsoleColor, ConsoleColor>  // Black/White
                {
                    {ConsoleColor.Black , ConsoleColor.Black},
                    {ConsoleColor.Green , ConsoleColor.Black},
                    {ConsoleColor.DarkGreen , ConsoleColor.Black},
                    {ConsoleColor.Blue , ConsoleColor.Black},
                    {ConsoleColor.DarkBlue , ConsoleColor.Black},
                    {ConsoleColor.Red , ConsoleColor.Black},
                    {ConsoleColor.DarkRed , ConsoleColor.Black},
                    {ConsoleColor.Yellow , ConsoleColor.Black},
                    {ConsoleColor.DarkYellow , ConsoleColor.Black},
                    {ConsoleColor.Cyan, ConsoleColor.Black},
                    {ConsoleColor.DarkCyan , ConsoleColor.Black},
                    {ConsoleColor.Magenta , ConsoleColor.Black},
                    {ConsoleColor.DarkMagenta , ConsoleColor.Black},
                    {ConsoleColor.Gray , ConsoleColor.Black},
                    {ConsoleColor.DarkGray , ConsoleColor.Black},
                    {ConsoleColor.White , ConsoleColor.Black}
                }},
                {ColorScheme.Gray, new Dictionary<ConsoleColor, ConsoleColor>  //4 Shades of Gray
                {
                    {ConsoleColor.Black , ConsoleColor.Black},
                    {ConsoleColor.Green , ConsoleColor.Gray},
                    {ConsoleColor.DarkGreen , ConsoleColor.DarkGray},
                    {ConsoleColor.Blue , ConsoleColor.Gray},
                    {ConsoleColor.DarkBlue , ConsoleColor.DarkGray},
                    {ConsoleColor.Red , ConsoleColor.Gray},
                    {ConsoleColor.DarkRed , ConsoleColor.Black},
                    {ConsoleColor.Yellow , ConsoleColor.Gray},
                    {ConsoleColor.DarkYellow , ConsoleColor.Gray},
                    {ConsoleColor.Cyan, ConsoleColor.Gray},
                    {ConsoleColor.DarkCyan , ConsoleColor.White},
                    {ConsoleColor.Magenta , ConsoleColor.Gray},
                    {ConsoleColor.DarkMagenta , ConsoleColor.DarkGray},
                    {ConsoleColor.Gray , ConsoleColor.Gray},
                    {ConsoleColor.DarkGray , ConsoleColor.DarkGray},
                    {ConsoleColor.White , ConsoleColor.White}
                }},
                {ColorScheme.GrayInverted, new Dictionary<ConsoleColor, ConsoleColor> //4 Shades of Gray Inverted
                {
                    {ConsoleColor.Black , ConsoleColor.White},
                    {ConsoleColor.Green , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkGreen , ConsoleColor.Gray},
                    {ConsoleColor.Blue , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkBlue , ConsoleColor.Gray},
                    {ConsoleColor.Red , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkRed , ConsoleColor.White},
                    {ConsoleColor.Yellow , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkYellow , ConsoleColor.DarkGray},
                    {ConsoleColor.Cyan, ConsoleColor.DarkGray},
                    {ConsoleColor.DarkCyan , ConsoleColor.Black},
                    {ConsoleColor.Magenta , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkMagenta , ConsoleColor.Gray},
                    {ConsoleColor.Gray , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkGray , ConsoleColor.Gray},
                    {ConsoleColor.White , ConsoleColor.Black}
                }},
                {ColorScheme.Random, new Dictionary<ConsoleColor, ConsoleColor>  //Random
                {
                    {ConsoleColor.Black , Color.RandomColor()},
                    {ConsoleColor.Green , Color.RandomColor()},
                    {ConsoleColor.DarkGreen , Color.RandomColor()},
                    {ConsoleColor.Blue , Color.RandomColor()},
                    {ConsoleColor.DarkBlue , Color.RandomColor()},
                    {ConsoleColor.Red , Color.RandomColor()},
                    {ConsoleColor.DarkRed , Color.RandomColor()},
                    {ConsoleColor.Yellow , Color.RandomColor()},
                    {ConsoleColor.DarkYellow , Color.RandomColor()},
                    {ConsoleColor.Cyan, Color.RandomColor()},
                    {ConsoleColor.DarkCyan , Color.RandomColor()},
                    {ConsoleColor.Magenta , Color.RandomColor()},
                    {ConsoleColor.DarkMagenta , Color.RandomColor()},
                    {ConsoleColor.Gray ,Color.RandomColor()},
                    {ConsoleColor.DarkGray , Color.RandomColor()},
                    {ConsoleColor.White , Color.RandomColor()}
                }}};
            ForeGroundList = new Dictionary<ColorScheme, Dictionary<ConsoleColor, ConsoleColor>>
            {
                {ColorScheme.Normal,new Dictionary<ConsoleColor, ConsoleColor> //Normal
                {
                   {ConsoleColor.Black , ConsoleColor.Black},
                    {ConsoleColor.Green , ConsoleColor.Green},
                    {ConsoleColor.DarkGreen , ConsoleColor.DarkGreen},
                    {ConsoleColor.Blue , ConsoleColor.Blue},
                    {ConsoleColor.DarkBlue , ConsoleColor.DarkBlue},
                    {ConsoleColor.Red , ConsoleColor.Red},
                    {ConsoleColor.DarkRed , ConsoleColor.DarkRed},
                    {ConsoleColor.Yellow , ConsoleColor.Yellow},
                    {ConsoleColor.DarkYellow , ConsoleColor.DarkYellow},
                    {ConsoleColor.Cyan, ConsoleColor.Cyan},
                    {ConsoleColor.DarkCyan , ConsoleColor.DarkCyan},
                    {ConsoleColor.Magenta , ConsoleColor.Magenta},
                    {ConsoleColor.DarkMagenta , ConsoleColor.DarkMagenta},
                    {ConsoleColor.Gray , ConsoleColor.Gray},
                    {ConsoleColor.DarkGray , ConsoleColor.DarkGray},
                    {ConsoleColor.White , ConsoleColor.White}
                }},
                {ColorScheme.BlackWhite,new Dictionary<ConsoleColor, ConsoleColor> // Black/White
                {
                     {ConsoleColor.Black , ConsoleColor.White},
                    {ConsoleColor.Green , ConsoleColor.White},
                    {ConsoleColor.DarkGreen , ConsoleColor.White},
                    {ConsoleColor.Blue , ConsoleColor.White},
                    {ConsoleColor.DarkBlue , ConsoleColor.White},
                    {ConsoleColor.Red , ConsoleColor.White},
                    {ConsoleColor.DarkRed , ConsoleColor.White},
                    {ConsoleColor.Yellow , ConsoleColor.White},
                    {ConsoleColor.DarkYellow , ConsoleColor.White},
                    {ConsoleColor.Cyan, ConsoleColor.White},
                    {ConsoleColor.DarkCyan , ConsoleColor.White},
                    {ConsoleColor.Magenta , ConsoleColor.White},
                    {ConsoleColor.DarkMagenta , ConsoleColor.White},
                    {ConsoleColor.Gray , ConsoleColor.White},
                    {ConsoleColor.DarkGray , ConsoleColor.White},
                    {ConsoleColor.White , ConsoleColor.White}
                }},
                {ColorScheme.Gray,new Dictionary<ConsoleColor, ConsoleColor> //4 Shades of Gray
                {
                 {ConsoleColor.Black , ConsoleColor.Black},
                    {ConsoleColor.Green , ConsoleColor.Gray},
                    {ConsoleColor.DarkGreen , ConsoleColor.DarkGray},
                    {ConsoleColor.Blue , ConsoleColor.Gray},
                    {ConsoleColor.DarkBlue , ConsoleColor.DarkGray},
                    {ConsoleColor.Red , ConsoleColor.Gray},
                    {ConsoleColor.DarkRed , ConsoleColor.Black},
                    {ConsoleColor.Yellow , ConsoleColor.Gray},
                    {ConsoleColor.DarkYellow , ConsoleColor.Gray},
                    {ConsoleColor.Cyan, ConsoleColor.Gray},
                    {ConsoleColor.DarkCyan , ConsoleColor.White},
                    {ConsoleColor.Magenta , ConsoleColor.Gray},
                    {ConsoleColor.DarkMagenta , ConsoleColor.DarkGray},
                    {ConsoleColor.Gray , ConsoleColor.Gray},
                    {ConsoleColor.DarkGray , ConsoleColor.DarkGray},
                    {ConsoleColor.White , ConsoleColor.White}
                }},
                {ColorScheme.GrayInverted,new Dictionary<ConsoleColor, ConsoleColor> //4 Shades of Gray Inverted
                {
                   {ConsoleColor.Black , ConsoleColor.White},
                    {ConsoleColor.Green , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkGreen , ConsoleColor.Gray},
                    {ConsoleColor.Blue , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkBlue , ConsoleColor.Gray},
                    {ConsoleColor.Red , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkRed , ConsoleColor.White},
                    {ConsoleColor.Yellow , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkYellow , ConsoleColor.DarkGray},
                    {ConsoleColor.Cyan, ConsoleColor.DarkGray},
                    {ConsoleColor.DarkCyan , ConsoleColor.Black},
                    {ConsoleColor.Magenta , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkMagenta , ConsoleColor.Gray},
                    {ConsoleColor.Gray , ConsoleColor.DarkGray},
                    {ConsoleColor.DarkGray , ConsoleColor.Gray},
                    {ConsoleColor.White , ConsoleColor.Black}
                }},
                {ColorScheme.Random,new Dictionary<ConsoleColor, ConsoleColor> //Random
                {
                     {ConsoleColor.Black , Color.RandomColor()},
                    {ConsoleColor.Green , Color.RandomColor()},
                    {ConsoleColor.DarkGreen , Color.RandomColor()},
                    {ConsoleColor.Blue , Color.RandomColor()},
                    {ConsoleColor.DarkBlue , Color.RandomColor()},
                    {ConsoleColor.Red , Color.RandomColor()},
                    {ConsoleColor.DarkRed , Color.RandomColor()},
                    {ConsoleColor.Yellow , Color.RandomColor()},
                    {ConsoleColor.DarkYellow , Color.RandomColor()},
                    {ConsoleColor.Cyan, Color.RandomColor()},
                    {ConsoleColor.DarkCyan , Color.RandomColor()},
                    {ConsoleColor.Magenta , Color.RandomColor()},
                    {ConsoleColor.DarkMagenta , Color.RandomColor()},
                    {ConsoleColor.Gray ,Color.RandomColor()},
                    {ConsoleColor.DarkGray , Color.RandomColor()},
                    {ConsoleColor.White , Color.RandomColor()}
                }}
            };
        }

        public Dictionary<ColorScheme, Dictionary<ConsoleColor, ConsoleColor>> ForeGroundList { get; set; }
        public Dictionary<ColorScheme, Dictionary<ConsoleColor, ConsoleColor>> BackGroundList { get; set; }
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