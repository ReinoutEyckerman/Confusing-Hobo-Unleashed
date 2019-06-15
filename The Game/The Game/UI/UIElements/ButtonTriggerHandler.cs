using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public delegate void ButtonTrigger(object parameter);

    public class ButtonTriggerHandler
    {
        private event ButtonTrigger triggerEvent;

        public void setTrigger(ButtonTrigger buttonTrigger)
        {
            triggerEvent = buttonTrigger;
        }

        public void addTrigger(ButtonTrigger buttonTrigger)
        {
            triggerEvent += buttonTrigger;
        }

        public void removeTrigger(ButtonTrigger buttonTrigger)
        {
            triggerEvent -= buttonTrigger;
        }

        public void clearTriggers()
        {
            triggerEvent = null;
        }

        public void HandleAction(object param)
        {
            triggerEvent?.Invoke(param);
        }
    }
}