using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class PauseMenu
    {
        public static List<Button> MenuItems { get; set; }
        public static byte ActiveItem { get; set; }
        public static byte ActiveSubItem { get; set; }

        public static void GenerateMenu()
        {
            MenuItems = new List<Button>
            {
                new Button(1, 1, "Resume"),
                new Button(1, 6, "Inventory"),
                new Button(1, 11, "Options"),
                new Button(1, 16, "Quit")
            };

            ActiveItem = 0;
        }

        public static void ShowStartMenu(buffer outputbuffer)
        {
            GenerateMenu();
            var frameTimer = new Stopwatch();
            frameTimer.Start();

            while (true)
            {
                RenderMenu(outputbuffer);
                InputHandler.PauseMenuInputHandling();

                if (frameTimer.ElapsedMilliseconds < VarDatabase.FrameTimeMs)
                {
                    Thread.Sleep(VarDatabase.FrameTimeMs - (int) frameTimer.ElapsedMilliseconds);
                }
            }
        }

        public static void RenderMenu(buffer outputBuffer)
        {
            foreach (var button in MenuItems)
            {
                if (MenuItems[ActiveItem] != button)
                {
                    button.Render(outputBuffer);
                }
            }

            MenuItems[ActiveItem].RenderActive(outputBuffer);

            Draw.Box(22, 1, 90, 30, TextColors, outputBuffer);
            Draw.FillRectangle(TextColors, 23, 89, 2, 29, outputBuffer);

            switch (MenuItems[ActiveItem].Message)
            {
                case "Inventory":
                    break;
                case "Options":
                    RenderOptions(outputBuffer);
                    break;
            }

            outputBuffer.Print();
        }

        public static void RenderOptions(buffer outputBuffer)
        {
        }

        public static void EnterCurrentOption()
        {
            if (MenuItems[ActiveItem].Message == "Resume")
            {
                Game.GameLoop();
            }
            else if (MenuItems[ActiveItem].Message == "Quit")
            {
                StartMenu.MainScreen();
            }
        }

        public static void ChangeSelect(bool next)
        {
            if (next)
            {
                if (ActiveItem >= MenuItems.Count - 1)
                {
                    ActiveItem = 0;
                }
                else
                {
                    ActiveItem++;
                }
            }
            else
            {
                if (ActiveItem <= 0)
                {
                    ActiveItem = Convert.ToByte(MenuItems.Count - 1);
                }
                else
                {
                    ActiveItem--;
                }
            }
        }

        public static ConsoleColor Bg = Painter.Instance.Paint(ConsoleColor.DarkGreen);
        public static ConsoleColor Border = Painter.Instance.Paint(ConsoleColor.Red);
        public static ConsoleColor Fg = Painter.Instance.Paint(ConsoleColor.White,true);
        public static short BorderColors = Painter.Instance.ColorsToAttribute(Bg, Border);
        public static short TextColors = Painter.Instance.ColorsToAttribute(Bg, Fg);
    }
}