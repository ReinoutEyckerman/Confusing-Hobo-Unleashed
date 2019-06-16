using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class AbstractBanner : Drawable //TODO Large letter generator?
    {
        private Image banner;

        public AbstractBanner()
        {
        }

        protected void Initialize(List<String> stringlist, Position position, ColorPoint colorPoint)
        {
            foreach (string s in stringlist)
            {
                Text text = new Text(s, colorPoint, position);
                position.setX(position.x + 1);
                if (this.banner == null)
                {
                    this.banner = text.toImage();
                }
                else
                {
                    this.banner.addTopLayer(text);
                }
            }
        }
        

        public void Draw()
        {
            ValidateBanner();
            this.banner.Draw();
        }

        public void DrawRelative(Position relativeTo)
        {
            ValidateBanner();
            this.banner.DrawRelative(relativeTo);
        }

        public void ValidateBanner()
        {
            if (this.banner == null)
            {
                throw new NotImplementedException();
                throw new Exception();//TODO 
            }
        }
    }
}