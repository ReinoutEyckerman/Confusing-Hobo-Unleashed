using System;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class GameOverlay:Drawable
    {
        private string playername;
        private LoadBar hp;
        public GameOverlay(string playername)
        {
            
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void DrawRelative(Position relativeTo)
        {
            throw new NotImplementedException();
        }
    }
}