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
        [STAThread]
        public static void Main()
        {
            AbstractUIFactory.setInstance(new MSConsoleUIFactory());
            GameStateManager manager = new GameStateManager();
            manager.Run();
        }
    }
}