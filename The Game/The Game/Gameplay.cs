using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Enemies;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class Gameplay
    {
        public static int RoomsVisited = 1;

        public static void Push()
        {
            foreach (var layer in Game.CurrentLoadedMap.Layers)
            {
                Game.CurrentLoadedMap.PushtoArray(layer.Value.Background, layer.Value.Foreground, layer.Value.Colors);
            }
            Array.Copy(Game.CurrentLoadedMap.Collision, Game.CurrentLoadedMap.CollisionBackUp, Game.CurrentLoadedMap.Mapheight*Console.WindowWidth);
        }

        private static void Enemies()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int number = random.Next(5);
                switch (number)
                {
                    case 0:
                        Game.Entities.Add(new Zerg(Game.CurrentLoadedMap));
                        break;
                    case 1:
                        Game.Entities.Add(new Harpy(Game.CurrentLoadedMap));
                        break;
                    case 2:
                        Game.Entities.Add(new Necromancer(Game.CurrentLoadedMap));
                        break;
                    case 3:
                        Game.Entities.Add(new Roflcopter(Game.CurrentLoadedMap));
                        break;
                }
            }
            foreach (Player player in Game.Players)
            {
                if (player.HpTotal != null) player.HpCurrent = (int) player.HpTotal;
                player.Map = Game.CurrentLoadedMap;
            }
            Game.FillEntities();
            foreach (AiCore entity in Game.Entities)
                entity.SetSpawn();
            
        }

        public static void EnableTerrain()
        {
            Push();
            Game.Entities = new List<AiCore>();
            Enemies();
            Game.GameLoop();
            RoomsVisited++;
            MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] = true;
            Console.Clear();
        }
    }
}