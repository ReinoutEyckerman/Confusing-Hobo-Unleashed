using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.Menu
{
    public class GridMenu : AbstractList
    {
        private int width;
        private int height;
        
        public GridMenu(int width, int height, CircularList<UIObject> items, Image image) : this(width, height,items, image, image)
        {
        } 
        
        public GridMenu(int width, int height,CircularList<UIObject> items, Image activeImage, Image inactiveImage) : base(items, activeImage, inactiveImage)
        {
            this.width = width;
            this.height = height;
        }
        
        public override void HandleAction(Input action)
        {
            if (isActive)
            {
                HandleActiveAction(action);
            }
            else
            {
                HandleInactiveAction(action);
            }
        }

        private void HandleActiveAction(Input action)
        {
            switch (action)
            {
                case Input.BACK:
                    this.isActive = false;
                    break;
                case Input.LEFT:
                     items.decrement();
                     break;
                case Input.RIGHT:
                     items.increment();
                     break;
                case Input.DOWN:
                    items.increment(width);
                    break;
                case Input.UP:
                    items.decrement(width);
                    break;
                default:
                     items.currentItem().HandleAction(action);
                     break;
            }
        }

        private void HandleInactiveAction(Input action)
        {
            switch (action)
            {
                case Input.A:
                    this.isActive = true;
                    break;
            }
        }
    }
}