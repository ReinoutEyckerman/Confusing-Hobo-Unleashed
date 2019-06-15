using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Button : UIObject
    {
        private readonly ButtonTriggerHandler _buttonTriggerHandler;

        public Button(ButtonTrigger buttonTrigger, Position position, Image image) : base(position, image)
        {
            _buttonTriggerHandler = new ButtonTriggerHandler();
            _buttonTriggerHandler.addTrigger(buttonTrigger);
        }

        private bool Value { get; set; }
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
            if (IsActive()) _buttonTriggerHandler.HandleAction(action);
        }
    }
}