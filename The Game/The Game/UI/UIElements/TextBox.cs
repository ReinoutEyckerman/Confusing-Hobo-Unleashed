using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.UI.Windows;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed.UI
{
    public class TextBox : UIObject
    {
        private readonly ButtonTriggerHandler _buttonTriggerHandler;
        private CircularList<char> chars;

        public TextBox(int maxSize, Position position, Image image) : base(position, image)
        {
            initChars(maxSize);
        }

        public TextBox(int maxSize, Position position, Image activeImage, Image inactiveImage) : base(position,
            activeImage, inactiveImage)
        {
            initChars(maxSize);
        }

        private void initChars(int maxSize)
        {
            chars = new CircularList<char>();
            for (int i = 0; i < maxSize; i++)
            {
                chars.Add('a');
            }
        }

        private UIObject RenderText()
        {
            Text text = new Text(String.Concat(chars),new ColorPoint(BaseColor.Void, BaseColor.White),new Position(0,0) );
            TextBlock textBlock = new TextBlock(new Position(0, 0), text.toImage());
            Align.AlignUI(boundingBox, textBlock, 0, Alignment.Center);
            return textBlock;
        }


        public override void HandleAction(Input action)
        {
            if (action == Input.A)
            {
                isActive = !isActive;
            }
            else if (isActive)
            {
                switch (action)
                {
                    case Input.LEFT:
                        chars.decrement();
                        break;
                    case Input.RIGHT:
                        chars.increment();
                        break;
                    case Input.UP:
                        chars[chars.getIndex()]=(char)(chars.currentItem()+1);
                        break;
                    case Input.DOWN:
                        chars[chars.getIndex()]=(char)(chars.currentItem()-1);
                        break;
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
            RenderText().Draw();
        }
    }
}