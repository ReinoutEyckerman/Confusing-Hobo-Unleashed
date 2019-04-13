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
        protected BoundingBox boundingBox;
        private Image activeImage;
        protected Image inactiveImage;


        protected UIObject(Position position, Image image) : this(position, image, image)
        {
        }


        protected UIObject(Position position, Image activeImage, Image inactiveImage)
        {
            this.activeImage = activeImage;
            this.inactiveImage = inactiveImage;

            int maxWidth = Math.Max(activeImage.getWidth(), inactiveImage.getWidth());
            int maxHeight = Math.Max(activeImage.getHeight(), inactiveImage.getHeight());
            this.boundingBox=new BoundingBox(position, maxWidth,maxHeight );
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

        public BoundingBox getBoundingBox()
        {
            return this.boundingBox;
        }
    }
}