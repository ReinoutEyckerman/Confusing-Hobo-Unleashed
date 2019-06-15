using Confusing_Hobo_Unleashed.Tools;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class Configuration
    {
        private Difficulty _difficulty;
        private MapDisplay _mapDisplay;
        private MapSize _mapSize;

        public Configuration()
        {
            _mapSize = MapSize.Small;
            _mapDisplay = MapDisplay.Small;
            _difficulty = Difficulty.Mediocre;
        }

        public void setMapSize(object size)
        {
            _mapSize = EnumExtensions.Parse<MapSize>(size.ToString());
        }

        public void setMapDisplay(object display)
        {
            _mapDisplay = EnumExtensions.Parse<MapDisplay>(display.ToString());
        }

        public void setDifficulty(object difficulty)
        {
            _difficulty = EnumExtensions.Parse<Difficulty>(difficulty.ToString());
        }
    }
}