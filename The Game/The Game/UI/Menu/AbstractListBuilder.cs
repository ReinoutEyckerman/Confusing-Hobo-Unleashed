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
            int width = getTotalWidth(uiObjects)+padding*(uiObjects.Count+1);
            int height = getLargestHeight(uiObjects);
            int x = padding;
            foreach (UIObject uiObject in uiObjects)
            {
                int y = (height - uiObject.getBoundingBox().getHeight()) / 2;
                uiObject.Reposition(new Position(x,y));
                x += padding + uiObject.getBoundingBox().getWidth();

            }
            return new BoundingBox(width, height);
        }

        private static BoundingBox growBoundsVertical(List<UIObject> uiObjects, int padding)
        {
            int width = getLargestWidth(uiObjects);
            int height = getTotalHeight(uiObjects) + padding * (uiObjects.Count + 1);
            int y = padding;
            foreach (UIObject uiObject in uiObjects)
            {
                int x = (width - uiObject.getBoundingBox().getWidth()) / 2;
                uiObject.Reposition(new Position(x,y));
                y += padding + uiObject.getBoundingBox().getHeight();

            }
            return new BoundingBox(width, height);
        }
        

        private static BoundingBox growBounds2D(List<UIObject> uiObjects, int padding, int maxWidth)
        {
            throw new NotImplementedException();
            int width = 0;
            int height = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                if (uiObject.getBoundingBox().getWidth() + width > maxWidth)
                {
                       
                }
                else
                {
                    width += uiObject.getBoundingBox().getWidth();
                }
            }
        }
        
        private static void AllocateHorizontal(List<UIObject> uiObjects, Int32 maxWidth=Int32.MaxValue;)
        {
            int totalWidth = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                totalWidth += uiObject.getBoundingBox().getWidth();
            }
            
        }
        
        private static int getTotalWidth(List<UIObject> uiObjects, Int32 maxWidth = Int32.MaxValue)
        {
            int totalWidth = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                totalWidth += uiObject.getBoundingBox().getWidth();
            }
            return totalWidth;
        }
        private static int getTotalHeight(List<UIObject> uiObjects)
        {
            int totalHeight = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                totalHeight += uiObject.getBoundingBox().getHeight();
            }
            return totalHeight;
        }

        private static int getLargestWidth(List<UIObject> uiObjects) //TODO Can we mmerge this with largestHeight?
        {
            //TODO LINQ?
            int maxWidth = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                if (uiObject.getBoundingBox().getWidth() > maxWidth)
                    maxWidth = uiObject.getBoundingBox().getWidth();
            }

            return maxWidth;
        }

        private static int getLargestHeight(List<UIObject> uiObjects)
        {
            int maxHeight = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                if (uiObject.getBoundingBox().getHeight() > maxHeight)
                    maxHeight = uiObject.getBoundingBox().getHeight();
            }

            return maxHeight;
        }
    }
}