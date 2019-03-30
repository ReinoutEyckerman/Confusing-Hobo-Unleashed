using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class Title:Drawable//TODO Large letter generator?
    {
        private Text title;

        public Title(Position position, ColorPoint colorPoint)
        {
            string a = @"   ______            ____           _                __  __      __             __  __      __                __             __";
            string b = @"  / ____/___  ____  / __/_  _______(_)___  ____ _   / / / /___  / /_  ____     / / / /___  / /__  ____ ______/ /_  ___  ____/ /";
            string c = @" / /   / __ \/ __ \/ /_/ / / / ___/ / __ \/ __ `/  / /_/ / __ \/ __ \/ __ \   / / / / __ \/ / _ \/ __ `/ ___/ __ \/ _ \/ __  / ";
            string d = @"/ /___/ /_/ / / / / __/ /_/ (__  ) / / / / /_/ /  / __  / /_/ / /_/ / /_/ /  / /_/ / / / / /  __/ /_/ (__  ) / / /  __/ /_/ / ";
            string e = @"\____/\____/_/ /_/_/  \__,_/____/_/_/ /_/\__, /  /_/ /_/\____/_.___/\____/   \____/_/ /_/_/\___/\__,_/____/_/ /_/\___/\__,_/ ";
            string f = @"                                        /____/";
            
            Text aText= new Text(a,position,colorPoint,null);//TODO
            position.setX(position.x + 1);
            Text bText= new Text(b,position,colorPoint,aText);//TODO
            position.setX(position.x + 1);
            Text cText= new Text(c,position,colorPoint,bText);//TODO
            position.setX(position.x + 1);
            Text dText= new Text(d,position,colorPoint,cText);//TODO
            position.setX(position.x + 1);
            Text eText= new Text(e,position,colorPoint,dText);//TODO
            position.setX(position.x + 1);
            Text fText= new Text(f,position,colorPoint,eText);//TODO
            
            this.title = fText;

        }
        public void Draw()
        {
            title.Draw();
        }
    }
}