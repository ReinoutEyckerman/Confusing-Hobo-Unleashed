using System.Diagnostics;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.Menu
{
    public abstract class Menu : Drawable
    {
        protected AbstractList root;
        protected GameState? GameState = null;

        public GameState Start()
        {
            if (GameState == null)
            {
                HandleAction();
                Run();
                Draw();
            }

            return (GameState) GameState;
        }

        protected abstract void Run();

        protected void exit(GameState gameState)
        {
            this.GameState = gameState;
        }

        public void HandleAction(Input action)
        {
            root.HandleAction(action);
            if (!root.IsActive())
            {
                exit(defaultExitState());
            }
        }

        protected abstract GameState defaultExitState();

        public void Draw()
        {
            root.Draw();
        }

        public void DrawRelative(Position relativeTo)
        {
            root.DrawRelative(relativeTo);
        }
    }
}