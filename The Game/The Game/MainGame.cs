using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class MainGame
    {
        public static Stopwatch GameTimer = new Stopwatch();

        [STAThread]
        public static void Main()
        {
            Window window = new MicrosoftWindow();
            AlphaBootScreen.DrawAlphaSymbol(window);
            Thread.Sleep(5000);
            window.Clear();
            MainMenu menu = new MainMenu();
        }
        
        public static string GameDuration(int x)
        {
            switch (x)
            {
                case 0:
                    GameTimer.Start();
                    break;
                case 1:
                    var time = GameTimer.Elapsed;
                    return time.ToString("hh\\:mm\\:ss");
                case 2:
                    GameTimer.Stop();
                    break;
            }
            return " ";
        }
    }
}