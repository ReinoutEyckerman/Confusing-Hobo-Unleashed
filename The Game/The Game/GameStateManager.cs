namespace Confusing_Hobo_Unleashed
{
    public class GameStateManager
    {
        private GameState currentState;

        public GameStateManager()
        {
            currentState = GameState.Booting;
        }

        public GameStateManager(GameState state)
        {
            currentState = state;
        }

        public void Run()
        {
            while (currentState != GameState.Exit)
            {
                switch (currentState)
                {
                    case GameState.Booting :
                        break;
                    case GameState.Configuration:
                        break;
                    default:
                        currentState = GameState.Exit;
                        break;
                }
            }
        }
    }
}