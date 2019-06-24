using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class LoadingScreen : Menu
    {
        /*
        public LoadingScreen()
        {
            AbstractList verticalList = new VerticalListBuilder(5)
                .addUIObject(new LoadBar())
                .build();
            Fire leftFire = new Fire();
            Fire rightFire = new Fire();
            root = new HorizontalListBuilder(5)
                .addUIObject(leftFire)
                .addUIObject(verticalList)
                .addUIObject(rightFire)
                .build();
        }

        public override void run()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            Draw.Box(Console.WindowWidth * 2 / 5, Console.WindowHeight * 5 / 6, Console.WindowWidth * 3 / 5,
                Console.WindowHeight * 5 / 6 + 4, Painter.Instance.Paint(ConsoleColor.Blue));
            foreach (var item in LoadMessages)
            {
                Loadbar(item.Key);
                item.Value.Invoke();
            }

            barCount = 1;
            //  StartMenu.Fire.Abort();
            MapControls.DrawMap();
        }

        private static readonly Dictionary<string, TempDelegate> LoadMessages = new Dictionary<string, TempDelegate>
        {
            {"Clearing Variables...", MapGeneration.Clearvars},
            {"Map Generation Started...", MapGeneration.GenerateCorridors},
            {"Advanced Map Generation Initiated...", MapFixVars},
            {"Defining Variables...", Definevars}
        };
        */
        protected override void Run()
        {
        }

        protected override GameState defaultExitState()
        {
            return Confusing_Hobo_Unleashed.GameState.StartScreen;
        }
    }
}