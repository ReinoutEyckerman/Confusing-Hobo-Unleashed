using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed
{
    public class ColorScheme
    {
        private Array Colors = Enum.GetValues(typeof (BaseColor));
        private Dictionary<ColorSchemes, Dictionary<BaseColor, BaseColor>> BackgroundColourMapping { get; set; }
        private Dictionary<ColorSchemes, Dictionary<BaseColor, BaseColor>> ForegroundColourMapping { get; set; }

        private ColorSchemes currentScheme;

        public ColorScheme()
        {
            Refresh();
            this.currentScheme = ColorSchemes.Default;
        }

        public void setColorScheme(ColorSchemes colorSchemes)
        {
            this.currentScheme = colorSchemes;
        }

        public ColorPoint translateColor(ColorPoint color)
        {
            return new ColorPoint(BackgroundColourMapping[currentScheme][color.GetBackgroundColor()],ForegroundColourMapping[currentScheme][color.GetForegroundColor()]);
        }

        public void Refresh()
        {
            BackgroundColourMapping = new Dictionary<ColorSchemes, Dictionary<BaseColor, BaseColor>> 
            {
                {
                    ColorSchemes.Default, new Dictionary<BaseColor, BaseColor> //Normal
                    {
                        {BaseColor.Black, BaseColor.Black},
                        {BaseColor.Green, BaseColor.Green},
                        {BaseColor.DarkGreen, BaseColor.DarkGreen}, 
                        {BaseColor.Blue, BaseColor.Blue}, 
                        {BaseColor.DarkBlue, BaseColor.DarkBlue}, 
                        {BaseColor.Red, BaseColor.Red}, 
                        {BaseColor.DarkRed, BaseColor.DarkRed}, 
                        {BaseColor.Yellow, BaseColor.Yellow}, 
                        {BaseColor.DarkYellow, BaseColor.DarkYellow},
                        {BaseColor.Cyan, BaseColor.Cyan}, 
                        {BaseColor.DarkCyan, BaseColor.DarkCyan},
                        {BaseColor.Magenta, BaseColor.Magenta},
                        {BaseColor.DarkMagenta, BaseColor.DarkMagenta}, 
                        {BaseColor.Gray, BaseColor.Gray},
                        {BaseColor.DarkGray, BaseColor.DarkGray},
                        {BaseColor.White, BaseColor.White}
                    }},
                {
                    ColorSchemes.BlackWhite, new Dictionary<BaseColor, BaseColor> // Black/White
                    {
                        {BaseColor.Black, BaseColor.Black}, 
                        {BaseColor.Green, BaseColor.Black},
                        {BaseColor.DarkGreen, BaseColor.Black},
                        {BaseColor.Blue, BaseColor.Black},
                        {BaseColor.DarkBlue, BaseColor.Black},
                        {BaseColor.Red, BaseColor.Black}, 
                        {BaseColor.DarkRed, BaseColor.Black},
                        {BaseColor.Yellow, BaseColor.Black},
                        {BaseColor.DarkYellow, BaseColor.Black},
                        {BaseColor.Cyan, BaseColor.Black},
                        {BaseColor.DarkCyan, BaseColor.Black},
                        {BaseColor.Magenta, BaseColor.Black},
                        {BaseColor.DarkMagenta, BaseColor.Black},
                        {BaseColor.Gray, BaseColor.Black},
                        {BaseColor.DarkGray, BaseColor.Black},
                        {BaseColor.White, BaseColor.Black}
                    }},
                {
                    ColorSchemes.Gray, new Dictionary<BaseColor, BaseColor> //4 Shades of Gray
                    {
                        {BaseColor.Black, BaseColor.Black}, 
                        {BaseColor.Green, BaseColor.Gray},
                        {BaseColor.DarkGreen, BaseColor.DarkGray}, 
                        {BaseColor.Blue, BaseColor.Gray}, 
                        {BaseColor.DarkBlue, BaseColor.DarkGray},
                        {BaseColor.Red, BaseColor.Gray}, 
                        {BaseColor.DarkRed, BaseColor.Black}, 
                        {BaseColor.Yellow, BaseColor.Gray}, 
                        {BaseColor.DarkYellow, BaseColor.Gray},
                        {BaseColor.Cyan, BaseColor.Gray}, 
                        {BaseColor.DarkCyan, BaseColor.White}, 
                        {BaseColor.Magenta, BaseColor.Gray}, 
                        {BaseColor.DarkMagenta, BaseColor.DarkGray}, 
                        {BaseColor.Gray, BaseColor.Gray}, 
                        {BaseColor.DarkGray, BaseColor.DarkGray}, 
                        {BaseColor.White, BaseColor.White}
                    }},
                {
                    ColorSchemes.GrayInverted, new Dictionary<BaseColor, BaseColor> //4 Shades of Gray Inverted
                    {
                        {BaseColor.Black, BaseColor.White},
                        {BaseColor.Green, BaseColor.DarkGray}, 
                        {BaseColor.DarkGreen, BaseColor.Gray}, 
                        {BaseColor.Blue, BaseColor.DarkGray},
                        {BaseColor.DarkBlue, BaseColor.Gray}, 
                        {BaseColor.Red, BaseColor.DarkGray}, 
                        {BaseColor.DarkRed, BaseColor.White}, 
                        {BaseColor.Yellow, BaseColor.DarkGray}, 
                        {BaseColor.DarkYellow, BaseColor.DarkGray}, 
                        {BaseColor.Cyan, BaseColor.DarkGray}, 
                        {BaseColor.DarkCyan, BaseColor.Black}, 
                        {BaseColor.Magenta, BaseColor.DarkGray},
                        {BaseColor.DarkMagenta, BaseColor.Gray},
                        {BaseColor.Gray, BaseColor.DarkGray}, 
                        {BaseColor.DarkGray, BaseColor.Gray}, 
                        {BaseColor.White, BaseColor.Black}
                    }},
                {
                    ColorSchemes.Random, new Dictionary<BaseColor, BaseColor> //Random
                    {
                        {BaseColor.Black, RandomColor()},
                        {BaseColor.Green, RandomColor()}, 
                        {BaseColor.DarkGreen, RandomColor()}, 
                        {BaseColor.Blue, RandomColor()}, 
                        {BaseColor.DarkBlue, RandomColor()}, 
                        {BaseColor.Red, RandomColor()}, 
                        {BaseColor.DarkRed, RandomColor()}, 
                        {BaseColor.Yellow, RandomColor()}, 
                        {BaseColor.DarkYellow, RandomColor()}, 
                        {BaseColor.Cyan, RandomColor()}, 
                        {BaseColor.DarkCyan, RandomColor()}, 
                        {BaseColor.Magenta, RandomColor()},
                        {BaseColor.DarkMagenta, RandomColor()}, 
                        {BaseColor.Gray, RandomColor()}, 
                        {BaseColor.DarkGray, RandomColor()}, 
                        {BaseColor.White, RandomColor()}
                    }}};
            ForegroundColourMapping = new Dictionary<ColorSchemes, Dictionary<BaseColor, BaseColor>> 
            {
                {
                    ColorSchemes.Default, new Dictionary<BaseColor, BaseColor> //Normal
                    {
                        {BaseColor.Black, BaseColor.Black},
                        {BaseColor.Green, BaseColor.Green}, 
                        {BaseColor.DarkGreen, BaseColor.DarkGreen}, 
                        {BaseColor.Blue, BaseColor.Blue}, 
                        {BaseColor.DarkBlue, BaseColor.DarkBlue},
                        {BaseColor.Red, BaseColor.Red}, 
                        {BaseColor.DarkRed, BaseColor.DarkRed}, 
                        {BaseColor.Yellow, BaseColor.Yellow}, 
                        {BaseColor.DarkYellow, BaseColor.DarkYellow}, 
                        {BaseColor.Cyan, BaseColor.Cyan}, 
                        {BaseColor.DarkCyan, BaseColor.DarkCyan}, 
                        {BaseColor.Magenta, BaseColor.Magenta}, 
                        {BaseColor.DarkMagenta, BaseColor.DarkMagenta}, 
                        {BaseColor.Gray, BaseColor.Gray}, 
                        {BaseColor.DarkGray, BaseColor.DarkGray}, 
                        {BaseColor.White, BaseColor.White}
                    }},
                {
                    ColorSchemes.BlackWhite, new Dictionary<BaseColor, BaseColor> // Black/White
                    {
                        {BaseColor.Black, BaseColor.White}, 
                        {BaseColor.Green, BaseColor.White}, 
                        {BaseColor.DarkGreen, BaseColor.White}, 
                        {BaseColor.Blue, BaseColor.White}, 
                        {BaseColor.DarkBlue, BaseColor.White}, 
                        {BaseColor.Red, BaseColor.White}, 
                        {BaseColor.DarkRed, BaseColor.White}, 
                        {BaseColor.Yellow, BaseColor.White}, 
                        {BaseColor.DarkYellow, BaseColor.White}, 
                        {BaseColor.Cyan, BaseColor.White}, 
                        {BaseColor.DarkCyan, BaseColor.White}, 
                        {BaseColor.Magenta, BaseColor.White}, 
                        {BaseColor.DarkMagenta, BaseColor.White}, 
                        {BaseColor.Gray, BaseColor.White}, 
                        {BaseColor.DarkGray, BaseColor.White}, 
                        {BaseColor.White, BaseColor.White}
                    }},
                {
                    ColorSchemes.Gray, new Dictionary<BaseColor, BaseColor> //4 Shades of Gray
                    {
                        {BaseColor.Black, BaseColor.Black},
                        {BaseColor.Green, BaseColor.Gray}, 
                        {BaseColor.DarkGreen, BaseColor.DarkGray}, 
                        {BaseColor.Blue, BaseColor.Gray},
                        {BaseColor.DarkBlue, BaseColor.DarkGray}, 
                        {BaseColor.Red, BaseColor.Gray}, 
                        {BaseColor.DarkRed, BaseColor.Black}, 
                        {BaseColor.Yellow, BaseColor.Gray}, 
                        {BaseColor.DarkYellow, BaseColor.Gray}, 
                        {BaseColor.Cyan, BaseColor.Gray}, 
                        {BaseColor.DarkCyan, BaseColor.White}, 
                        {BaseColor.Magenta, BaseColor.Gray}, 
                        {BaseColor.DarkMagenta, BaseColor.DarkGray}, 
                        {BaseColor.Gray, BaseColor.Gray}, 
                        {BaseColor.DarkGray, BaseColor.DarkGray}, 
                        {BaseColor.White, BaseColor.White}
                    }},
                {
                    ColorSchemes.GrayInverted, new Dictionary<BaseColor, BaseColor> //4 Shades of Gray Inverted
                {
                    {BaseColor.Black, BaseColor.White}, 
                    {BaseColor.Green, BaseColor.DarkGray}, 
                    {BaseColor.DarkGreen, BaseColor.Gray}, 
                    {BaseColor.Blue, BaseColor.DarkGray}, 
                    {BaseColor.DarkBlue, BaseColor.Gray}, 
                    {BaseColor.Red, BaseColor.DarkGray}, 
                    {BaseColor.DarkRed, BaseColor.White}, 
                    {BaseColor.Yellow, BaseColor.DarkGray}, 
                    {BaseColor.DarkYellow, BaseColor.DarkGray}, 
                    {BaseColor.Cyan, BaseColor.DarkGray}, 
                    {BaseColor.DarkCyan, BaseColor.Black}, 
                    {BaseColor.Magenta, BaseColor.DarkGray}, 
                    {BaseColor.DarkMagenta, BaseColor.Gray}, 
                    {BaseColor.Gray, BaseColor.DarkGray}, 
                    {BaseColor.DarkGray, BaseColor.Gray}, 
                    {BaseColor.White, BaseColor.Black}
                }},
                {
                    ColorSchemes.Random, new Dictionary<BaseColor, BaseColor> //Random
                {
                    {BaseColor.Black, RandomColor()}, 
                    {BaseColor.Green, RandomColor()}, 
                    {BaseColor.DarkGreen, RandomColor()}, 
                    {BaseColor.Blue, RandomColor()}, 
                    {BaseColor.DarkBlue, RandomColor()}, 
                    {BaseColor.Red, RandomColor()}, 
                    {BaseColor.DarkRed, RandomColor()}, 
                    {BaseColor.Yellow, RandomColor()}, 
                    {BaseColor.DarkYellow, RandomColor()}, 
                    {BaseColor.Cyan, RandomColor()}, 
                    {BaseColor.DarkCyan, RandomColor()}, 
                    {BaseColor.Magenta, RandomColor()}, 
                    {BaseColor.DarkMagenta, RandomColor()}, 
                    {BaseColor.Gray, RandomColor()}, 
                    {BaseColor.DarkGray, RandomColor()}, 
                    {BaseColor.White, RandomColor()}
                }}};
        }

        private BaseColor RandomColor()
        {
            var color = new Random().Next(0, Colors.Length);
            Thread.Sleep(4);
            return (BaseColor) Colors.GetValue(color);
        }
    }
}