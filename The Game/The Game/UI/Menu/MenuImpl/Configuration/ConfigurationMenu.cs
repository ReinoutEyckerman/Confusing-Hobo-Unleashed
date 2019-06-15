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

            mapSizeList.addUIObject(UIFactory.createDefaultRelativeButton("Custom", new ButtonTrigger()));

            return mapSizeList.build();
        }

        private AbstractList createMapDisplayList()
        {
            VerticalListBuilder mapDisplayList = new VerticalListBuilder();
            foreach (MapDisplay mapDisplay in EnumExtensions.GetValues<MapDisplay>())
                mapDisplayList.addUIObject(
                    UIFactory.createDefaultRelativeButton(mapDisplay.ToString(), configuration.setMapDisplay));

            mapDisplayList.addUIObject(UIFactory.createDefaultRelativeButton("Custom", new ButtonTrigger()));

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
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Black/White", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("4 Shades of Gray", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("yarG fo sedahS 4", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Random", new ButtonTrigger()))
                .build();
            return colorSchemeList;
        }

        private AbstractList createWorldTypeList()
        {
            AbstractList colorSchemeList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Asteroid", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Air", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", new ButtonTrigger()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Underground", new ButtonTrigger()))
                .build();
            return colorSchemeList;
        }

        private AbstractList createExtraList()
        {
            AbstractList ExtraList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Invert", new ButtonTrigger()))
                .build();
            return ExtraList;
        }

        //(new OptionsMenu {BiDirectional = true, Name = "Map Size", Content = "This defines the size in number of rooms on the game-map. Note: Too much rooms may increase loading times or even make the game unable to generate or display properly. You can possibly fix the display size by picking 'Small' in map display size.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, State = true, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {4, 4, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {7, 4, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 6, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {7, 4}}}});
        //   Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Display Size", Content = "This defines the size of the displayed rooms on the map. Setting them to 'Small' will display larger maps correctly.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {5, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {9, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {9, 5}}}});
        //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Exploration Difficulty", Content = "Difficulty of map. Very easy=Start with complete map. Easy=Map is retrievable en rooms discovered are registered. Medium=Map retrievable. Hard=Rooms registered. Very hard=None of these.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*5, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Very Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Medium", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Hard", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Very Hard", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}}});
        //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Color Schemes", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Normal", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, Value = true, BlockHeight = 8}, new Button {Message = "Black & White", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "4 Shades of Gray", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Inverted Shades of Gray ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Random ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});

        //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "World Type", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Asteroid", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Air", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Aboveground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = true}, new Button {Message = "Underground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
        //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Extra", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Invert", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
    }
}