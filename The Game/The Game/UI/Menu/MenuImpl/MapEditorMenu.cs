using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorMenu : Menu
    {
        public MapEditorMenu()
        {
            AbstractList mapEditorList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Start New Map", StartNewMap))
                .addUIObject(UIFactory.createDefaultRelativeButton("Load Map From File", LoadMap))
                .build();
            root = mapEditorList;
        }

        private void StartNewMap(object parameter)
        {
            throw new NotImplementedException();
        }

        private void LoadMap(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}