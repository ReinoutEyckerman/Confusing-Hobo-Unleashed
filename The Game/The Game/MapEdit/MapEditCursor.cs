using System;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.MapEdit
{
    internal class MapEditCursor
    {
        public bool CurrentPosDestr;

        public MapEditCursor(int xcoord, int ycoord)
        {
            X = xcoord;
            Y = ycoord;

            CurrentPosChar = ' ';
            CurrentPosBgColor = ConsoleColor.Black;
            CurrentPosFgColor = ConsoleColor.White;
            CurrentPosColl = false;
            CurrentPosDestr = true;

            PaintBgColor = ConsoleColor.Black;
            PaintFgColor = ConsoleColor.White;
            PaintChar = null;
        }

        public int X { get; set; }

        public int Y { get; set; }

        //Properties of the current block the cursor is on.
        public char CurrentPosChar { get; set; }
        public ConsoleColor CurrentPosBgColor { get; set; }
        public ConsoleColor CurrentPosFgColor { get; set; }
        public bool CurrentPosColl { get; set; }

        //Selected paint options.
        public ConsoleColor PaintFgColor { get; set; }
        public ConsoleColor PaintBgColor { get; set; }
        public char? PaintChar { get; set; }

        public bool PaintCollision { get; set; }

        public bool PaintDestruct { get; set; }

        public bool Locked { get; set; }

        public void ToggleBgColor(bool up)
        {
            //create an array of all possible ConsoleColors and find the index of the currently selected color.
            int currentindex = Array.IndexOf(Color.Kleuren, PaintBgColor);

            //add or subtract 1 of the index of the current color.
            if (up)
            {
                if (currentindex + 1 >= Color.Kleuren.Length)
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
                    currentindex = Color.Kleuren.Length - 1;
                }
                else
                {
                    currentindex--;
                }
            }

            PaintBgColor = (ConsoleColor) Color.Kleuren.GetValue(currentindex);
        }

        public void ToggleFgColor(bool up)
        {
            //See ToggleBgColor for explanation.
            int currentindex = Array.IndexOf(Color.Kleuren, PaintFgColor);

            if (up)
            {
                if (currentindex + 1 >= Color.Kleuren.Length)
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
                    currentindex = Color.Kleuren.Length - 1;
                }
                else
                {
                    currentindex--;
                }
            }

            PaintFgColor = (ConsoleColor) Color.Kleuren.GetValue(currentindex);
        }

        public void ToggleChar()
        {
            //Empty the input buffer before reading a key. Thanks to Monsieur Tim Dams.
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Locked = true;
            MapEditor.SystemMessage("Type the desired character:");
            Console.SetCursorPosition(50, Console.WindowHeight - 2);
            PaintChar = Console.ReadKey(true).KeyChar;
            MapEditor.SystemMessage(" ");
            Locked = false;
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
            CurrentPosChar = Convert.ToChar(map.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Characters[Y, X]);
            CurrentPosBgColor = map.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Background[Y, X];
            CurrentPosFgColor = map.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(layerindex))].Foreground[Y, X];
            CurrentPosColl = map.Collision[Y, X];
            CurrentPosDestr = map.Destructible[Y, X];
        }
    }
}