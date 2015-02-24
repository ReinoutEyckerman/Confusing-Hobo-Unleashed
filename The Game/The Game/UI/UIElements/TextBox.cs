using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed.UI
{
    public class TextBox
    {
        public TextBox()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BoxBackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            BoxForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            SelectedColor = Painter.Instance.Paint(ConsoleColor.Blue);
            BoxColors = Painter.Instance.ColorsToAttribute(BoxBackgroundColor, BoxForegroundColor);
            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            SelectedColors = Painter.Instance.ColorsToAttribute(SelectedColor, ForegroundColor);
            Value = false;
            Xpos = Console.WindowWidth*2/5;
            BlockLength = Console.WindowWidth/5;
        }

        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public bool Value { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int XPosForCenteredMessage { get; set; }
        public int YPosForCenteredMessage { get; set; }
        public int BlockLength { get; set; }
        public int BlockHeight { get; set; }
        public string Message { get; set; }
        public ConsoleColor BoxBackgroundColor { get; set; }
        public ConsoleColor BoxForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor SelectedColor { get; set; }
        public short BorderColors { get; set; }
        public short BackgroundColors { get; set; }
        public short BoxColors { get; set; }
        public short SelectedColors { get; set; }
        public List<InsertBox> Box { get; set; }
        public List<int> VarChanger { get; set; }

        private void CenterMessage()
        {
            XPosForCenteredMessage = (Xpos + (BlockLength/2)) - Message.Length/2;
            YPosForCenteredMessage = (Ypos + (BlockHeight/3));
        }

        private void DrawBox(buffer outputbuffer)
        {
            for (var a = 0; a < Box.Count; a++)
            {
                if (Box[a].PosY == 0)
                    Box[a].PosY = Ypos + BlockHeight*2/3;
                for (var i = 0; i < Box[a].Length; i++)
                    outputbuffer.Draw(" ", Box[a].PosX, Box[a].PosY, BoxColors);

                outputbuffer.Draw(VarChanger[a].ToString(), Box[a].PosX, Ypos + BlockHeight*2/3, BoxColors);
            }
        }

        public void Insert()
        {
            for (var a = 0; a < Box.Count; a++)
            {
                var var = "";
                Console.CursorVisible = true;
                for (var x = 0; x < Box[a].Length; x++)
                {
                    int w;
                    Console.SetCursorPosition(Box[a].PosX + x, Box[a].PosY);
                    if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out w))
                        var += Convert.ToString(w);
                    else x--;
                }
                Console.CursorVisible = false;

                VarChanger[a] = Convert.ToInt32(var);
                bool input;
                do
                {
                    var Input = InputHandler.ControlInputHandling();
                    switch (Input)
                    {
                        case Buttons.A:
                            input = true;
                            break;
                        case Buttons.B:
                        case Buttons.Back:
                            a -= 1;
                            input = true;
                            break;
                        default:
                            input = false;
                            break;
                    }
                } while (!input);
            }
        }

        public void Recolor()
        {
            BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkGreen);
            ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BoxBackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            BoxForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
            BorderColor = Painter.Instance.Paint(ConsoleColor.Red);
            SelectedColor = Painter.Instance.Paint(ConsoleColor.Blue);
            SelectedColors = Painter.Instance.ColorsToAttribute(SelectedColor, ForegroundColor);
            BorderColors = Painter.Instance.ColorsToAttribute(BorderColor, ForegroundColor);
            BackgroundColors = Painter.Instance.ColorsToAttribute(BackgroundColor, ForegroundColor);
            BoxColors = Painter.Instance.ColorsToAttribute(BoxBackgroundColor, BoxForegroundColor);
        }

        public void Render(buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, Value ? SelectedColors : BackgroundColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);
            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
            DrawBox(outputbuffer);
        }

        public void RenderActive(buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, BorderColors, outputbuffer, true);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);

            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
            DrawBox(outputbuffer);
        }
    }
}