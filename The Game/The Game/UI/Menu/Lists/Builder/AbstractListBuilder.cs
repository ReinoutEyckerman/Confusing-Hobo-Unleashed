using System;
using System.Collections.Generic;
using System.Linq;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI
{
    public abstract class AbstractListBuilder
    {
        protected readonly CircularList<UIObject> items;
        protected readonly int padding;

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

        public abstract AbstractList build();

        protected static Image GenerateListImage(BoundingBox bounds) //TODO add pixel
        {
            Pixel pixel = new Pixel(BaseColor.DarkRed, BaseColor.White, ' ');

            RegularShape regularShape = new ShapeBuilder()
                .setType(typeof(RegularRectangle))
                .setPosition(bounds.getPosition())
                .setWidth(bounds.getWidth())
                .setHeight(bounds.getHeight())
                .Build();
            Image image = new FilledShapeDrawer(regularShape, pixel).toImage();
            pixel = new Pixel(BaseColor.Red, BaseColor.White, '|');
            image = image.addTopLayer(new ContouredShapeDrawer(regularShape, pixel));
            return image;
        }


        private static BoundingBox growBounds2D(List<UIObject> uiObjects, int padding, int maxWidth)
        {
            throw new NotImplementedException();
            int width = 0;
            int height = 0;
            foreach (UIObject uiObject in uiObjects)
                if (uiObject.getBoundingBox().getWidth() + width > maxWidth)
                {
                }
                else
                {
                    width += uiObject.getBoundingBox().getWidth();
                }
        }

        protected static int getTotalWidth(List<UIObject> uiObjects)
        {
            return uiObjects.Select(o => o.getBoundingBox().getWidth()).Sum();
        }

        protected static int getTotalHeight(List<UIObject> uiObjects)
        {
            return uiObjects.Select(o => o.getBoundingBox().getHeight()).Sum();
        }

        protected static int getLargestWidth(List<UIObject> uiObjects)
        {
            return uiObjects.Select(o => o.getBoundingBox().getWidth()).Max();
        }

        protected static int getLargestHeight(List<UIObject> uiObjects)
        {
            return uiObjects.Select(o => o.getBoundingBox().getHeight()).Max();
        }
    }
}