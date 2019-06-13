using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MainMenu : Menu
    {
        //private Menu menu;


        public MainMenu()
        {
            var verticalList = new AbstractListBuilder(5)
                .addUIObject(UIFactory.createDefaultRelativeButton("Start the Game!", startGame))
                .addUIObject(UIFactory.createDefaultRelativeButton("Versus Mode", versusScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Map Editor", mapEditorScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Configuration Screen", configScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Credits", creditsScreen))
                .buildVertical();
            root = verticalList;
        }

        private void startGame()
        {
            throw new NotImplementedException();
        }

        private void versusScreen()
        {
            throw new NotImplementedException();
        }

        private void mapEditorScreen()
        {
            throw new NotImplementedException();
        }

        private void configScreen()
        {
            throw new NotImplementedException();
        }

        private void creditsScreen()
        {
            throw new NotImplementedException();
        }
    }
}