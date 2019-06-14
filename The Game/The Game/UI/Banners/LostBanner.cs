using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class LostBanner : AbstractBanner
    {
        public LostBanner(Position position, ColorPoint colorPoint)
        {
            List<string> stringlist = new List<string>();
            stringlist.Add(@"    _                                _    _      _ _     _                 _ _     ");
            stringlist.Add(@"   /_\__ __ ____ __ __   __ ___ _  _| |__| |_ _ ( ) |_  | |_  __ _ _ _  __| | |___ ");
            stringlist.Add(@"  / _ \ V  V /\ V  V /  / _/ _ \ || | / _` | ' \|/|  _| | ' \/ _` | ' \/ _` | / -_)");
            stringlist.Add(@" /_/ \_\_/\_/  \_/\_( ) \__\___/\_,_|_\__,_|_||_|  \__| |_||_\__,_|_||_\__,_|_\___|");
            stringlist.Add(@"  _   _          _  |/     _      ___ ");
            stringlist.Add(@" | |_| |_  ___  | |__  ___| |_ __|__ \ ");
            stringlist.Add(@" |  _| ' \/ -_) | '_ \/ _ \  _(_-< /_/");
            stringlist.Add(@"  \__|_||_\___| |_.__/\___/\__/__/(_) ");

            this.Initialize(stringlist, position, colorPoint);
        }
    }
}