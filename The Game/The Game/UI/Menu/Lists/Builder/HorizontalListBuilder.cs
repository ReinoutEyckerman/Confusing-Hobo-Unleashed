using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class HorizontalListBuilder : AbstractListBuilder
    {
        public HorizontalListBuilder(int padding = 0) : base(padding)
        {
        }

        public override AbstractList build()
        {
            BoundingBox bounds = growBoundsHorizontal(items, padding);
            Image image = GenerateListImage(bounds);
            positionObjects(items, padding, bounds);
            return new HorizonalList(items, image);
        }

        private static BoundingBox growBoundsHorizontal(List<UIObject> uiObjects, int padding)
        {
            int width = getTotalWidth(uiObjects) + padding * (uiObjects.Count + 1);
            int height = getLargestHeight(uiObjects);
            return new BoundingBox(width, height);
        }

        private static void positionObjects(List<UIObject> uiObjects, int padding, BoundingBox bounds)
        {
            int x = padding;
            int height = bounds.getHeight();
            foreach (UIObject uiObject in uiObjects)
            {
                int y = (height - uiObject.getBoundingBox().getHeight()) / 2;
                uiObject.Reposition(new Position(x, y));
                x += padding + uiObject.getBoundingBox().getWidth();
            }
        }
    }
}