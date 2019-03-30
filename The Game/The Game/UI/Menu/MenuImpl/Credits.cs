using System;
using System.Threading;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class Credits
    {
        
        public static void ShowCredits()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            Console.Clear();
            for (var y = Console.WindowHeight; y > StartMenu.Credits.Count*-2; y--)
            {
                Console.Clear();
                for (var i = 0; i < StartMenu.Credits.Count; i++)
                {
                    var pos = y + i*2;
                    if (pos < Console.WindowHeight && pos > 0)
                    {
                        Console.SetCursorPosition(Console.WindowWidth/2 - StartMenu.Credits[i].Length/2, pos);
                        Console.Write(StartMenu.Credits[i]);
                    }
                }
                Thread.Sleep(300);
            }
        }
    }
}