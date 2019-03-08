using System;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.MapEdit;

namespace Confusing_Hobo_Unleashed
{
    /*
     * class to draw shapes, both to maps and in UI elements.
     * - By Oliver
     */

    internal class Draw
    {
        public static void Line(CustomMap mapToDraw, int layerindex, Buffer outputbuffer, MapEditCursor paintBrush, int x1, int x2, int y1, int y2)
        {
            var smallestX = 0;
            var largestX = 0;
            var smallestY = 0;
            var largestY = 0;

            if (x1 < x2)
            {
                smallestX = x1;
                largestX = x2;
            }
            else if (x2 < x1)
            {
                smallestX = x2;
                largestX = x1;
            }
            if (y1 < y2 || y1 == y2) //if the y's are the same, it doesn't matter which is considered the bigger value.
            {
                smallestY = y1;
                largestY = y2;
            }
            else if (y2 < y1)
            {
                smallestY = y2;
                largestY = y1;
            }

            if (x1 == x2)
            {
                for (var ypos = smallestY; ypos <= largestY; ypos++)
                {
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[ypos, x1] = paintBrush.PaintBgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[ypos, x1] = paintBrush.PaintFgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[ypos, x1] = paintBrush.PaintChar;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Colors[ypos, x1] = Painter.Instance.ColorsToAttribute(paintBrush.PaintBgColor, paintBrush.PaintFgColor);
                    mapToDraw.Collision[ypos, x1] = paintBrush.PaintCollision;
                    mapToDraw.Destructible[ypos, x1] = paintBrush.PaintDestruct;
                }
            }

            else if (x1 != x2)
            {
                var rico = Convert.ToDouble((y2 - y1))/(x2 - x1);
                for (var x = smallestX; x <= largestX; x++)
                {
                    var ypos = Convert.ToInt32(rico*(x - x1) + y1);

                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[ypos, x] = paintBrush.PaintBgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[ypos, x] = paintBrush.PaintFgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[ypos, x] = paintBrush.PaintChar;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Colors[ypos, x] = Painter.Instance.ColorsToAttribute(paintBrush.PaintBgColor, paintBrush.PaintFgColor);
                    mapToDraw.Collision[ypos, x] = paintBrush.PaintCollision;
                    mapToDraw.Destructible[ypos, x] = paintBrush.PaintDestruct;
                }
            }
        }

        public static void CircleCenterRadius(CustomMap mapToDraw, int layerindex, Buffer outputbuffer, MapEditCursor paintBrush, int centerX, int centerY, int radiusX, int radiusY)
        {
            var radius = Math.Sqrt(Math.Pow(centerX - radiusX, 2) + Math.Pow(centerY - radiusY, 2));

            for (var i = 0; i < 360; i++)
            {
                var angle = i*Math.PI/180;
                var xpos = Convert.ToInt32(centerX + (radius*1.5*Math.Cos(angle)));
                var ypos = Convert.ToInt32(centerY + (radius*Math.Sin(angle)));

                if (xpos > 0 && xpos < mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background.GetLength(1) && ypos > 0 && ypos < mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background.GetLength(0))
                {
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[ypos, xpos] = paintBrush.PaintBgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[ypos, xpos] = paintBrush.PaintFgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[ypos, xpos] = paintBrush.PaintChar;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Colors[ypos, xpos] = Painter.Instance.ColorsToAttribute(paintBrush.PaintBgColor, paintBrush.PaintFgColor);
                    mapToDraw.Collision[ypos, xpos] = paintBrush.PaintCollision;
                    mapToDraw.Destructible[ypos, xpos] = paintBrush.PaintDestruct;
                }
            }
        }

        public static void FillRectangle(CustomMap mapToDraw, int layerindex, Buffer outputbuffer, MapEditCursor paintBrush, int x1, int x2, int y1, int y2)
        {
            var smallestX = 0;
            var smallestY = 0;
            var largestY = 0;
            var largestX = 0;

            if (x1 < x2)
            {
                smallestX = x1;
                largestX = x2;
            }
            else if (x2 < x1)
            {
                smallestX = x2;
                largestX = x1;
            }
            if (y1 < y2 || y1 == y2) //if the y's are the same, it doesn't matter which is considered the bigger value.
            {
                smallestY = y1;
                largestY = y2;
            }
            else if (y2 < y1)
            {
                smallestY = y2;
                largestY = y1;
            }

            for (var i = smallestY; i <= largestY; i++)
            {
                for (var j = smallestX; j <= largestX; j++)
                {
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[i, j] = paintBrush.PaintBgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[i, j] = paintBrush.PaintFgColor;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[i, j] = paintBrush.PaintChar;
                    mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Colors[i, j] = Painter.Instance.ColorsToAttribute(paintBrush.PaintBgColor, paintBrush.PaintFgColor);
                    mapToDraw.Collision[i, j] = paintBrush.PaintCollision;
                    mapToDraw.Destructible[i, j] = paintBrush.PaintDestruct;
                }
            }
        }

        public static void FillRectangle(short colors, int x1, int x2, int y1, int y2, Buffer outputbuffer, char drawChar = ' ')
        {
            var smallestX = 0;
            var largestX = 0;
            var smallestY = 0;
            var largestY = 0;

            if (x1 < x2)
            {
                smallestX = x1;
                largestX = x2;
            }
            else if (x2 < x1)
            {
                smallestX = x2;
                largestX = x1;
            }
            if (y1 < y2 || y1 == y2) //if the y's are the same, it doesn't matter which is considered the bigger value.
            {
                smallestY = y1;
                largestY = y2;
            }
            else if (y2 < y1)
            {
                smallestY = y2;
                largestY = y1;
            }

            for (var i = smallestY; i <= largestY; i++)
            {
                for (var j = smallestX; j <= largestX; j++)
                {
                    var drawstring = Convert.ToString(drawChar);
                    outputbuffer.Draw(drawstring, j, i, colors);
                }
            }
        }

        public static void PaintPixel(CustomMap mapToDraw, MapEditCursor paintBrush, int layerindex)
        {
            mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[paintBrush.Y, paintBrush.X] = paintBrush.PaintBgColor;
            mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[paintBrush.Y, paintBrush.X] = paintBrush.PaintFgColor;
            mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Colors[paintBrush.Y, paintBrush.X] = Painter.Instance.ColorsToAttribute(paintBrush.PaintBgColor, paintBrush.PaintFgColor);
            mapToDraw.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[paintBrush.Y, paintBrush.X] = paintBrush.PaintChar;
            mapToDraw.Collision[paintBrush.Y, paintBrush.X] = paintBrush.PaintCollision;
            mapToDraw.Destructible[paintBrush.Y, paintBrush.X] = paintBrush.PaintDestruct;
        }

        public static void Box(int leftX, int topY, int rightX, int botY, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;

            var width = rightX - leftX;

            //Top Border
            Console.SetCursorPosition(leftX, topY);
            for (var i = 0; i <= width; i++)
            {
                Console.Write("-");
            }

            //Left and Right border
            for (var j = topY + 1; j <= botY - 1; j++)
            {
                Console.SetCursorPosition(leftX, j);
                Console.Write("|");
                Console.SetCursorPosition(rightX, j);
                Console.Write("|");
            }

            //Bot Border
            Console.SetCursorPosition(leftX, botY);
            for (var i = 0; i <= width; i++)
            {
                Console.Write("-");
            }
        }

        public static void Box(int leftX, int topY, int rightX, int botY, short colors, Buffer outputbuffer, bool selected = false)
        {
            //Top Border
            var hori = "-";
            var verti = "|";
            if (Painter.Instance.Bw && selected)
                hori = verti = "o";

            for (var i = leftX; i <= rightX; i++)
            {
                outputbuffer.Draw(hori, i, topY, colors);
            }

            //Left and Right border
            for (var j = topY + 1; j <= botY - 1; j++)
            {
                outputbuffer.Draw(verti, leftX, j, colors);
                outputbuffer.Draw(verti, rightX, j, colors);
            }

            //Bot Border
            for (var i = leftX; i <= rightX; i++)
            {
                outputbuffer.Draw(hori, i, botY, colors);
            }
        }
    }
}