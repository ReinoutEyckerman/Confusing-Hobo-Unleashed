using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class ConfigurationMenu : Menu
    {
        private Configuration configuration;

        public ConfigurationMenu()
        {
            //TODO Name tags
            AbstractList mapSize = createMapsizeList();
            AbstractList mapDisplaySize = createMapsizeList();
            AbstractList difficulties = createDifficultyList();
            AbstractList worldTypes = createWorldTypeList();
            AbstractList colorScheme = createColorSchemeList();
            AbstractList extras = createExtraList();
            AbstractList configMenuList = new HorizontalListBuilder()
                .addUIObject(mapSize)
                .addUIObject(mapDisplaySize)
                .addUIObject(difficulties)
                .addUIObject(worldTypes)
                .addUIObject(colorScheme)
                .addUIObject(extras)
                .build();
            root = configMenuList;
        }

        private AbstractList createMapsizeList()
        {
            AbstractListBuilder mapSizeList = new VerticalListBuilder();

            foreach (MapSize mapSize in EnumExtensions.GetValues<MapSize>())
                mapSizeList.addUIObject(
                    UIFactory.createDefaultRelativeButton(mapSize.ToString(), configuration.setMapSize));

            //TODO           mapSizeList.addUIObject(UIFactory.createDefaultRelativeButton("Custom", new ButtonTrigger("Custom")));

            return mapSizeList.build();
        }

        private AbstractList createMapDisplayList()
        {
            VerticalListBuilder mapDisplayList = new VerticalListBuilder();
            foreach (MapDisplay mapDisplay in EnumExtensions.GetValues<MapDisplay>())
                mapDisplayList.addUIObject(
                    UIFactory.createDefaultRelativeButton(mapDisplay.ToString(), configuration.setMapDisplay));

            //TODO           mapDisplayList.addUIObject(UIFactory.createDefaultRelativeButton("Custom", new ButtonTrigger()));

            return mapDisplayList.build();
        }

        private AbstractList createDifficultyList()
        {
            VerticalListBuilder mapDifficultyList = new VerticalListBuilder();
            foreach (Difficulty difficulty in EnumExtensions.GetValues<Difficulty>())
                mapDifficultyList.addUIObject(
                    UIFactory.createDefaultRelativeButton(difficulty.ToString(), configuration.setDifficulty));
            return mapDifficultyList.build();
        }

        private AbstractList createColorSchemeList()
        {
            AbstractList colorSchemeList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", configuration.setColorScheme))
                .addUIObject(UIFactory.createDefaultRelativeButton("Black/White", configuration.setColorScheme))
                .addUIObject(UIFactory.createDefaultRelativeButton("4 Shades of Gray", configuration.setColorScheme))
                .addUIObject(UIFactory.createDefaultRelativeButton("yarG fo sedahS 4", configuration.setColorScheme))
                .addUIObject(
                    UIFactory.createDefaultRelativeButton("Random",
                        configuration.setColorScheme)) //TODO Generate instead of manually listing
                .build();
            return colorSchemeList;
        }

        private AbstractList createWorldTypeList()
        {
            AbstractList colorSchemeList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Asteroid", configuration.setWorldType))
                .addUIObject(UIFactory.createDefaultRelativeButton("Air", configuration.setWorldType))
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", configuration.setWorldType))
                .addUIObject(UIFactory.createDefaultRelativeButton("Underground", configuration.setWorldType))
                .build();
            return colorSchemeList;
        }

        private AbstractList createExtraList()
        {
            AbstractList ExtraList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Invert", configuration.setInversion))
                .build();
            return ExtraList;
        }

        protected override void Run()
        {
        }

        protected override GameState defaultExitState()
        {
            return Confusing_Hobo_Unleashed.GameState.StartScreen;
        }
    }
}