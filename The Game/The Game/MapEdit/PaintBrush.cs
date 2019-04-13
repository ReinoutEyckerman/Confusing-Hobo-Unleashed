using System;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.MapEdit
{
    internal class PaintBrush
    {
        public bool CurrentPosDestr;
        
        public PaintBrush(int xcoord, int ycoord)
        {
            X = xcoord;
            Y = ycoord;

            CurrentPosChar = ' ';
            CurrentPosBgColor = BaseColor.Black;
            CurrentPosFgColor = BaseColor.White;
            CurrentPosColl = false;
            CurrentPosDestr = true;

            PaintBgColor = BaseColor.Black;
            PaintFgColor = BaseColor.White;
            PaintChar = null;
        }

        public int X { get; set; }
        public int Y { get; set; }
        //Properties of the current block the cursor is on.
        public char CurrentPosChar { get; set; }
        public BaseColor CurrentPosBgColor { get; set; }
        public BaseColor CurrentPosFgColor { get; set; }
        public bool CurrentPosColl { get; set; }
        //Selected paint options.
        public BaseColor PaintFgColor { get; set; }
        public BaseColor PaintBgColor { get; set; }
        public char? PaintChar { get; set; }
        public bool PaintCollision { get; set; }
        public bool PaintDestruct { get; set; }
        public bool Locked { get; set; }

        public void ToggleBgColor(bool up)
        {
            if (up)
            {
                PaintBgColor.Next();
            }
            else
            {
                PaintBgColor.Previous();
            }
        }

        public void ToggleFgColor(bool up)
        {
            if (up)
            {
                PaintFgColor.Next();
            }
            else
            {
                PaintFgColor.Previous();
            }
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