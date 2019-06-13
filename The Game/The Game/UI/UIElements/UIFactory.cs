using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class UIFactory
    {
        public static Button
            createDefaultRelativeButton(string text, TriggerEventHandler triggerEventHandler) //TODO Check positioning
        {
            var position = new Position(0, 0);
            var image = createDefaultBox(position);
            image = createDefaultBoxBounds(position, image);
            image = createDefaultText(text, position, image);
            return new Button(triggerEventHandler, position, image);
        }

        public static Image createDefaultBox(Position position, Image rootImage = null)
        {
            var pixel = new Pixel(BaseColor.DarkGreen, BaseColor.White, ' ');
            var shape = new ShapeBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setType(typeof(RegularRectangle))
                .Build();
            var drawer = new FilledShapeDrawer(shape, pixel);
            if (rootImage != null) return rootImage.addTopLayer(drawer);

            return drawer.toImage();
        }

        public static Image createDefaultBoxBounds(Position position, Image rootImage = null)
        {
            var pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            var shape = new ShapeBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setType(typeof(RegularRectangle))
                .Build();
            var drawer = new ContouredShapeDrawer(shape, pixel);
            if (rootImage != null) return rootImage.addTopLayer(drawer);

            return drawer.toImage();
        }

        public static Image createDefaultText(string text, Position position, Image rootImage = null)
        {
            var pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            var textImage = new Text(text, pixel, position).toImage();
            return textImage;
        }
    }
}