using Confusing_Hobo_Unleashed.Graphics.Image;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public abstract class UIObjectBuilder
    {
        protected Image activeImage;
        protected Image inactiveImage;
        protected Position position;

        public UIObjectBuilder()
        {
            activeImage = null;
            inactiveImage = null;
            position = new Position(0,0);
        }

        protected virtual UIObjectBuilder setImage(Image image)
        {
            this.activeImage = image;
            this.inactiveImage = image;
            return this;
        }

        protected virtual UIObjectBuilder setActiveImage(Image activeImage)
        {
            this.activeImage = activeImage;
            return this;
        }

        protected virtual UIObjectBuilder setInactiveImage(Image inactiveImage)
        {
            this.inactiveImage = inactiveImage;
            return this;
        }

        protected virtual UIObjectBuilder setPosition(Position position)
        {
            this.position = position;
            return this;
        }

        public abstract UIObject build();
    }
}