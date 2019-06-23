using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.UI.Colors;
using Microsoft.Xna.Framework;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public static class Align
    {
        public static void AlignUI(BoundingBox bounds, UIObject uiObject, int padding, Alignment alignment)
        {
            BoundingBox window = new BoundingBox(new Position(padding,padding),bounds.getWidth(),bounds.getHeight());
            executeAlignment(window, uiObject, alignment);
            removeRelativeBounds(bounds, window, uiObject);
            window.reposition(window.getPosition()
                .add(new Position(0, uiObject.getBoundingBox().getWidth() + padding)));
        }

        public static void AlignUI(BoundingBox bounds, List<UIObject> uiObjects, int padding, Alignment alignment)
        {
            int totalHeight = getTotalRequiredHeight(bounds, uiObjects, padding);
            checkHeightRequirements(bounds, totalHeight);
            int height = 0;
            switch (alignment)
            {
                case Alignment.CenterLeft:
                case Alignment.Center:
                case Alignment.CenterRight:
                    height = (bounds.getHeight() / 2) - (totalHeight / 2);
                    uiObjects.Insert(0,
                        new ImageFrame(bounds.getPosition(),
                            AbstractUIFactory.getInstance()
                                .buildImage(new Pixel[bounds.getWidth(),
                                    height]))); //TODO too obfuse for a simple padder?
                    break;
                case Alignment.BottomLeft:
                case Alignment.BottomCenter:
                case Alignment.BottomRight:
                    height = bounds.getHeight() - totalHeight;
                    uiObjects.Insert(0,
                        new ImageFrame(bounds.getPosition(),
                            AbstractUIFactory.getInstance()
                                .buildImage(new Pixel[bounds.getWidth(),
                                    height]))); //TODO too obfuse for a simple padder?
                    break;
            }

            alignInit(bounds, uiObjects, padding, alignment);
        }

        private static void alignInit(BoundingBox bounds, List<UIObject> uiObjects, int padding, Alignment alignment)
        {
            List<UIObject> uiObjectsCopy = new List<UIObject>();
            uiObjectsCopy.AddRange(uiObjects);
            BoundingBox window = new BoundingBox(new Position(padding, padding), bounds.getWidth(), bounds.getHeight());
            int height = 0;
            while (uiObjectsCopy.Count > 0)
            {
                int rowFitCount = Align.rowFitCount(bounds, uiObjects, padding);
                List<UIObject> objects = uiObjectsCopy.GetRange(0, rowFitCount);
                height += minHeightCount(bounds, objects, padding) + padding;
                foreach (UIObject uiObject in objects)
                {
                    executeAlignment(window, uiObject, alignment);
                    removeRelativeBounds(bounds, window, uiObject);
                    window.reposition(window.getPosition()
                        .add(new Position(0, uiObject.getBoundingBox().getWidth() + padding)));
                }

                window.reposition(new Position(padding, height));
            }
        }

        private static void removeRelativeBounds(BoundingBox baseBounds, BoundingBox removedBounds,
            UIObject positionedUi)
        {
            Position targetPosition = positionedUi.getBoundingBox().getPosition()
                .add(removedBounds.getPosition().substract(baseBounds.getPosition()));
            positionedUi.Reposition(targetPosition);
        }

        private static void checkHeightRequirements(BoundingBox bounds, int totalHeight)
        {
            if (totalHeight > bounds.getHeight())
            {
                throw new NotImplementedException(); //TODO better error
            }
        }

        private static int getTotalRequiredHeight(BoundingBox bounds, List<UIObject> uiObjects, int padding)
        {
            List<UIObject> uiObjectsCopy = new List<UIObject>();
            uiObjectsCopy.AddRange(uiObjects);
            int totalHeight = padding;
            while (uiObjectsCopy.Count > 0)
            {
                int rowFitCount = Align.rowFitCount(bounds, uiObjects, padding);
                List<UIObject> objects = uiObjectsCopy.GetRange(0, rowFitCount);
                totalHeight += minHeightCount(bounds, objects, padding);
            }

            return totalHeight;
        }

        private static void executeAlignment(BoundingBox bounds, UIObject uiObject, Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.TopLeft:
                    alignTop(bounds, uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.TopCenter:
                    alignTop(bounds, uiObject);
                    horizontalAlignCenter(bounds, uiObject);
                    break;
                case Alignment.TopRight:
                    alignTop(bounds, uiObject);
                    alignRight(bounds, uiObject);
                    break;
                case Alignment.CenterLeft:
                    verticalAlignCenter(bounds, uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.Center:
                    verticalAlignCenter(bounds, uiObject);
                    horizontalAlignCenter(bounds, uiObject);
                    break;
                case Alignment.CenterRight:
                    verticalAlignCenter(bounds, uiObject);
                    alignRight(bounds, uiObject);
                    break;
                case Alignment.BottomLeft:
                    alignTop(bounds, uiObject);
                    alignLeft(bounds, uiObject);
                    break;
                case Alignment.BottomCenter:
                    alignBottom(bounds, uiObject);
                    horizontalAlignCenter(bounds, uiObject);
                    break;
                case Alignment.BottomRight:
                    alignBottom(bounds, uiObject);
                    alignRight(bounds, uiObject);
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

            return minHeight + padding;
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
                boundingBox.getPosition().y + boundingBox.getHeight() - uiObject.getBoundingBox().getHeight()));
        }

        public static void removeRelativeBounds(BoundingBox baseBounds, BoundingBox removedBounds,
            List<UIObject> positionedUI)
        {
            //TODO check basebounds and removebounds
            foreach (UIObject uiObject in positionedUI)
            {
                removeRelativeBounds(baseBounds, removedBounds, uiObject);
            }
        }
    }
}