using Confusing_Hobo_Unleashed.Graphics.Image;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class ButtonBuilder : UIObjectBuilder //TODO this is too much code, simplify this!
    {
        private object parameter;
        private ButtonTrigger TriggerHandler;

        public ButtonBuilder() : base()
        {
            this.parameter = null;
            this.TriggerHandler = null;
        }

        public ButtonBuilder setTrigger(ButtonTrigger triggerHandler)
        {
            this.TriggerHandler = triggerHandler;
            return this;
        }

        public ButtonBuilder setTriggerParameter(object parameter)
        {
            this.parameter = parameter;
            return this;
        }

        public ButtonBuilder setImage(Image image)
        {
            base.setImage(image);
            return this;
        }

        public UIObjectBuilder setActiveImage(Image activeImage)
        {
            base.setActiveImage(activeImage);
            return this;
        }

        public UIObjectBuilder setInactiveImage(Image inactiveImage)
        {
            base.setInactiveImage(inactiveImage);
            return this;
        }

        public UIObjectBuilder setPosition(Position position)
        {
            base.setPosition(position);
            return this;
        }

        public override UIObject build()
        {
            if (activeImage != null && inactiveImage != null)
            {
                return new Button(TriggerHandler, position, activeImage, inactiveImage, parameter);
            }
            else if (activeImage == null)
            {
                return new Button(TriggerHandler, position, inactiveImage, parameter);
            }
            else
            {
                return new Button(TriggerHandler, position, activeImage, parameter);
            }
        }
    }
}