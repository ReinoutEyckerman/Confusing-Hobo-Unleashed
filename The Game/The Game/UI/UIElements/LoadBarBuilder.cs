using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public class LoadBarBuilder
    {
        private Dictionary<string, TriggerEventHandler> delegates = new Dictionary<string, TriggerEventHandler>();
        private Position position;
        private Image image;

        public LoadBarBuilder(Position position, Image image)
        {
            this.delegates = new Dictionary<string, TriggerEventHandler>();
            this.position = position;
            this.image = image;
        }

        public LoadBarBuilder(Position position, Image activeImage, Image inactiveImage)
        {
            this.delegates = new Dictionary<string, TriggerEventHandler>();
            this.position = position; //TODO
            this.image = image;
        }

        public void addDelegate(String task, TriggerEventHandler EventHandler)
        {
            this.delegates.Add(EventHandler);
        }

        public LoadBar build()
        {
            return new LoadBar(this.delegates, position, image);
        }

        private static void Loadbar(string message)
        {
            for (var a = 1; a <= 3; a++)
            {
                Console.SetCursorPosition(Console.WindowWidth * 2 / 5 + 1, Console.WindowHeight * 5 / 6 + a);
                for (var b = Console.WindowWidth * 2 / 5 + 1; b < Console.WindowWidth * 2 / 5 + _barCount * barLength; b++)
                {
                    Console.Write(" ");
                }
            }

            _barCount++;
            Thread.Sleep(20);
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            int w;
            if (_prevMessage > Console.WindowWidth / 5)
                w = (_prevMessage - Console.WindowWidth / 5) / 2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth * 4 / 10 - w, Console.WindowHeight * 5 / 6 - 1);
            for (var a = 0; a < _prevMessage; a++)
            {
                Console.Write(" ");
            }

            if (message.Length > Console.WindowWidth / 5)
                w = (message.Length - Console.WindowWidth / 5) / 2;
            else w = 0;
            Console.SetCursorPosition(Console.WindowWidth * 2 / 5 - w, Console.WindowHeight * 5 / 6 - 1);
            Console.Write(message);
            _prevMessage = message.Length;
        }
    }
}