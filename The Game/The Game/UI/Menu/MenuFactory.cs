using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Confusing_Hobo_Unleashed.MapEdit;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.Menu
{
    public class MenuFactory
    {

        public static Menu createMainMenu()
        {
            CircularList<UIObject> mainMenuList = new CircularList<UIObject>();
            UIObject startButton = UIFactory.createButton();
            UIObject versusButton = UIFactory.createButton();
            UIObject mapEditorButton = UIFactory.createButton();
            UIObject configScreenButton = UIFactory.createButton();
            UIObject creditsButton = UIFactory.createButton();
            mainMenuList.Add(startButton);
            mainMenuList.Add(versusButton);
            mainMenuList.Add(mapEditorButton);
            mainMenuList.Add(configScreenButton);
            mainMenuList.Add(creditsButton);
            Menu mainMenu = new Menu(mainMenuList,null);//TODO
            return mainMenu;
        }




    }
}