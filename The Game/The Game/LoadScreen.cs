using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    public class LoadScreen
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

        private static void Loadbar(string message)
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkCyan);
            var barLength = Console.WindowWidth / 5 / LoadMessages.Count;
            for (var a = 1; a <= 3; a++)
            {
                Console.SetCursorPosition(Console.WindowWidth * 2 / 5 + 1, Console.WindowHeight * 5 / 6 + a);
                for (var b = Console.WindowWidth * 2 / 5 + 1; b < Console.WindowWidth * 2 / 5 + barCount * barLength; b++)
                {
                    Console.Write(" ");
                }
            }

            barCount++;
            Thread.Sleep(20);
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            int w;
            if (prevMessage > Console.WindowWidth / 5)
                w = (prevMessage - Console.WindowWidth / 5) / 2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth * 4 / 10 - w, Console.WindowHeight * 5 / 6 - 1);
            for (var a = 0; a < prevMessage; a++)
            {
                Console.Write(" ");
            }

            if (message.Length > Console.WindowWidth / 5)
                w = (message.Length - Console.WindowWidth / 5) / 2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth * 2 / 5 - w, Console.WindowHeight * 5 / 6 - 1);
            Console.Write(message);
            prevMessage = message.Length;
        }

        private delegate void TempDelegate();

        private static int barCount = 1;
        private static int prevMessage;
        private static readonly Dictionary<string, TempDelegate> LoadMessages = new Dictionary<string, TempDelegate>
        {
            {"Clearing Variables...", MapGeneration.Clearvars},
            {"Map Generation Started...", MapGeneration.GenerateCorridors},
            {"Advanced Map Generation Initiated...", MapFixVars},
            {"Defining Variables...", Definevars}
        };
        
    }
}