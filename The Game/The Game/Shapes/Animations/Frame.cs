using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.Shapes.Animations
{
    public class Frame : Image
    {
        private int duration; //TODO ms?

        public Frame(Position position, int width, int height) : base(position, width, height)
        {
        }

        public Frame(Pixel[,] imageGrid, Position position) : base(imageGrid, position)
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