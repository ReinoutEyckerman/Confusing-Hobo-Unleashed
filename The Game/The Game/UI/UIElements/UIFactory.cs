using System;
using System.Net.Mime;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class UIFactory
    {
        public static Image generateImage(CircularList<UIObject> objects, int padding)
        {
            Pixel pixel = new Pixel(BaseColor.DarkRed, BaseColor.White, ' ');
            BoundingBox bounds = null;
            foreach (UIObject uiObject in objects)
            {
                if (bounds == null)
                {
                    bounds = uiObject.getBoundingBox();
                }
                else
                {
                    bounds = bounds.grow(uiObject.getBoundingBox());
                }
            }

            bounds.grow(padding);
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

        public static Button createDefaultButton(string text, TriggerEventHandler triggerEventHandler, Position position)//TODO Check positioning
        {
            Image image = createDefaultBox(position);
            image = createDefaultBoxBounds(position, image);
            image = createDefaultText(text, position, image);
            return new Button(triggerEventHandler,position, image);
        }

        public static Image createDefaultBox(Position position, Image rootImage = null)
        {
            Pixel pixel = new Pixel(BaseColor.DarkGreen, BaseColor.White, ' ');
            RegularShape shape = new ShapeBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setType(typeof(RegularRectangle))
                .Build();
            FilledShapeDrawer drawer = new FilledShapeDrawer(shape, pixel);
            if (rootImage != null)
            {
                return rootImage.addTopLayer(drawer);
            }

            return drawer.toImage();
        }

        public static Image createDefaultBoxBounds(Position position, Image rootImage = null)
        {
            Pixel pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            RegularShape shape = new ShapeBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setType(typeof(RegularRectangle))
                .Build();
            ContouredShapeDrawer drawer = new ContouredShapeDrawer(shape, pixel);
            if (rootImage != null)
            {
                return rootImage.addTopLayer(drawer);
            }

            return drawer.toImage();
        }

        public static Image createDefaultText(string text, Position position, Image rootImage = null)
        {
            Pixel pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            Image textImage = new Text(text, pixel, position).toImage();
            return textImage;
        }
    }
}