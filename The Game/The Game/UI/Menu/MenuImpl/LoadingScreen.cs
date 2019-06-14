using System;
using System.Collections.Generic;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class LoadingScreen
    {
        
        public void Load()
        {
            if (VarDatabase.Debug)
            {
                foreach (var item in LoadMessages)
                {
                    Loadbar(item.Key);
                    item.Value.Invoke();
                }

                MapControls.DrawMap();
            }
            else
            {
                Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
                Console.Clear();
                //StartMenu.DrawFirePits();
                //   StartMenu.Fire = new Thread(StartMenu.DrawFire);
                // StartMenu.Fire.Start();
                Draw.Box(Console.WindowWidth * 2 / 5, Console.WindowHeight * 5 / 6, Console.WindowWidth * 3 / 5, Console.WindowHeight * 5 / 6 + 4, Painter.Instance.Paint(ConsoleColor.Blue));
                foreach (var item in LoadMessages)
                {
                    Loadbar(item.Key);
                    item.Value.Invoke();
                }

                barCount = 1;
                //  StartMenu.Fire.Abort();
                MapControls.DrawMap();
            }
        }

        private static readonly Dictionary<string, TempDelegate> LoadMessages = new Dictionary<string, TempDelegate>
        {
            {"Clearing Variables...", MapGeneration.Clearvars},
            {"Map Generation Started...", MapGeneration.GenerateCorridors},
            {"Advanced Map Generation Initiated...", MapFixVars},
            {"Defining Variables...", Definevars}
        };
    }
}