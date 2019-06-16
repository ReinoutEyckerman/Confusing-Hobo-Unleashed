using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI
{
    public class VerticalListBuilder : AbstractListBuilder
    {
        public VerticalListBuilder(int padding = 0) : base(padding)
        {
        }

        public override AbstractList build()
        {
            BoundingBox bounds = growBounds(items, padding);
            Image image = GenerateListImage(bounds);
            positionObjects(items, padding, bounds);
            return new VerticalList(items, image);
        }

        private static BoundingBox growBounds(List<UIObject> uiObjects, int padding)
        {
            int width = getLargestWidth(uiObjects);
            int height = getTotalHeight(uiObjects) + padding * (uiObjects.Count + 1);
            return new BoundingBox(width, height);
        }

        private static void positionObjects(List<UIObject> uiObjects, int padding, BoundingBox bounds)
        {
            int y = padding;
            int width = bounds.getWidth();
            foreach (UIObject uiObject in uiObjects)
            {
                int x = (width - uiObject.getBoundingBox().getWidth()) / 2;
                uiObject.Reposition(new Position(x, y));
                y += padding + uiObject.getBoundingBox().getHeight();
            }
        }
    }
}