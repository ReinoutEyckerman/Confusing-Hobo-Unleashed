using System;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;

namespace Confusing_Hobo_Unleashed.UI
{
    public abstract class AbstractUIFactory
    {
        public abstract Window createWindow();
        public abstract Image buildImage(Pixel[,] imageGrid, Position position);

        protected static AbstractUIFactory instance;

        public static void setInstance(AbstractUIFactory abstractUiFactory)
        {
            instance = abstractUiFactory;
        }

        public static AbstractUIFactory getInstance()
        {
            if (instance == null)
            {
                throw new NotImplementedException();
            }

            return instance;
        }
    }
}