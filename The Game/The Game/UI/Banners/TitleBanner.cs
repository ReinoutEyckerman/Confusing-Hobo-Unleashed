using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class TitleBanner : AbstractBanner //TODO Large letter generator?
    {
        public TitleBanner(Position position, ColorPoint colorPoint)
        {
            List<string> stringlist = new List<string>();
            stringlist.Add(@"   ______            ____           _                __  __      __             __  __      __                __             __");
            stringlist.Add(@"  / ____/___  ____  / __/_  _______(_)___  ____ _   / / / /___  / /_  ____     / / / /___  / /__  ____ ______/ /_  ___  ____/ /");
            stringlist.Add(@" / /   / __ \/ __ \/ /_/ / / / ___/ / __ \/ __ `/  / /_/ / __ \/ __ \/ __ \   / / / / __ \/ / _ \/ __ `/ ___/ __ \/ _ \/ __  / ");
            stringlist.Add(@"/ /___/ /_/ / / / / __/ /_/ (__  ) / / / / /_/ /  / __  / /_/ / /_/ / /_/ /  / /_/ / / / / /  __/ /_/ (__  ) / / /  __/ /_/ / ");
            stringlist.Add(@"\____/\____/_/ /_/_/  \__,_/____/_/_/ /_/\__, /  /_/ /_/\____/_.___/\____/   \____/_/ /_/_/\___/\__,_/____/_/ /_/\___/\__,_/ ");
            stringlist.Add(@"                                        /____/");

            this.Initialize(stringlist, position, colorPoint);
        }
    }
}