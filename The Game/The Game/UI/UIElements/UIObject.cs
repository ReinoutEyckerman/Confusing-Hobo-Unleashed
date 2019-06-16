using System;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public abstract class UIObject : Drawable
    {
        private readonly Image activeImage;
        protected BoundingBox boundingBox;
        protected Image inactiveImage;
        protected bool isActive;

        protected UIObject(Position position, Image image) : this(position, image, image)
        {
        }

        protected UIObject(Position position, Image activeImage, Image inactiveImage)
        {
            this.activeImage = activeImage;
            this.inactiveImage = inactiveImage;

            var maxWidth = Math.Max(activeImage.getWidth(), inactiveImage.getWidth());
            var maxHeight = Math.Max(activeImage.getHeight(), inactiveImage.getHeight());
            boundingBox = new BoundingBox(position, maxWidth, maxHeight);
        }

        public virtual void Draw()
        {
            if (IsActive())
                activeImage.Draw();
            else
                inactiveImage.Draw();
        }

        public virtual void DrawRelative(Position relativeTo)
        {
            if (IsActive())
                activeImage.DrawRelative(relativeTo);
            else
                inactiveImage.DrawRelative(relativeTo);
        }

        public virtual bool IsActive()
        {
            return isActive;
        }

        public abstract void HandleAction(Input action);

        public BoundingBox getBoundingBox()
        {
            return boundingBox;
        }

        public void Reposition(Position position)
        {
            boundingBox.reposition(position);
        }
    }
}