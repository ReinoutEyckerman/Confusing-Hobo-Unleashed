using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    public class BootScreen
    {
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

        private static void MapFixVars()
        {
            MapGeneration.MainMapFix(MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, MapGeneration.EnableMoreCorridors);
        }

        private static void Definevars()
        {
            MapDrawing.RoomFound = new bool[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical];
            TerrainSelection.RoomDistribution();
            MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] = true;
            Game.Players = new List<Player>
            {
                new Player(Game.CurrentLoadedMap, 3, 3, 100, Encoding.GetEncoding(437).GetChars(new byte[] {001})[0],
                    VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black,
                    VarDatabase.ColorScheme.ForeGroundList[VarDatabase.ColorSchemenumber].White)
            };
        }

        public static void LoadScreen()
        {
            if (VarDatabase.Debug)
            {
                Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
                Console.Clear();
                foreach (var item in LoadMessages)
                {
                    Loadbar(item.Key);
                    item.Value.Invoke();
                }
                MapControls.DrawMap();
            }
            else
            {
                Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Blue;
                Console.Clear();
                StartMenu.DrawFirePits();
                StartMenu.Fire = new Thread(StartMenu.DrawFire);
                StartMenu.Fire.Start();
                Draw.Box(Console.WindowWidth*2/5, Console.WindowHeight*5/6, Console.WindowWidth*3/5,
                    Console.WindowHeight*5/6 + 4,
                    VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Blue);
                foreach (var item in LoadMessages)
                {
                    Loadbar(item.Key);
                    item.Value.Invoke();
                }
                GameDuration(0);
                _barCount = 1;
                StartMenu.Fire.Abort();
                MapControls.DrawMap();
            }
        }

        private static void Loadbar(string message)
        {
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkCyan;
            var barLength = Console.WindowWidth/5/LoadMessages.Count;
            for (var a = 1; a <= 3; a++)
            {
                Console.SetCursorPosition(Console.WindowWidth*2/5 + 1, Console.WindowHeight*5/6 + a);
                for (var b = Console.WindowWidth*2/5 + 1; b < Console.WindowWidth*2/5 + _barCount*barLength; b++)
                {
                    Console.Write(" ");
                }
            }
            _barCount++;
            Thread.Sleep(20);
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Blue;
            int w;
            if (_prevMessage > Console.WindowWidth/5)
                w = (_prevMessage - Console.WindowWidth/5)/2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth*4/10 - w, Console.WindowHeight*5/6 - 1);
            for (var a = 0; a < _prevMessage; a++)
            {
                Console.Write(" ");
            }

            if (message.Length > Console.WindowWidth/5)
                w = (message.Length - Console.WindowWidth/5)/2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth*2/5 - w, Console.WindowHeight*5/6 - 1);
            Console.Write(message);
            _prevMessage = message.Length;
        }

        private delegate void TempDelegate();

        public static Stopwatch GameTimer = new Stopwatch();
        private static int _barCount = 1;
        private static int _prevMessage;

        private static readonly Dictionary<string, TempDelegate> LoadMessages = new Dictionary<string, TempDelegate>
        {
            {"Clearing Variables...", MapGeneration.Clearvars},
            {"Map Generation Started...", MapGeneration.GenerateCorridors},
            {"Advanced Map Generation Initiated...", MapFixVars},
            {"Defining Variables...", Definevars}
        };
    }
}