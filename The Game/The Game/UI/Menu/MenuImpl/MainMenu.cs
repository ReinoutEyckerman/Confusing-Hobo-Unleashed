using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MainMenu:Menu
    {
        //private Menu menu;


        public MainMenu() 
        {
            CircularList<UIObject> mainMenuList = new CircularList<UIObject>();
            UIObject startButton = UIFactory.createDefaultButton(new TriggerEventHandler(startGame), );
            UIObject versusButton = UIFactory.createDefaultButton(new TriggerEventHandler(versusScreen), );
            UIObject mapEditorButton = UIFactory.createDefaultButton(new TriggerEventHandler(mapEditorScreen), );
            UIObject configScreenButton = UIFactory.createDefaultButton(new TriggerEventHandler(configScreen), );
            UIObject creditsButton = UIFactory.createDefaultButton(new TriggerEventHandler(creditsScreen), );
            mainMenuList.Add(startButton);
            mainMenuList.Add(versusButton);
            mainMenuList.Add(mapEditorButton);
            mainMenuList.Add(configScreenButton);
            mainMenuList.Add(creditsButton);
            this.root = new GridMenu(4, mainMenuList.Count/4, mainMenuList,);//TODO
            /*
             new Button {Message = "Start the Game!", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*0, BlockHeight = Console.WindowHeight/9},
             new Button {Message = "Versus Mode", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*1, BlockHeight = Console.WindowHeight/9},
             new Button {Message = "Map Editor", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*2, BlockHeight = Console.WindowHeight/9},
             new Button {Message = "Configuration Screen", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*3, BlockHeight = Console.WindowHeight/9},
             new Button {Message = "Credits", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*4, BlockHeight = Console.WindowHeight/9}
             */
        }

        private void startGame()
        {
            
        }

        private void versusScreen()
        {
            
        }

        private void mapEditorScreen()
        {
            
        }

        private void configScreen()
        {
            
        }
        
        private void creditsScreen()
        {
            
        }
    }
}