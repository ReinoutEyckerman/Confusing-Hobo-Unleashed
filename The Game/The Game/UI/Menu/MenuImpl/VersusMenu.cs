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
            var versusMenuList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Single Player", singlePlayer))
                .addUIObject(UIFactory.createDefaultRelativeButton("Split-Screen", splitScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("LAN", lan))
                .addUIObject(UIFactory.createDefaultRelativeButton("New LAN Server", lanServer))
                .buildVertical();

            root = versusMenuList;
        }

        private void singlePlayer()
        {
            //  MapSelectionMenu//TODO
            throw new NotImplementedException();
        }

        private void splitScreen()
        {
            //  MapSelectionMenu//TODO
            throw new NotImplementedException();
        }

        private void lan()
        {
            throw new NotImplementedException();
            Client.Start(); //TODO
        }

        private void lanServer()
        {
            throw new NotImplementedException();
            Server.Start(); //TODO
        }
    }
}