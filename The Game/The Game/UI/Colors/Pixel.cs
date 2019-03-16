using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.Colors
{
    public class Pixel : ColorPoint
    {

        private readonly char character;

        public Pixel(BaseColor backgroundColor, BaseColor foregroundColor, char character): base(backgroundColor, foregroundColor)
        {
            this.character = character;
        }

        public char getCharacter()
        {
            return character;
        }
    }
}