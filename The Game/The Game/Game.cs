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
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class Game
    {
        public static CustomMap CurrentLoadedMap { get; set; }
        public static Buffer GameBuffer { get; set; }
        public static List<Player> Players { get; set; }
        public static Encoding OutputEncoding { get; set; }

        [STAThread]
        public static void Main()
        {
            Window window = new MicrosoftWindow();
            Init();
            AlphaBootScreen.DrawAlphaSymbol(window);
            Thread.Sleep(5000);
            window.Clear();
            StartMenu.MainScreen(window);
        }

        private static void Init()
        {
            CurrentLoadedMap = new CustomMap(55);
            //Setting Lists
            StartMenu.GenList();
            DrawUi.PostStart();
            GameBuffer = new Buffer(Console.WindowWidth, Console.WindowHeight, Console.WindowWidth, Console.WindowHeight);
            Players = new List<Player>();
            Endgame.PlayMusic();
        }

        public static void FillEntities()
        {
            foreach (var player in Players)
                Entities.Add(player);
        }

        public static void GameLoop()
        {
            Endgame.PlayMusic();
            var frameTimer = new Stopwatch();
            frameTimer.Start();

            while (true)
            {
                frameTimer.Restart();
                Array.Copy(CurrentLoadedMap.CollisionBackUp, CurrentLoadedMap.Collision, CurrentLoadedMap.Mapheight*CurrentLoadedMap.Mapwidth);
                UpdateGame();
                if (CheckWin())
                    return;
                Render();
                if (!Boss)

                    if (frameTimer.ElapsedMilliseconds < VarDatabase.FrameTimeMs)
                    {
                        Thread.Sleep(VarDatabase.FrameTimeMs - (int) frameTimer.ElapsedMilliseconds);
                    }
            }
        }

        private static bool CheckWin()
        {
            var players = 0;
            var enemies = 0;
            foreach (var entity in Entities)
            {
                if (entity.CurrentClass == Classes.Player)
                    players++;
                else if (entity.CurrentClass != Classes.Grave)
                    enemies++;
            }
            if (Gameplay.RoomsVisited == MapGeneration.Approved)
            {
                if (Boss)
                {
                    Endgame.Win();
                }
                else Endgame.End();
            }
            if (enemies == 0)
                return true;
            if (players == 0)
                Endgame.Losebots();
            return false;
        }

        public static void UpdateGame()
        {
            if (VarDatabase.CurrentLayer != Layers.Cave && Random.Next(10000) == 0)
                TerrainGraphics.CopterAnimation = true;
            if (!Boss && Random.Next(100000) == 0)
                GodzillaAnimation.Animate = true;

            for (var i = 0; i < Entities.Count; i++)
            {
                Array.Copy(CurrentLoadedMap.CollisionBackUp, CurrentLoadedMap.Collision, CurrentLoadedMap.Mapheight*CurrentLoadedMap.Mapwidth);
                for (var j = 0; j < Entities.Count; j++)
                    if (i != j && Entities[j].CurrentClass != Classes.Boss)
                        CurrentLoadedMap.Collision[Entities[j].Y, Entities[j].X] = true;
                Entities[i].UpdateMana();
                Entities[i].Movement(CurrentLoadedMap);
                Entities[i].SetCollision();
                Entities[i].CalculateAttack();
                if (Entities[i].CurrentClass != Classes.Grave)
                    Entities[i].Special();
                if (DamageArray != null && Entities[i].CurrentClass != Classes.Boss && DamageArray[Entities[i].Y, Entities[i].X])
                {
                    Entities[i].HpCurrent--;
                }
            }
            for (var i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].CalculateMovement(CurrentLoadedMap))
                    Bullets.RemoveAt(i);
            }
            for (var index = 0; index < Entities.Count; index++)
            {
                Entities[index].Update();
                if (Entities[index].HpCurrent <= 0)
                {
                    if (Entities[index].CurrentClass != Classes.Grave)
                        Entities.Add(new Grave(CurrentLoadedMap, Entities[index]));
                    Entities.RemoveAt(index);
                }
            }
            Gravity();
        }

        public static void Render()
        {
            if (CurrentLoadedMap.Layers[0].IsEnabled)
                CurrentLoadedMap.Layers[0].LayerToBuffer(GameBuffer);
            if (CurrentLoadedMap.DayNightEnabled)
            {
                if (MoonCount == 30)
                {
                    MoonCount = 0;
                    TerrainGraphics.GenCyclus(CurrentLoadedMap, true);
                }
                TerrainGraphics.GenCyclus(CurrentLoadedMap);
            }
            if (TerrainGraphics.CopterAnimation)
                TerrainGraphics.Copter(CurrentLoadedMap);
            if (GodzillaAnimation.Animate || Boss)
                GodzillaAnimation.Draw(CurrentLoadedMap);
            if (CurrentLoadedMap.Layers[Maplayers.Collision].IsEnabled)
                CurrentLoadedMap.Layers[Maplayers.Collision].LayerToBuffer(GameBuffer);
            MoonCount++;
            if (CurrentLoadedMap.Layers[Maplayers.Destructible].IsEnabled)
                CurrentLoadedMap.Layers[Maplayers.Destructible].LayerToBuffer(GameBuffer);

            if (CurrentLoadedMap.Layers[Maplayers.Decor].IsEnabled)
                CurrentLoadedMap.Layers[Maplayers.Decor].LayerToBuffer(GameBuffer);

            foreach (var entity in Entities)
            {
                entity.Render(GameBuffer, CurrentLoadedMap);
            }
            foreach (var bullet in Bullets)
            {
                bullet.Render(GameBuffer, CurrentLoadedMap);
                bullet.Rendered = true;
            }
            GameUi.DrawUi(GameBuffer, Players[0] /*, Players[1]*/);

            if (CurrentLoadedMap.Layers[Maplayers.Clouds].IsEnabled)
                CurrentLoadedMap.Layers[Maplayers.Clouds].LayerToBuffer(GameBuffer);
            GameBuffer.Print();
            Console.SetCursorPosition(10, 0);
            Console.Write(MapGeneration.Terrains[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent]);
            Console.Write("\nBotErrorCount: " + BotErrorCount);
        }

        public static void Gravity()
        {
            foreach (var player in Entities)
            {
                if (player.SpeedY != 0 || player.CanFly)
                {
                    player.MoveUp(CurrentLoadedMap);
                }
                else
                {
                    player.MoveDown(CurrentLoadedMap);
                }
            }
        }

        public static void Start_Versus()
        {
            Players.Add(new Player(CurrentLoadedMap, 10, 3, 100, '1', ConsoleColor.Black, ConsoleColor.White));
            Entities.Add(new Necromancer(CurrentLoadedMap));
            GameLoop();
        }

        public static bool Versus = false;
        public static bool BotsEnabled = true;
        public static int MoonCount;
        public static List<AiCore> Entities = new List<AiCore>();
        public static List<BulletCore> Bullets = new List<BulletCore>();
        public static Stopwatch FrameTimer = new Stopwatch();
        public static bool Boss = false;
        public static bool[,] DamageArray;
        private static readonly Random Random = new Random();
        public static int BotErrorCount;
    }
}