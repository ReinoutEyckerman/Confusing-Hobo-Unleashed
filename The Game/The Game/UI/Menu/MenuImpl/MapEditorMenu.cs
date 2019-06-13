using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorMenu : Menu
    {
        public MapEditorMenu()
        {
            var mapEditorList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Start New Map", StartNewMap))
                .addUIObject(UIFactory.createDefaultRelativeButton("Load Map From File", LoadMap))
                .buildVertical();
            root = mapEditorList;
        }

        private void StartNewMap()
        {
            throw new NotImplementedException();
        }

        private void LoadMap()
        {
            throw new NotImplementedException();
        }
    }
}