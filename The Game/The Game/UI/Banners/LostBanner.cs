using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class LostBanner
    {

        private Text lostBanner;

        public LostBanner(Position position, ColorPoint colorPoint)
        {
            string a = @"    _                                _    _      _ _     _                 _ _     ";
            string b = @"   /_\__ __ ____ __ __   __ ___ _  _| |__| |_ _ ( ) |_  | |_  __ _ _ _  __| | |___ ";
            string c = @"  / _ \ V  V /\ V  V /  / _/ _ \ || | / _` | ' \|/|  _| | ' \/ _` | ' \/ _` | / -_)";
            string d = @" /_/ \_\_/\_/  \_/\_( ) \__\___/\_,_|_\__,_|_||_|  \__| |_||_\__,_|_||_\__,_|_\___|";
            string e = @"  _   _          _  |/     _      ___ ";
            string f = @" | |_| |_  ___  | |__  ___| |_ __|__ \ ";
            string g = @" |  _| ' \/ -_) | '_ \/ _ \  _(_-< /_/";
            string h = @"  \__|_||_\___| |_.__/\___/\__/__/(_) ";
            Text aText= new Text(a,null, colorPoint,null, position);//TODO
            position.setX(position.x + 1);
            Text bText= new Text(b,aText,colorPoint,null, position);//TODO
            position.setX(position.x + 1);
            Text cText= new Text(c,bText,colorPoint,null,position);//TODO
            position.setX(position.x + 1);
            Text dText= new Text(d,cText,colorPoint,null,position);//TODO
            position.setX(position.x + 1);
            Text eText= new Text(e,dText,colorPoint,null,position);//TODO
            position.setX(position.x + 1);
            Text fText= new Text(f,eText,colorPoint,null,position);//TODO
            position.setX(position.x + 1);
            Text gText= new Text(g,fText,colorPoint,null,position);//TODO
            position.setX(position.x + 1);
            Text hText= new Text(h,gText,colorPoint,null,position);//TODO
            
            this.lostBanner = gText;
        }
    }
}