using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class CongratulationsBanner : Drawable //TODO Large letter generator?
    {
        private Image congratulationsBanner;

        public CongratulationsBanner(Position position, ColorPoint colorPoint)
        {
            string a = @"   ____                            _         _       _   _";
            string b = @"  / ___|___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___";
            string c = @" | |   / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __|";
            string d = @" | |__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \ ";
            string e = @"  \____\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/";
            string f = @"                   |___/                                                 ";
            string g = @"And now complete the game on a harder difficulty!";

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

            this.congratulationsBanner = aText.toImage()
                .addTopLayer(bText)
                .addTopLayer(cText)
                .addTopLayer(dText)
                .addTopLayer(eText)
                .addTopLayer(fText)
                .addTopLayer(gText);
        }

        public void Draw()
        {
            this.congratulationsBanner.Draw();
        }
    }
}