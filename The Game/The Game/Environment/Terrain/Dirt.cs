using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Dirt : Updateable
    {
        private Updateable _entity;

        private static readonly int maxHp = 4;
        private static readonly Pixel[,] design = {{new Pixel(BaseColor.DarkRed, BaseColor.Void, ' ')}};

        private static readonly ShapedImage shape = new ShapedImage(
            AbstractUIFactory.getInstance().buildImage(design),
            new RegularRectangle(new Position(0, 0), 1, 1)); //TODO Fix this position problem!

        public Dirt()
        {
            _entity = new Entity(maxHp, shape);
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}