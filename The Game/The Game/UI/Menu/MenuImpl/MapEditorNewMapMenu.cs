using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorNewMapMenu : Menu
    {
        public MapEditorNewMapMenu()
        {
            AbstractList mapEditorNewMapList = new VerticalListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Gen Clouds InGame", setCloudGeneration))
                .addUIObject(UIFactory.createDefaultRelativeButton("Gen Sky Ingame", setSkyGeneration))
                .addUIObject(UIFactory.createDefaultRelativeButton("Continue", Continue))
                .build();
            root = mapEditorNewMapList;
        }

        private void setCloudGeneration(object parameter)
        {
            throw new NotImplementedException();
        }

        private void setSkyGeneration(object parameter)
        {
            throw new NotImplementedException();
        }

        private void Continue(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}