using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class MapView : UIObject
    {//TODO Player drawing
        private Overview map;

        public MapView(Overview map, Position position, Image image) : base(position, image)
        {
        }

        public MapView(Overview map, Position position, Image activeImage, Image inactiveImage) : base(position,
            activeImage, inactiveImage)
        {
        }

        public override void HandleAction(Input action)
        {
            throw new System.NotImplementedException();
        }
    }
}