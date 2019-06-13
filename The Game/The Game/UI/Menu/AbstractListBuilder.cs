using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI
{
    public class AbstractListBuilder
    {
        private readonly CircularList<UIObject> items;
        private readonly int padding;

        public AbstractListBuilder(int padding = 0)
        {
            items = new CircularList<UIObject>();
            this.padding = padding;
        }

        public AbstractListBuilder addUIObject(UIObject uiObject)
        {
            items.Add(uiObject);
            return this;
        }

        public AbstractList buildHorizontal()
        {
            var boundsHorizontal = growBoundsHorizontal(items, padding);
            var image = generateImage(boundsHorizontal);
            return new HorizonalList(items, image);
        }

        public AbstractList buildVertical()
        {
            var boundsVertical = growBoundsVertical(items, padding);
            var image = generateImage(boundsVertical);
            return new VerticalList(items, image);
        }

        public AbstractList buildDiagonal()
        {
            throw new NotImplementedException();
        }

        private static Image generateImage(BoundingBox bounds)
        {
            var pixel = new Pixel(BaseColor.DarkRed, BaseColor.White, ' ');

            var regularShape = new ShapeBuilder()
                .setType(typeof(RegularRectangle))
                .setPosition(bounds.getPosition())
                .setWidth(bounds.getWidth())
                .setHeight(bounds.getHeight())
                .Build();
            var image = new FilledShapeDrawer(regularShape, pixel).toImage();
            pixel = new Pixel(BaseColor.Red, BaseColor.White, '|');
            image = image.addTopLayer(new ContouredShapeDrawer(regularShape, pixel));
            return image;
        }

        private static BoundingBox growBoundsHorizontal(List<UIObject> uiObjects, int padding)
        {
            var bounds = new BoundingBox(padding, padding);
            foreach (var uiObject in uiObjects)
            {
                uiObject.Reposition(new Position(bounds.getWidth(), padding));
                var uiHeight = uiObject.getBoundingBox().getHeight();
                var height = bounds.getHeight() - padding * 2 > uiHeight ? 0 : uiHeight;
                bounds = bounds.enlarge(uiObject.getBoundingBox().getWidth() + padding, height);
            }

            return bounds;
        }

        private static BoundingBox growBoundsVertical(List<UIObject> uiObjects, int padding)
        {
            var bounds = new BoundingBox(padding * 2, padding * 2);
            foreach (var uiObject in uiObjects)
            {
                uiObject.Reposition(new Position(bounds.getWidth(), padding));
                var uiWidth = uiObject.getBoundingBox().getWidth();
                var width = bounds.getWidth() - padding * 2 > uiWidth ? 0 : uiWidth;
                bounds = bounds.enlarge(width, uiObject.getBoundingBox().getHeight() + padding);
            }

            return bounds;
        }

        private static BoundingBox growBounds2D(List<UIObject> uiObjects, int padding, int maxWidth)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}