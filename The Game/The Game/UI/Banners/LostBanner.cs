using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class LostBanner
    {
        private Image lostBanner;

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
            Text aText = new Text(a, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text bText = new Text(b, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text cText = new Text(c, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text dText = new Text(d, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text eText = new Text(e, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text fText = new Text(f, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text gText = new Text(g, colorPoint, position); //TODO
            position.setX(position.x + 1);
            Text hText = new Text(h, colorPoint, position); //TODO check object copy shit

            this.lostBanner = aText.toImage()
                .addTopLayer(bText)
                .addTopLayer(cText)
                .addTopLayer(dText)
                .addTopLayer(eText)
                .addTopLayer(fText)
                .addTopLayer(gText)
                .addTopLayer(hText);
        }
    }
}