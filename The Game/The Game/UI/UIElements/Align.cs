using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public static class Align
    {
        public static void AlignUI(BoundingBox bounds, List<UIObject> uiObjects, int padding, Alignment alignment)
        {
            List<UIObject> uiObjectsCopy = new List<UIObject>();
            uiObjectsCopy.AddRange(uiObjects);
            
            while (uiObjectsCopy.Count > 0)
            {
                int rowFitCount = Align.rowFitCount(bounds, uiObjects, padding);
                List<UIObject> objects = uiObjectsCopy.GetRange(0, rowFitCount);
                int height = minHeightCount(bounds, objects, padding);
            }
        }

        private static void executeAlignment(BoundingBox bounds,  UIObject uiObject, Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.TopLeft:
                    alignTop(bounds,uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.TopCenter:
                    alignTop(bounds, uiObject);
                    horizontalAlignCenter(bounds,uiObject);
                    break;
                case Alignment.TopRight:
                    alignTop(bounds,uiObject);
                    alignRight(bounds,uiObject);
                    break;
                case Alignment.CenterLeft:
                    verticalAlignCenter(bounds,uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.Center:
                    verticalAlignCenter(bounds,uiObject);
                    horizontalAlignCenter(bounds,uiObject);
                    break;
                case Alignment.CenterRight:
                    verticalAlignCenter(bounds,uiObject);
                    alignRight(bounds,uiObject);
                    break;
                case Alignment.BottomLeft:
                    alignTop(bounds,uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.BottomCenter:
                    alignBottom(bounds, uiObject);
                    horizontalAlignCenter(bounds,uiObject);
                    break;
                case Alignment.BottomRight:
                    alignBottom(bounds,uiObject);
                    alignRight(bounds,uiObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null);
            }
        }
        

        private static int rowFitCount(BoundingBox bounds, List<UIObject> uiObjects, int padding)
        {
            int maxWidth = bounds.getWidth();
            int width = padding;
            int i = 0;
            while (width < maxWidth)
            {
                width += uiObjects[i++].getBoundingBox().getWidth() + padding;
            }

            return i;
        }

        private static int minHeightCount(BoundingBox bounds, List<UIObject> uiObjects, int padding)
        {
            int minHeight = 0;
            foreach (UIObject uiObject in uiObjects)
            {
                int height = uiObject.getBoundingBox().getHeight();
                if (minHeight < height)
                {
                    minHeight = height;
                }
            }

            return minHeight + 2 * padding;
        }


        public static void AlignUI(BoundingBox bounds, UIObject uiObject, int padding, Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.TopLeft:
                    AlignTopLeft(bounds, uiObject);
                    break;
            }
        }

        private static void AlignUI(BoundingBox boundingBox, UIObject uiObject, int padding)
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