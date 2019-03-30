using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Button : UIObject
    {
        private TriggerHandler triggerHandler;

        public Button(TriggerEventHandler triggerEventHandler,Shape shape):base(shape)
        {
            this.triggerHandler = new TriggerHandler();
            triggerHandler.addTrigger(triggerEventHandler);
        }

        public bool Value { get; set; }
        public List<int> VarChanger { get; set; }

        public void ChangeValue()
        {
            Value = !Value;
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void HandleAction(Input action)
        {
            if (IsActive())
            {
                triggerHandler.HandleAction(action);
            }
        }
    }
}