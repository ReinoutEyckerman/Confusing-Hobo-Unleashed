using System;
using System.Threading;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Multiplayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Keyboard = System.Windows.Input.Keyboard;

namespace Confusing_Hobo_Unleashed.User
{
    internal class InputHandler
    {
        public static Buttons ControlInputHandling()
        {
            Thread.Sleep(90);
            bool controller = GamePad.GetState(PlayerIndex.One).IsConnected;

            do
            {
                if (Keyboard.IsKeyDown(Key.Up) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)))
                    return Buttons.DPadUp;
                if (Keyboard.IsKeyDown(Key.Up) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)
                    return Buttons.LeftThumbstickUp;
                if (Keyboard.IsKeyDown(Key.Up) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == 1)
                    return Buttons.RightThumbstickUp;
                if (Keyboard.IsKeyDown(Key.Down) || (controller && GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed))
                    return Buttons.DPadDown;
                if (Keyboard.IsKeyDown(Key.Down) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1))
                    return Buttons.LeftThumbstickDown;
                if (Keyboard.IsKeyDown(Key.Down) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == -1))
                    return Buttons.RightThumbstickDown;
                if (Keyboard.IsKeyDown(Key.Left) || (controller && GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed))
                    return Buttons.DPadLeft;
                if (Keyboard.IsKeyDown(Key.Left) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1))
                    return Buttons.LeftThumbstickLeft;
                if (Keyboard.IsKeyDown(Key.Left) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X == -1))
                    return Buttons.RightThumbstickLeft;
                if (Keyboard.IsKeyDown(Key.Right) || (controller && GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed))
                    return Buttons.DPadRight;
                if (Keyboard.IsKeyDown(Key.Right) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1))
                    return Buttons.LeftThumbstickRight;
                if (Keyboard.IsKeyDown(Key.Right) || (controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X == 1))
                    return Buttons.RightThumbstickRight;
                if ((controller && (GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed)))
                    return Buttons.LeftShoulder;
                if ((controller && (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed)))
                    return Buttons.RightShoulder;
                if ((controller && GamePad.GetState(PlayerIndex.One).Triggers.Left == 1))
                    return Buttons.LeftTrigger;
                if ((controller && GamePad.GetState(PlayerIndex.One).Triggers.Right == 1))
                    return Buttons.RightTrigger;
                if (Keyboard.IsKeyDown(Key.Enter) || (controller && (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)))
                    return Buttons.A;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed))
                    return Buttons.B;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed))
                    return Buttons.X;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed))
                    return Buttons.Y;
                if (Keyboard.IsKeyDown(Key.Escape) || (controller && GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed))
                    return Buttons.Back;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed))
                    return Buttons.BigButton;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed))
                    return Buttons.Start;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed))
                    return Buttons.LeftStick;
                if ((controller && GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed))
                    return Buttons.RightStick;
            } while (true);
        }

        public static void AiHandling(Player player)
        {
            var random = new Random();
            if (Game.Players[0].X - Game.Players[1].X < 10 && Game.Players[0].X - Game.Players[1].X >= 0 || !(player.IsPossibleMove(Game.CurrentLoadedMap, Move.Right)))
            {
                if (random.Next(2) == 0) player.MoveLeft(Game.CurrentLoadedMap);
                else if (random.Next(15) == 0)
                    player.Jump(Game.CurrentLoadedMap);
            }
            else if (Game.Players[1].X - Game.Players[0].X < 10 && Game.Players[1].X - Game.Players[0].X > 0 || !(player.IsPossibleMove(Game.CurrentLoadedMap, Move.Left)))
            {
                if (random.Next(2) == 0) player.MoveRight(Game.CurrentLoadedMap);

                else if (random.Next(15) == 0)
                    player.Jump(Game.CurrentLoadedMap);
            }
            else
            {
                if (random.Next(4) == 0)
                    player.MoveLeft(Game.CurrentLoadedMap);
                else if (random.Next(4) == 0)
                    player.MoveRight(Game.CurrentLoadedMap);
            }
            Thread.Sleep(4);
        }

        public static void GameInputHandling()
        {
            bool controller = GamePad.GetState(PlayerIndex.One).IsConnected;
            if (Keyboard.IsKeyDown(Key.Right) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1)
            {
                Client.Input[0] = Key.Right;
            }
            if (Keyboard.IsKeyDown(Key.Left) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1)
            {
                Client.Input[1] = Key.Left;
            }
            if (Keyboard.IsKeyDown(Key.Up) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)
            {
                Client.Input[2] = Key.Up;
            }
            if (Keyboard.IsKeyDown(Key.Down) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1)
            {
                Client.Input[3] = Key.Down;
            }
            if (Keyboard.IsKeyDown(Key.Q) || controller && GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                Client.Input[4] = Key.Q;
            }
            if (Keyboard.IsKeyDown(Key.Z) || controller && GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                Client.Input[5] = Key.Z;
            }

            if (Keyboard.IsKeyDown(Key.D) || controller && GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                Client.Input[6] = Key.D;
            }

            if (Keyboard.IsKeyDown(Key.S) || controller && GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                Client.Input[7] = Key.S;
            }

            if (Keyboard.IsKeyDown(Key.X) || controller && GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                Client.Input[8] = Key.X;
            }
        }

        public static void GameInputHandling(int playernum, Key key)
        {
            if (key == Key.Right)
            {
                Game.Players[playernum].MoveRight(Game.CurrentLoadedMap);
            }
            if (key == Key.Left)
            {
                Game.Players[playernum].MoveLeft(Game.CurrentLoadedMap);
            }
            if (key == Key.Up)
            {
                Game.Players[playernum].Jump(Game.CurrentLoadedMap);
            }
            if (key == Key.Down)
            {
                Game.Players[playernum].MoveDown(Game.CurrentLoadedMap);
            }
            if (key == Key.Escape)
            {
                PauseMenu.ShowStartMenu(Game.GameBuffer);
            }
            if (key == Key.Q)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Left);
            }
            if (key == Key.Z)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Up);
            }
            if (key == Key.D)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Right);
            }
            if (key == Key.S)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Down);
            }
            if (key == Key.X)
            {
                Game.Players[playernum].SwapWeapon();
            }
        }

        public static void GameInputHandling(int playernum)
        {
            bool controller = GamePad.GetState(PlayerIndex.One).IsConnected;

            if (Keyboard.IsKeyDown(Key.Right) || controller &&  GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1)
            {
                Game.Players[playernum].MoveRight(Game.CurrentLoadedMap);
            }
            if (Keyboard.IsKeyDown(Key.Left) || controller && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1)
            {
                Game.Players[playernum].MoveLeft(Game.CurrentLoadedMap);
            }
            if (Keyboard.IsKeyDown(Key.Up) || controller &&  GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)
            {
                Game.Players[playernum].Jump(Game.CurrentLoadedMap);
            }
            if (Keyboard.IsKeyDown(Key.Down) || controller &&  GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1)
            {
                Game.Players[playernum].MoveDown(Game.CurrentLoadedMap);
            }
            if (Keyboard.IsKeyDown(Key.Escape)|| controller && GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed)
            {
                PauseMenu.ShowStartMenu(Game.GameBuffer);
            }
            if (Keyboard.IsKeyDown(Key.Q) || controller && GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Left);
            }
            if (Keyboard.IsKeyDown(Key.Z)||controller && GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed )
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Up);
            }
            if (Keyboard.IsKeyDown(Key.D)||controller && GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Right);
            }
            if (Keyboard.IsKeyDown(Key.S)||controller && GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                Game.Players[playernum].Attack(Game.CurrentLoadedMap, Move.Down);
            }
            if (Keyboard.IsKeyDown(Key.X)||controller && GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                Game.Players[playernum].SwapWeapon();
            }
        }
        
        public static void PauseMenuInputHandling()
        {
            bool controller = GamePad.GetState(PlayerIndex.One).IsConnected;
                        if (Keyboard.IsKeyDown(Key.Up) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)))
            {
                PauseMenu.ChangeSelect(false);
            }
            if (Keyboard.IsKeyDown(Key.Down) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1)))
            {
                PauseMenu.ChangeSelect(true);
            }
            if (Keyboard.IsKeyDown(Key.Enter)||controller && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                PauseMenu.EnterCurrentOption();
            }
        }
    }

    public enum Action
    {
        Right,
        Left,
        Up,
        None
    }
}