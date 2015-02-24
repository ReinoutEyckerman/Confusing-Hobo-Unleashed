using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.TerrainGen;

namespace Confusing_Hobo_Unleashed
{
    internal class Endgame
    {
        private static readonly Dictionary<int, SoundPlayer> SoundTracks = new Dictionary<int, SoundPlayer>
        {
            {0, new SoundPlayer(@"Sound Files\Fancy.wav")},
            {1, new SoundPlayer(@"Sound Files\Happy.wav")},
            {2, new SoundPlayer(@"Sound Files\HappySlow.wav")},
            {3, new SoundPlayer(@"Sound Files\LoopMe.wav")},
            {4, new SoundPlayer(@"Sound Files\MonoTone.wav")},
            {5, new SoundPlayer(@"Sound Files\Ode To Joy.wav")},
            {6, new SoundPlayer(@"Sound Files\Oh Susanna.wav")},
            {7, new SoundPlayer(@"Sound Files\Over The Rainbow.wav")},
            {8, new SoundPlayer(@"Sound Files\Rudolf.wav")},
            {9, new SoundPlayer(@"Sound Files\Untitled.wav")}
        };

        private static SoundPlayer _gamesound = new SoundPlayer();

        public static void End()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            short i = 0;
            short x = 0;
            short y = 0;
            short vx = 1;
            Game.Boss = true;
            Game.DamageArray = new bool[Game.CurrentLoadedMap.Mapheight, Game.CurrentLoadedMap.Mapwidth];
            while (i < 500)
            {
                if (x > 1 || x < -1)
                    vx *= -1;
                if (i%5 == 0)
                    if (y == 0)
                        y = -1;
                    else if (y == -1)
                        y = 0;

                x += vx;
                Game.GameBuffer.SetDrawCord(x, y);
                Game.GameBuffer.Print();
                i++;
                Thread.Sleep(20);
                if (i == 250)
                {
                    Game.Entities.Clear();
                    Game.CurrentLoadedMap = new CustomMap(Game.CurrentLoadedMap.Mapheight, Console.WindowWidth, false);
                    TerrainSelection.Redirect(Game.CurrentLoadedMap, 204 );
                    Gameplay.Push();
                    foreach (var player in Game.Players)
                    {
                        player.SetSpawn();
                    }
                    Game.Entities.Add(new Godzilla(Game.CurrentLoadedMap));
                    Game.FillEntities();
                    Game.Render();
                }
            }
            Console.Clear();
            Game.GameBuffer.SetDrawCord(0, 0);
        }

        public static void Losebots()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 10);
            Console.Write("    _                                _    _      _ _     _                 _ _     ");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 9);
            Console.Write(@"   /_\__ __ ____ __ __   __ ___ _  _| |__| |_ _ ( ) |_  | |_  __ _ _ _  __| | |___ ");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 8);
            Console.Write(@"  / _ \ V  V /\ V  V /  / _/ _ \ || | / _` | ' \|/|  _| | ' \/ _` | ' \/ _` | / -_)");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 7);
            Console.Write(@" /_/ \_\_/\_/  \_/\_( ) \__\___/\_,_|_\__,_|_||_|  \__| |_||_\__,_|_||_\__,_|_\___|");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 6);
            Console.Write(@"  _   _          _  |/     _      ___ ");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 5);
            Console.Write(@" | |_| |_  ___  | |__  ___| |_ __|__ \ ");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 4);
            Console.Write(@" |  _| ' \/ -_) | '_ \/ _ \  _(_-< /_/");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2 - 3);
            Console.Write(@"  \__|_||_\___| |_.__/\___/\__/__/(_) ");
            Thread.Sleep(7000);
            StartMenu.MainScreen();
        }

        public static void PlayMusic()
        {
            var random = new Random();
            _gamesound = SoundTracks[random.Next(SoundTracks.Count)];
            _gamesound.Stop();
            _gamesound.PlayLooping();
        }

        public static void Win()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            Console.ForegroundColor = Painter.Instance.Paint(ConsoleColor.White,true);
            Game.GameBuffer.Clear();
            var meslength = "   ____                            _         _       _   _".Length/2;
            Game.GameBuffer.Draw(@"   ____                            _         _       _   _",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2 - 3,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@"  / ___|___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2 - 2,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@" | |   / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __|",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2 - 1,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@" | |__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \ ",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@"  \____\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2 + 1,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@"                   |___/                                                 ",
                Console.WindowWidth/2 - meslength, Console.WindowHeight/2 + 2,
                Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Draw(@"And now complete the game on a harder difficulty!", Console.WindowWidth/2 - meslength,
                Console.WindowHeight / 2 + 4, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            Game.GameBuffer.Print();
        }
    }
}