using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class ConfigurationMenu : Menu
    {
        public ConfigurationMenu()
        {
            var mapSize = createMapsizeList();
            AbstractList mapDisplaySize = new HorizonalList(createMapDisplayList(), null); //TODO
            AbstractList difficulties = new HorizonalList(createDifficultyList()(), null); //TODO
            AbstractList worldTypes = new HorizonalList(createWorldTypeList()(), null); //TODO
            AbstractList colorScheme = new HorizonalList(createColorSchemeList()(), null); //TODO
            AbstractList extras = new HorizonalList(createExtraList(), null); //TODO
            var configMenuList = new AbstractListBuilder()
                .addUIObject(mapSize)
                .addUIObject(mapDisplaySize)
                .addUIObject(difficulties)
                .addUIObject(worldTypes)
                .addUIObject(colorScheme)
                .addUIObject(extras)
                .buildHorizontal();
            root = configMenuList;
        }

        private AbstractList createMapsizeList()
        {
            var mapSizeList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Small", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Medium", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Large", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Custom", new TriggerEventHandler()))
                .buildHorizontal();
            return mapSizeList;
        }

        private AbstractList createMapDisplayList()
        {
            var mapDisplayList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Small", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Medium", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Large", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Custom", new TriggerEventHandler()))
                .buildHorizontal();
            return mapDisplayList;
        }

        private AbstractList createDifficultyList()
        {
            var mapDifficultyList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Very Easy", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Easy", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Medium", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Hard", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Very Hard", new TriggerEventHandler()))
                .buildHorizontal();
            return mapDifficultyList;
        }

        private AbstractList createColorSchemeList()
        {
            var colorSchemeList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Black/White", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("4 Shades of Gray", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("yarG fo sedahS 4", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Random", new TriggerEventHandler()))
                .buildHorizontal();
            return colorSchemeList;
        }

        private AbstractList createWorldTypeList()
        {
            var colorSchemeList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Asteroid", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Air", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Normal", new TriggerEventHandler()))
                .addUIObject(UIFactory.createDefaultRelativeButton("Underground", new TriggerEventHandler()))
                .buildHorizontal();
            return colorSchemeList;
        }

        private AbstractList createExtraList()
        {
            var ExtraList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Invert", new TriggerEventHandler()))
                .buildHorizontal();
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