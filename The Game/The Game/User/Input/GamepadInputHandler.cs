using System;
using System.Threading;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.UI.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed.User
{
    public class GamepadInputHandler : InputHandler
    {
        public override Input handle()
        {
            var controller = GamePad.GetState(PlayerIndex.One).IsConnected;

            if (!controller) return Input.UP;//TODO
            
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == 1)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                return Input.DOWN;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1)
            {
                return Input.DOWN;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == -1)
            {
                return Input.DOWN;
            }

            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                return Input.LEFT;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1)
            {
                return Input.LEFT;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X == -1)
            {
                return Input.LEFT;
            }

            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                return Input.RIGHT;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1)
            {
                return Input.RIGHT;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X == 1)
            {
                return Input.RIGHT;
            }

            //TODO input
            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Triggers.Left == 1)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Triggers.Right == 1)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed)
            {
                return Input.UP;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed)
            {
                return Input.UP;
            }

            return Input.UP;
        }
    }
}