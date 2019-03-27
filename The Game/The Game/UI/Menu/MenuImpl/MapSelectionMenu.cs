using System;
using System.Collections.Generic;
using System.IO;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapSelectionMenu
    {

        public MapSelectionMenu()
        {
            string[] files = Directory.GetFileSystemEntries("maps", "*.xml");
            List<UIObject> items= new List<UIObject>();
            for (var x = 0; x < files.Length; x++)
            {
                items.Add(new Button());
            }
        }
        
            
    }
}