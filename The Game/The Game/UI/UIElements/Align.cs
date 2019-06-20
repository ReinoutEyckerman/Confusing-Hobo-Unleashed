using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public static class Align
    {
        public static void AlignUI(BoundingBox bounds, UIObject uiObject, int padding, Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.TopLeft:
                    AlignTopLeft(bounds, uiObject);
                    break;
            }
        }

        private static void AlignTopLeft(BoundingBox boundingBox, UIObject uiObject, int padding)
        {
        }

        private static void alignLeft(BoundingBox boundingBox, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                boundingBox.getPosition().x,
                uiObject.getBoundingBox().getPosition().y));
        }

        private static void horizontalAlignCenter(BoundingBox bounds, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                bounds.getPositionalCenter().x / 2 - uiObject.getBoundingBox().getPositionalCenter().x / 2,
                uiObject.getBoundingBox().getPosition().y));
        }

        private static void alignRight(BoundingBox boundingBox, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                boundingBox.getPosition().x + boundingBox.getWidth() - uiObject.getBoundingBox().getWidth(),
                uiObject.getBoundingBox().getPosition().y));
        }

        private static void alignTop(BoundingBox boundingBox, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                uiObject.getBoundingBox().getPosition().x,
                boundingBox.getPosition().y));
        }

        private static void verticalAlignCenter(BoundingBox bounds, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                uiObject.getBoundingBox().getPosition().x,
                bounds.getPositionalCenter().y / 2 - uiObject.getBoundingBox().getPositionalCenter().y / 2));
        }

        private static void alignBottom(BoundingBox boundingBox, UIObject uiObject)
        {
            uiObject.Reposition(new Position(
                uiObject.getBoundingBox().getPosition().x,
                boundingBox.getPosition().y + boundingBox.getHeight()() - uiObject.getBoundingBox().getHeight()));
        }
    }
}