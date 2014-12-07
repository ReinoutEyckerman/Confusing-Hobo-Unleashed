using System;
using System.Threading;

namespace Confusing_Hobo_Unleashed
{
    internal class AlphaBootScreen
    {
        private static readonly int Calculatrix = Console.WindowHeight/10;
        private static readonly int YQuarter = Console.WindowHeight/4;
        private static readonly int XQuarter = Console.WindowWidth/4 + Calculatrix*3;
        private static readonly int XHalf = Console.WindowWidth/2;
        private static readonly int XThreeQuarter = Console.WindowWidth*3/4;

        private static void Write(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

        public static void DrawAlpha()

        {
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].White;
            for (int y = YQuarter; y < YQuarter + Calculatrix; y++)
            {
                for (int x = XQuarter; x < XHalf; x++)
                {
                    Write(x, y);
                }
                for (int x = XThreeQuarter - XQuarter/2; x < XThreeQuarter - Calculatrix*2; x++)
                {
                    Write(x, y);
                }
            }
            for (int y = YQuarter + Calculatrix; y < YQuarter + Calculatrix*2; y++)
            {
                for (int x = XQuarter - Calculatrix; x < XQuarter + Calculatrix; x++)
                {
                    Write(x, y);
                }
                for (int x = XHalf - Calculatrix; x < XHalf + Calculatrix; x++)
                {
                    Write(x, y);
                }
                for (int x = XThreeQuarter - XQuarter/2 - Calculatrix; x < XThreeQuarter - XQuarter/2 + Calculatrix;
                    x++)
                {
                    Write(x, y);
                }
            }
            for (int y = YQuarter + Calculatrix*2; y < YQuarter + Calculatrix*3; y++)
            {
                for (int x = XQuarter - Calculatrix*2; x < XQuarter; x++)
                {
                    Write(x, y);
                }
                for (int x = XHalf; x < XThreeQuarter - XQuarter/2; x++)
                {
                    Write(x, y);
                }
            }
            for (int y = YQuarter + Calculatrix*3; y < YQuarter + Calculatrix*4; y++)
            {
                for (int x = XQuarter - Calculatrix; x < XQuarter + Calculatrix; x++)
                {
                    Write(x, y);
                }
                for (int x = XHalf - Calculatrix; x < XHalf + Calculatrix; x++)
                {
                    Write(x, y);
                }
                for (int x = XThreeQuarter - XQuarter/2 - Calculatrix; x < XThreeQuarter - XQuarter/2 + Calculatrix;
                    x++)
                {
                    Write(x, y);
                }
                for (int x = XThreeQuarter - Calculatrix*3; x < XThreeQuarter - Calculatrix; x++)
                {
                    Write(x, y);
                }
            }
            for (int y = YQuarter + Calculatrix*4; y < YQuarter + Calculatrix*5; y++)
            {
                for (int x = XQuarter; x < XHalf; x++)
                {
                    Write(x, y);
                }
                for (int x = XThreeQuarter - XQuarter/2; x < XThreeQuarter - Calculatrix*2; x++)
                {
                    Write(x, y);
                }
            }
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
            Console.SetCursorPosition(0, YQuarter + Calculatrix*6);
            Console.Write("Confusing Hobo Unleashed".PadLeft(XHalf + 12));
            Console.SetCursorPosition(0, YQuarter + Calculatrix*6 + 1);
            Console.Write("By Oliver Hofkens & Reinout Eyckerman".PadLeft(XHalf + 18));
            Console.SetCursorPosition(0, YQuarter + Calculatrix*6 + 3);
            Console.Write("A Team Alpha Production".PadLeft(XHalf + 11));
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}