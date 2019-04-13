using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class VersusMenu
    {
        private bool versus = true;
        public VersusMenu()
        {
            CircularList<UIObject> versusMenuList = new CircularList<UIObject>();
            UIObject singlePlayerButton = UIFactory.createDefaultButton("Single Player", this.singlePlayer,);
            UIObject splitScreenButton = UIFactory.createButton();
            UIObject lanButton = UIFactory.createButton();
            UIObject lanServerButton = UIFactory.createButton();
            versusMenuList.Add(singlePlayerButton);
            versusMenuList.Add(splitScreenButton);
            versusMenuList.Add(lanButton);
            versusMenuList.Add(lanServerButton);
            Menu versusMenu = new Menu(versusMenuList,null);//TODO
            return versusMenu;
            /*
            new Button {Message = "Single-Player", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*0, BlockHeight = Console.WindowHeight/9},
             new Button {Message = "Split-Screen", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*1, BlockHeight = Console.WindowHeight/9},
              new Button {Message = "LAN", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*2, BlockHeight = Console.WindowHeight/9},
               new Button {Message = "New LAN Server", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*3, BlockHeight = Console.WindowHeight/9}},
                TextBoxList = new List<TextBox>()}};
                */
        }

        private void singlePlayer()
        {
          //  MapSelectionMenu//TODO
        }

        private void splitScreen()
        {
          //  MapSelectionMenu//TODO
        }

        private void lan()
        {
            Client.Start();//TODO
        }

        private void lanServer()
        {
            Server.Start();//TODO
        }
    }
}