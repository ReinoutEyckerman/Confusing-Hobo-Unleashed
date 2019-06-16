using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Extensions;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class LoadBar : UIObject
    {
        private Pixel loadColor;
        private int progress;
        private int previousProgress;
        
        public LoadBar( Pixel loadColor, Position position, Image image) : base(position, image)
        {
            this.loadColor = loadColor;
        }

        public LoadBar(Position position, Pixel loadColor, Image activeImage, Image inactiveImage) : base(position, activeImage, inactiveImage)
        {
            this.loadColor = loadColor;
        }

        public void setProgress(int progress)
        {
            this.progress = progress.Clamp(0, 100);
        }

        public override void HandleAction(Input action)
        {
            throw new System.NotImplementedException();
        }

        private void regenerateImage()
        {
            if (progress != previousProgress)
            {
                previousProgress = progress;
                throw new NotImplementedException();
                //TODO recreate image
            }
        }

        public override void Draw()
        {
            regenerateImage();
            base.Draw();
        }

        public override void DrawRelative(Position relativePosition)
        {
            regenerateImage();
            base.DrawRelative(relativePosition);
        }

    }
}