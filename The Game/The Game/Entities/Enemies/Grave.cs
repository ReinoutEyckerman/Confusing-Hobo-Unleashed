using System.Text;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Menu.MenuImpl;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class Grave:Updateable
    {
        private Updateable _entity;
        private Updateable deadEntity;
        private static readonly int maxHp =15;
        private static readonly Pixel design = new Pixel(BaseColor.DarkGray, BaseColor.White, Encoding.GetEncoding(437).GetChars(new byte[] {127})[0]);

        private static readonly ShapedImage shape = new ShapedImage(
            AbstractUIFactory.getInstance().buildImage(new[,] {{design}}),
            new RegularRectangle(new Position(0, 0), 1, 1)); //TODO Fix this position problem!

        public Grave(Difficulty difficulty, Updateable deadEntity )
        {
            _entity = new Entity(maxHp, shape);
        }

        public void Resurrect()
        {
            
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}