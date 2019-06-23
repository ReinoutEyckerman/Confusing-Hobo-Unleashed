using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MainMenu : Menu
    {
        //private Menu menu;


        public MainMenu()
        {
            AbstractList verticalList = new VerticalListBuilder(5)
                .addUIObject(UIFactory.createDefaultRelativeButton("Start the Game!", startGame))
                .addUIObject(UIFactory.createDefaultRelativeButton("Versus Mode", versusScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Map Editor", mapEditorScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Configuration Screen", configScreen))
                .addUIObject(UIFactory.createDefaultRelativeButton("Credits", creditsScreen))
                .build();
            root = verticalList;
        }

        private void startGame(object parameter)
        {
            exit(Confusing_Hobo_Unleashed.GameState.Loading);
        }

        private void versusScreen(object parameter)
        {
            exit(Confusing_Hobo_Unleashed.GameState.Versus);
        }

        private void mapEditorScreen(object parameter)
        {
            exit(Confusing_Hobo_Unleashed.GameState.MapEditor);
        }

        private void configScreen(object parameter)
        {
            exit(Confusing_Hobo_Unleashed.GameState.Configuration);
        }

        private void creditsScreen(object parameter)
        {
            exit(Confusing_Hobo_Unleashed.GameState.Credits);
        }

        protected override void Run()
        {
            
        }

        protected override GameState defaultExitState()
        {
            return Confusing_Hobo_Unleashed.GameState.Exit;
        }
    }
}