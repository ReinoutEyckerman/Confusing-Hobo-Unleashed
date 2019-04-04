using System;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class UIFactory
    {
        public static Button createDefaultButton(string text, TriggerEventHandler triggerEventHandler, Position position)
        {
            Shape box = createDefaultBox(position);
            Shape bounds = createDefaultBoxBounds(position, box);
            Shape textShape = createDefaultText(text, position, bounds);
            return new Button(triggerEventHandler, textShape.toImage());
        }

        public static Shape createDefaultBox(Position position, Shape rootShape = null)
        {
            Pixel pixel = new Pixel(BaseColor.DarkGreen, BaseColor.White, ' ');
            Shape shape = new BoxBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setPixel(pixel)
                .setRootShape(rootShape)
                .Build();
            return shape;
        }

        public static Shape createDefaultBoxBounds(Position position, Shape rootShape = null)
        {
            Pixel pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            Shape shape = new BoxBuilder()
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setPixel(pixel)
                .setRootShape(rootShape)
                .Build();
            return shape;
        }

        public static Shape createDefaultText(string text, Position position, Shape rootShape = null)
        {
            Pixel pixel = new Pixel(BaseColor.Green, BaseColor.White, ' ');
            Shape shape = new TextBuilder()
                .setText(text)
                .setWidthPercentageOfScreen(10)
                .setHeigthPercentageOfScreen(10)
                .setPosition(position)
                .setPixel(pixel)
                .setRootShape(rootShape)
                .Build();
            return shape;
        }
    }
}