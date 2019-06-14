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

        public static void End()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            short x =0 ;
            short y =0 ;
            short i = 0;
            short vx = 1;
            MainGame.Boss = true;
            MainGame.DamageArray = new bool[MainGame.CurrentLoadedMap.Mapheight, MainGame.CurrentLoadedMap.Mapwidth];
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
                MainGame.GameBuffer.SetDrawCord(x, y);
                MainGame.GameBuffer.Print();
                i++;
                Thread.Sleep(20);
                if (i == 250)
                {
                    MainGame.Entities.Clear();
                    MainGame.CurrentLoadedMap = new CustomMap(MainGame.CurrentLoadedMap.Mapheight, Console.WindowWidth, false);
                    TerrainSelection.Redirect(MainGame.CurrentLoadedMap, 204);
                    Gameplay.Push();
                    foreach (var player in MainGame.Players)
                    {
                        player.SetSpawn();
                    }
                    MainGame.Entities.Add(new Godzilla(MainGame.CurrentLoadedMap));
                    MainGame.FillEntities();
                    MainGame.Render();
                }
            }
            Console.Clear();
            MainGame.GameBuffer.SetDrawCord(0, 0);
        }
    }
}