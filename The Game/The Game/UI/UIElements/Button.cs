using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Button : UIObject
    {
        private readonly ButtonTriggerHandler _buttonTriggerHandler;
        private object parameter;

        public Button(ButtonTrigger buttonTrigger, Position position, Image image, object parameter = null) : this(
            buttonTrigger, position, image,image,parameter)
        {
        }
        
        public Button(ButtonTrigger buttonTrigger, Position position, Image activeImage, Image inactiveImage, object parameter = null) : base(
            position, activeImage,inactiveImage)
        {
            _buttonTriggerHandler = new ButtonTriggerHandler();
            _buttonTriggerHandler.addTrigger(buttonTrigger);
            this.parameter = parameter;
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void HandleAction(Input action)
        {
            if (IsActive()) _buttonTriggerHandler.HandleAction(parameter);
        }
    }
}