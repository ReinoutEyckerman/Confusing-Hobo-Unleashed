using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.Colors
{
    public class Pixel : ColorPoint //TODO Flyweight
    {
        private char character;

        public Pixel():base()
        {
            this.character = ' ';
        }
        public Pixel(Pixel copy) : base(copy)
        {
            this.character = copy.character;
        }

        public Pixel(BaseColor backgroundColor, BaseColor foregroundColor, char character) : base(backgroundColor,
            foregroundColor)
        {
            this.character = character;
        }

        public char getCharacter()
        {
            return character;
        }

        public Pixel add(Pixel pixel)
        {
            ColorPoint c = base.add(pixel);
            return new Pixel(c.GetBackgroundColor(), c.GetForegroundColor(), pixel.character);
        }
    }
}