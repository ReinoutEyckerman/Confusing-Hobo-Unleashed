using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public class MSConsoleUIFactory : AbstractUIFactory
    {
        private Window _window;

        public override Window createWindow()
        {
            this._window = new MicrosoftWindow();
            return _window;
        }

        public override Image buildImage(Pixel[,] imageGrid, Position position)
        {
            return new Image(imageGrid, position, _window);
        }

    }
}