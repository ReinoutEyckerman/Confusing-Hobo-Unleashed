using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public abstract class AbstractList : UIObject
    {
        protected CircularList<UIObject> items;

        private int ringIndex = 0;

        protected AbstractList(CircularList<UIObject> uiObjects, Image image) : base(image.getPosition(), image)
        {
        }

        protected AbstractList(CircularList<UIObject> items, Position position, Image image) : base(position, image)
        {
            this.items = items;
        }

        protected AbstractList(CircularList<UIObject> items, Position position, Image activeImage, Image inactiveImage)
            : base(position, activeImage, inactiveImage)
        {
            this.items = items;
        }

        public override void Draw()
        {
            base.Draw();
            DrawItems();
        }

        private void DrawItems()
        {
            foreach (var uiObject in items) uiObject.Draw();
        }
    }
}