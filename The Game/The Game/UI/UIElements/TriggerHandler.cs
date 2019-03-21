using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public delegate void TriggerEventHandler();
    public class TriggerHandler
    {
        private event TriggerEventHandler triggerEvent;

        public void setTrigger(TriggerEventHandler triggerEventHandler)
        {
            this.triggerEvent = triggerEventHandler;
        }

        public void addTrigger(TriggerEventHandler triggerEventHandler)
        {
            this.triggerEvent += triggerEventHandler;
        }

        public void removeTrigger(TriggerEventHandler triggerEventHandler)
        {
            this.triggerEvent -= triggerEventHandler;
        }

        public void clearTriggers()
        {
            this.triggerEvent = null;
        }

        public void HandleAction(Input action)
        {
            triggerEvent?.Invoke();
        }
    }
}