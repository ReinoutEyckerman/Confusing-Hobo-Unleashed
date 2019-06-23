using System;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class VersusMenu : Menu
    {
        private bool versus = true;

        public VersusMenu()
        {
            AbstractList versusMenuList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Single Player", singlePlayer))
                .addUIObject(UIFactory.createDefaultRelativeButton("Split-Screen", splitScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("LAN", lan))
                .addUIObject(UIFactory.createDefaultRelativeButton("New LAN Server", lanServer))
                .build();

            root = versusMenuList;
        }

        private void singlePlayer(object parameter)
        {
            //  MapSelectionMenu//TODO
            throw new NotImplementedException();
        }

        private void splitScreen(object parameter)
        {
            //  MapSelectionMenu//TODO
            throw new NotImplementedException();
        }

        private void lan(object parameter)
        {
            throw new NotImplementedException();
            //Client.Start(); //TODO
        }

        private void lanServer(object parameter)
        {
            throw new NotImplementedException();
            //Server.Start(); //TODO
        }

        protected override void Run()
        {
        }

        protected override GameState defaultExitState()
        {
            return Confusing_Hobo_Unleashed.GameState.StartScreen;
        }
    }
}