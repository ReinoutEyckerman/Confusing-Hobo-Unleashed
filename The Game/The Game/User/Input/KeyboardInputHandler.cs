using System;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.UI.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed.User
{
    public class KeyboardInputHandler : InputHandler //TODO Configuration files
    {
        public override Input handle()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                return Input.UP;
            }

            if (state.IsKeyDown(Keys.Down))
            {
                return Input.DOWN;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                return Input.LEFT;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                return Input.RIGHT;
            }

            if (state.IsKeyDown(Keys.Enter))
            {
                return Input.START;
            }

            if (state.IsKeyDown(Keys.Escape))
            {
                return Input.BACK;
            }

            return Input.A; //TODO: Return list of inputs?
        }
    }
}