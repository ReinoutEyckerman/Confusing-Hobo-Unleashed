using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes.Animations
{
    public class Frame : Image
    {
        private int duration; //TODO ms?


        public Frame(Pixel[,] imageGrid, Position position, Window window) : base(imageGrid, position, window)
        {
        }

        public void setDuration()
        {
            duration = duration;
        }

        public int getDuration()
        {
            return duration;
        }
    }
}