using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Enemies;

namespace Confusing_Hobo_Unleashed
{
    internal class Gameplay
    {
        public static int RoomsVisited = 1;

        public static void Push()
        {
            foreach (var layer in MainGame.CurrentLoadedMap.Layers)
            {
                MainGame.CurrentLoadedMap.PushtoArray(layer.Value.Background, layer.Value.Foreground, layer.Value.Colors);
            }
            Array.Copy(MainGame.CurrentLoadedMap.Collision, MainGame.CurrentLoadedMap.CollisionBackUp, MainGame.CurrentLoadedMap.Mapheight*Console.WindowWidth);
        }

        private static void Enemies()
        {
            var random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var number = random.Next(5);
                switch (number)
                {
                    case 0:
                        MainGame.Entities.Add(new Zerg(MainGame.CurrentLoadedMap));
                        break;
                    case 1:
                        MainGame.Entities.Add(new Harpy(MainGame.CurrentLoadedMap));
                        break;
                    case 2:
                        MainGame.Entities.Add(new Necromancer(MainGame.CurrentLoadedMap));
                        break;
                    case 3:
                        MainGame.Entities.Add(new Roflcopter(MainGame.CurrentLoadedMap));
                        break;
                }
            }
            foreach (var player in MainGame.Players)
            {
                if (player.HpTotal != null) player.HpCurrent = (int) player.HpTotal;
                player.Map = MainGame.CurrentLoadedMap;
            }
            MainGame.FillEntities();
            foreach (var entity in MainGame.Entities)
            {
                entity.SetSpawn();
            }
        }

        public static void EnableTerrain()
        {
            Push();
            Enemies();
            RoomsVisited++;
            MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] = true;
            Console.Clear();
        }
    }
}