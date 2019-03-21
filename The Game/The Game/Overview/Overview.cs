using System.Runtime.CompilerServices;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Overview:Drawable
    {
        private Chamber[,] _chamberGrid;

        public Overview(int width, int height)
        {
            _chamberGrid = new Chamber[width,height];
        }


        public void Draw()//TODO incomplete
        {
            foreach (Chamber chamber in _chamberGrid)
            {
                chamber.Draw();
            }
        }
    }
}