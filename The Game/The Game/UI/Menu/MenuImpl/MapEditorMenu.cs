using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorMenu:Menu
    {
        
        public MapEditorMenu()
        {
            CircularList<UIObject> mapEditorList = new CircularList<UIObject>();
            UIObject newMap = UIFactory.createButton();
            UIObject loadMap = UIFactory.createButton();
            mapEditorList.Add(newMap);
            mapEditorList.Add(loadMap);
            this.root= new GridMenu(mapEditorList,null);
            
           /*new Button {Message = "Start New Map", BlockHeight = Console.WindowHeight/9, Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*0},
            new Button {BlockHeight = Console.WindowHeight/9, Message = "Load Map From File", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*1}}}};
            */
        }
    }
}