using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class CongratulationsBanner : AbstractBanner //TODO Large letter generator?
    {
        private Image congratulationsBanner;

        public CongratulationsBanner(Position position, ColorPoint colorPoint)
        {
            List<String> stringlist = new List<String>();
            stringlist.Add(@"   ____                            _         _       _   _");
            stringlist.Add(@"  / ___|___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___");
            stringlist.Add(@" | |   / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __|");
            stringlist.Add(@" | |__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \ ");
            stringlist.Add(@"  \____\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/");
            stringlist.Add(@"                   |___/                                                 ");
            stringlist.Add(@"And now complete the game on a harder difficulty!");

            this.Initialize(stringlist,position,colorPoint);
        }
    }
}