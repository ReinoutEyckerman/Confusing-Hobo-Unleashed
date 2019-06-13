using System;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapEditorNewMapMenu : Menu
    {
        public MapEditorNewMapMenu()
        {
            var mapEditorNewMapList = new AbstractListBuilder()
                .addUIObject(UIFactory.createDefaultRelativeButton("Gen Clouds InGame", setCloudGeneration))
                .addUIObject(UIFactory.createDefaultRelativeButton("Gen Sky Ingame", setSkyGeneration))
                .addUIObject(UIFactory.createDefaultRelativeButton("Continue", Continue))
                .buildVertical();
            root = mapEditorNewMapList;
        }

        private void setCloudGeneration()
        {
            throw new NotImplementedException();
        }

        private void setSkyGeneration()
        {
            throw new NotImplementedException();
        }

        private void Continue()
        {
            throw new NotImplementedException();
        }
    }
}