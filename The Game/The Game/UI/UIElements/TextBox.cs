using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed.UI
{
    //TODO: Make this a simplistic textbox with a set amount of characters and arrows pointing up and downward for char selection
    public class TextBox:UIObject
    {
        
        private Shape inactiveShape;
        private Shape activeShape;
        private Window _window; //todo
        
        protected TextBox( Shape activeShape, Shape inactiveShape, string text): base(activeShape,inactiveShape)
        {
            this.activeShape = activeShape;
            this.inactiveShape = inactiveShape;
            this.text = new CenteredText(text, shape.getPosition(), shape);
        }

        public string Message { get; set; }
        public List<InsertBox> Box { get; set; }
        public List<int> VarChanger { get; set; }

        private void CenterMessage()
        {
            XPosForCenteredMessage = (Xpos + (BlockLength/2)) - Message.Length/2;
            YPosForCenteredMessage = (Ypos + (BlockHeight/3));
        }

        private void DrawBox(Buffer outputbuffer)
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
        public void Render(Buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, Value ? SelectedColors : BackgroundColors, outputbuffer);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);
            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
            DrawBox(outputbuffer);
        }

        public void RenderActive(Buffer outputbuffer)
        {
            if (XPosForCenteredMessage == 0)
                CenterMessage();
            Draw.Box(Xpos, Ypos, Xpos + BlockLength, Ypos + BlockHeight, BorderColors, outputbuffer, true);
            Draw.FillRectangle(BackgroundColors, Xpos + 1, Xpos + BlockLength - 1, Ypos + 1, Ypos + BlockHeight - 1, outputbuffer);

            outputbuffer.Draw(Message, XPosForCenteredMessage, YPosForCenteredMessage, BackgroundColors);
            DrawBox(outputbuffer);
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void HandleAction(Input action)
        {
            throw new NotImplementedException();
        }

        public override void HandleAction()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            if (IsActive())
            {
                activeShape.Draw();
            }
            else
            {
                inactiveShape.Draw();
            }
        }
    }
}