using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;

namespace Confusing_Hobo_Unleashed
{
    public class Background
    {
        private Image background;
        private Dictionary<int, List<Drawable>> overlays;

        public Background()
        {
            this.background = null;
            this.overlays=new Dictionary<int, List<Drawable>>();
        }

        private void setBackground(Image background)
        {
            this.background = background;
        }

        private void addOverlay(int priority, Drawable drawable)
        {
            this.overlays.Add(priority, );
        }
    }
}