using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class UIFactory
    {
        public static Button
            createDefaultRelativeButton(string text, ButtonTrigger buttonTrigger) //TODO Check positioning
        {
            Position position = new Position(0, 0);
            Image image = createDefaultBox(position);
            image = createDefaultBoxBounds(position, image);
            image = createDefaultText(text, position, image);
            return new Button(buttonTrigger, position, image);
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
            if (rootImage != null) return rootImage.addTopLayer(drawer);

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
            if (rootImage != null) return rootImage.addTopLayer(drawer);

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