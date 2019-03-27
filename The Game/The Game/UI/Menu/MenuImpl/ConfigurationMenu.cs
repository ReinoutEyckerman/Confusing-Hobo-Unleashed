using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class ConfigurationMenu:Menu
    {
        public ConfigurationMenu()
        {
            HorizonalList mapSize= new HorizonalList(createMapsizeList(),null);//TODO
            HorizonalList mapDisplaySize= new HorizonalList(createMapDisplayList(),null);//TODO
            HorizonalList difficulties= new HorizonalList(createDifficultyList()(),null);//TODO
            HorizonalList worldTypes= new HorizonalList(createWorldTypeList()(),null);//TODO
            HorizonalList colorScheme= new HorizonalList(createColorSchemeList()(),null);//TODO
            HorizonalList extras= new HorizonalList(createExtraList(),null);//TODO
            CircularList<UIObject> configMenuList = new CircularList<UIObject>();
            configMenuList.Add(mapSize);
            configMenuList.Add(mapDisplaySize);
            configMenuList.Add(difficulties);
            configMenuList.Add(worldTypes);
            configMenuList.Add(colorScheme);
            configMenuList.Add(extras);
            VerticalList items = new VerticalList(configMenuList, null); //TODO
            this.root=new GridMenu(new CircularList<UIObject>(items,), );//TODO
        }
        
        private CircularList<UIObject> createMapsizeList()
        {
            
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button small = new Button();
            Button medium = new Button();
            Button large = new Button();
            Button custom = new Button();
            items.Add(small);
            items.Add(medium);
            items.Add(large);
            items.Add(custom);
            return items;
        }
        
        private CircularList<UIObject> createMapDisplayList()
        {
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button small = new Button();
            Button medium = new Button();
            Button large = new Button();
            Button custom = new Button();
            items.Add(small);
            items.Add(medium);
            items.Add(large);
            items.Add(custom);
            return items;
        }
        
        private CircularList<UIObject> createDifficultyList()
        {
            
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button veasy = new Button();
            Button easy = new Button();
            Button medium = new Button();
            Button hard = new Button();
            Button vhard = new Button();
            items.Add(veasy);
            items.Add(easy);
            items.Add(medium);
            items.Add(hard);
            items.Add(vhard);
            return items;
        }
        
        private CircularList<UIObject> createColorSchemeList()
        {
            
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button normal = new Button();
            Button bw = new Button();
            Button shades = new Button();
            Button shadesinv = new Button();
            Button random = new Button();
            items.Add(normal);
            items.Add(bw);
            items.Add(shades);
            items.Add(shadesinv);
            items.Add(random);
            return items;
        }
        
        private CircularList<UIObject> createWorldTypeList()
        {
            
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button asteroid = new Button();
            Button air = new Button();
            Button normal = new Button();
            Button underground = new Button();
            items.Add(asteroid);
            items.Add(air);
            items.Add(normal);
            items.Add(underground);
            return items;
        }
        
        private CircularList<UIObject> createExtraList()
        {
            
            CircularList<UIObject> items = new CircularList<UIObject>();
            Button invert = new Button();
            items.Add(invert);
            return items;
        }
        
           //(new OptionsMenu {BiDirectional = true, Name = "Map Size", Content = "This defines the size in number of rooms on the game-map. Note: Too much rooms may increase loading times or even make the game unable to generate or display properly. You can possibly fix the display size by picking 'Small' in map display size.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, State = true, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {4, 4, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {7, 4, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 6, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {7, 4}}}});
         //   Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Display Size", Content = "This defines the size of the displayed rooms on the map. Setting them to 'Small' will display larger maps correctly.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {5, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {9, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {9, 5}}}});
 //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Exploration Difficulty", Content = "Difficulty of map. Very easy=Start with complete map. Easy=Map is retrievable en rooms discovered are registered. Medium=Map retrievable. Hard=Rooms registered. Very hard=None of these.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*5, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Very Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Medium", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Hard", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Very Hard", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}}});
 //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Color Schemes", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Normal", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, Value = true, BlockHeight = 8}, new Button {Message = "Black & White", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "4 Shades of Gray", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Inverted Shades of Gray ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Random ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});

 //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "World Type", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Asteroid", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Air", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Aboveground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = true}, new Button {Message = "Underground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
 //           Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Extra", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Invert", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
        
    }
}