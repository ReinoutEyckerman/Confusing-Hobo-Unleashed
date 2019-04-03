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
        private static readonly Dictionary<int, SoundPlayer> SoundTracks = new Dictionary<int, SoundPlayer> {{0, new SoundPlayer(@"Sound Files\Fancy.wav")}, {1, new SoundPlayer(@"Sound Files\Happy.wav")}, {2, new SoundPlayer(@"Sound Files\HappySlow.wav")}, {3, new SoundPlayer(@"Sound Files\LoopMe.wav")}, {4, new SoundPlayer(@"Sound Files\MonoTone.wav")}, {5, new SoundPlayer(@"Sound Files\Ode To Joy.wav")}, {6, new SoundPlayer(@"Sound Files\Oh Susanna.wav")}, {7, new SoundPlayer(@"Sound Files\Over The Rainbow.wav")}, {8, new SoundPlayer(@"Sound Files\Rudolf.wav")}, {9, new SoundPlayer(@"Sound Files\Untitled.wav")}};
        private static SoundPlayer _gamesound = new SoundPlayer();

        public static void End()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            short x =0 ;
            short y =0 ;
            short i = 0;
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
                    TerrainSelection.Redirect(Game.CurrentLoadedMap, 204);
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


        public static void PlayMusic()
        {
            var random = new Random();
            _gamesound = SoundTracks[random.Next(SoundTracks.Count)];
            _gamesound.Stop();
            _gamesound.PlayLooping();
        }
    }
}