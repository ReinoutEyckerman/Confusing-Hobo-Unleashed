using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorNewMapMenu:Menu
    {
        
        public MapEditorNewMapMenu()
        {
            CircularList<UIObject> mapEditorNewMapList = new CircularList<UIObject>();
            UIObject genClouds = UIFactory.createButton();
            UIObject genSKy = UIFactory.createButton();
            UIObject cont = UIFactory.createButton();
            mapEditorNewMapList.Add(genClouds);
            mapEditorNewMapList.Add(genSKy);
            mapEditorNewMapList.Add(cont);
            this.root =new GridMenu(mapEditorNewMapList,null);//TODO
            /*
             * new Button {Message = "Gen Clouds Ingame", BlockHeight = Console.WindowHeight/9, Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*0},
             * new Button {BlockHeight = Console.WindowHeight/9, Message = "Gen Sky Ingame", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*1},
             * new Button {BlockHeight = Console.WindowHeight/9, Message = "Continue", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*2}}}};
             */
        }
    }
}