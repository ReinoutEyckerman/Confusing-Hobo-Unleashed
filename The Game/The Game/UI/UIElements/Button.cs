using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    internal class Button
    {
        public Button()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            SelectedColor = Painter.Instance.Paint(ConsoleColor.Blue);
            SelectedColors = Painter.Instance.ColorsToAttribute(SelectedColor, ForegroundColor);

            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            Value = false;
            Xpos = Console.WindowWidth*2/5;
            BlockLength = Console.WindowWidth/5;
        }

        public Button(int xpos, int ypos, string message, bool value = false, int blocklength = 20, int blockheight = 5)
        {
            Xpos = xpos;
            Ypos = ypos;
            BlockLength = blocklength;
            BlockHeight = blockheight;
            Message = message;
            Value = value;

            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);

            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            CenterMessage();
        }

        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int BlockLength { get; set; }
        public int BlockHeight { get; set; }
        public string Message { get; set; }
        public int XPosForCenteredMessage { get; set; }
        public int YPosForCenteredMessage { get; set; }
        public bool Value { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor SelectedColor { get; set; }
        public short BorderColors { get; set; }
        public short BackgroundColors { get; set; }
        public short SelectedColors { get; set; }
        public List<int> VarChanger { get; set; }

        private void CenterMessage()
        {
            XPosForCenteredMessage = (Xpos + (BlockLength/2)) - Message.Length/2;
            YPosForCenteredMessage = (Ypos + (BlockHeight/2));
        }

        public void Recolor()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            SelectedColor = Painter.Instance.Paint(ConsoleColor.Blue);
            SelectedColors = Painter.Instance.ColorsToAttribute(SelectedColor, ForegroundColor);
            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
        }

        public void ChangeValue()
        {
            Value = !Value;
        }

        public void Render(buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, Value ? SelectedColors : BackgroundColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);
            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
        }

        public void RenderActive(buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, BorderColors, outputbuffer, true);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);

            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
        }
    }
}