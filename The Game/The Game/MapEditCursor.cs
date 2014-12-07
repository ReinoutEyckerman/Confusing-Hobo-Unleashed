using System;
using System.Threading;

namespace Confusing_Hobo_Unleashed
{
    internal class MapEditCursor
    {
        public bool CurrentPosDestr;

        public MapEditCursor(int xcoord, int ycoord)
        {
            x = xcoord;
            y = ycoord;

            CurrentPosChar = ' ';
            CurrentPosBgColor = ConsoleColor.Black;
            CurrentPosFgColor = ConsoleColor.White;
            CurrentPosColl = false;
            CurrentPosDestr = true;

            PaintBgColor = ConsoleColor.Black;
            PaintFgColor = ConsoleColor.White;
            PaintChar = ' ';
        }

        public int x { get; set; }

        public int y { get; set; }

        //Properties of the current block the cursor is on.
        public char CurrentPosChar { get; set; }
        public ConsoleColor CurrentPosBgColor { get; set; }
        public ConsoleColor CurrentPosFgColor { get; set; }
        public bool CurrentPosColl { get; set; }

        //Selected paint options.
        public ConsoleColor PaintFgColor { get; set; }
        public ConsoleColor PaintBgColor { get; set; }
        public char PaintChar { get; set; }

        public bool PaintCollision { get; set; }

        public bool PaintDestruct { get; set; }

        public void ToggleBgColor(bool up)
        {
            //create an array of all possible ConsoleColors and find the index of the currently selected color.
            int currentindex = Array.IndexOf(Color.kleuren, PaintBgColor);

            //add or subtract 1 of the index of the current color.
            if (up)
            {
                if (currentindex + 1 >= Color.kleuren.Length)
                {
                    currentindex = 0;
                }
                else
                {
                    currentindex++;
                }
            }
            else
            {
                if (currentindex - 1 < 0)
                {
                    currentindex = Color.kleuren.Length - 1;
                }
                else
                {
                    currentindex--;
                }
            }

            PaintBgColor = (ConsoleColor) Color.kleuren.GetValue(currentindex);
        }

        public void ToggleFgColor(bool up)
        {
            //See ToggleBgColor for explanation.
            int currentindex = Array.IndexOf(Color.kleuren, PaintFgColor);

            if (up)
            {
                if (currentindex + 1 >= Color.kleuren.Length)
                {
                    currentindex = 0;
                }
                else
                {
                    currentindex++;
                }
            }
            else
            {
                if (currentindex - 1 < 0)
                {
                    currentindex = Color.kleuren.Length - 1;
                }
                else
                {
                    currentindex--;
                }
            }

            PaintFgColor = (ConsoleColor) Color.kleuren.GetValue(currentindex);
        }

        public void ToggleChar()
        {
            MapEditor.SystemMessage("Type the desired character:");
            Console.SetCursorPosition(85, Console.WindowHeight - 2);
            PaintChar = Console.ReadKey(true).KeyChar;
            MapEditor.SystemMessage(" ");
        }

        public void ToggleCollide()
        {
            PaintCollision = !PaintCollision;
        }

        public void ToggleDestructible()
        {
            PaintDestruct = !PaintDestruct;
        }

        public void UpdateCursorValues(CustomMap map, int layerindex)
        {
            CurrentPosChar = Convert.ToChar(map.Layers[layerindex].Characters[y, x]);
            CurrentPosBgColor = map.Layers[layerindex].Background[y, x];
            CurrentPosFgColor = map.Layers[layerindex].Foreground[y, x];
            CurrentPosColl = map.Collision[y, x];
            CurrentPosDestr = map.Destructible[y, x];
        }
    }
}