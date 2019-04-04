using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public abstract class UIObject : Drawable
    {
        protected bool isActive;
        private Image activeImage;
        protected Image inactiveImage;


        protected UIObject(Image image) : this(image, image)
        {
        }


        protected UIObject(Image activeImage, Image inactiveImage)
        {
            this.activeImage = activeImage;
            this.inactiveImage = inactiveImage;
        }

        public virtual bool IsActive()
        {
            return this.isActive;
        }

        public virtual void Draw()
        {
            if (IsActive())
            {
                this.activeImage.Draw();
            }
            else
            {
                inactiveImage.Draw();
            }
        }

        public abstract void HandleAction(Input action);
    }
}