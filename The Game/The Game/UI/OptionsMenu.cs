using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class OptionsMenu
    {
        public OptionsMenu()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            BlockLength = Console.WindowWidth*5/7;
            BlockHeight = 10;
            Xpos = Console.WindowWidth/6;
            TextBoxList = new List<TextBox>();
            ButtonList = new List<Button>();
            Content = "";
            BiDirectional = false;
        }

        public OptionsMenu(string name, int xpos, int ypos, int xposmax, string content, bool state, int blocklength, int blockheight)
        {
            Name = name;
            Xpos = xpos;
            Ypos = ypos;
            XposMax = xposmax;
            Content = content;
            State = state;
            BlockLength = blocklength;
            BlockHeight = blockheight;
            BiDirectional = false;

            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);

            TextBoxList = new List<TextBox>();
            ButtonList = new List<Button>();
        }

        public bool BiDirectional { get; set; }
        public string Name { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int XposMax { get; set; }
        public string Content { get; set; }
        public bool State { get; set; }
        public int BlockLength { get; set; }
        public int BlockHeight { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public short BorderColors { get; set; }
        public short BackgroundColors { get; set; }
        public List<Button> ButtonList { get; set; }
        public List<TextBox> TextBoxList { get; set; }

        public void Recolor()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            foreach (var t in ButtonList)
            {
                t.Recolor();
            }
            foreach (var t in TextBoxList)
            {
                t.Recolor();
            }
        }

        private void WriteMessage(Buffer outputbuffer)
        {
            if (Content != "")
            {
                var tempx = XposMax - 5 - Console.WindowWidth/6;
                for (var x = Content.Length; x <= (tempx)*7; x++)
                {
                    Content += " ";
                }
                for (var i = 0; i < 7; i++)
                {
                    outputbuffer.Draw(Content.Substring(tempx*i, tempx), Console.WindowWidth/6 + 2, Ypos + i + 2, BackgroundColors);
                }
            }
        }

        public void Render(Buffer outputbuffer)
        {
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            Draw.Box(Xpos - Name.Length - 3, Ypos + BlockHeight/3, Xpos, Ypos + BlockHeight*2/3 + 1, BackgroundColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos - Name.Length - 2, Xpos, Ypos + BlockHeight/3 + 1, Ypos + BlockHeight/3 + 3, outputbuffer);
            outputbuffer.Draw(Name, Xpos - Name.Length - 1, Ypos + BlockHeight/2, BackgroundColors);

            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, BackgroundColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);
        }

        public void RenderActive(Buffer outputbuffer)
        {
            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            Draw.Box(Xpos - Name.Length - 3, Ypos + BlockHeight/3, Xpos, Ypos + BlockHeight*2/3 + 1, BorderColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos - Name.Length - 2, Xpos, Ypos + BlockHeight/3 + 1, Ypos + BlockHeight/3 + 3, outputbuffer);
            outputbuffer.Draw(Name, Xpos - Name.Length - 1, Ypos + BlockHeight/2, BackgroundColors);
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, BorderColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);
            WriteMessage(outputbuffer);
        }
    }
}