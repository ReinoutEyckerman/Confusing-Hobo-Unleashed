using System;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed
{
    internal class GameUi
    {
        private const int UiLeftX = 2;
        private static readonly short UiBoxColors = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.DarkGray), Painter.Instance.Paint(ConsoleColor.Black, true));
        private static readonly short UiTextColors = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.DarkGray), Painter.Instance.Paint(ConsoleColor.Cyan, true));
        private static readonly short HpBarColor = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Green), Painter.Instance.Paint(ConsoleColor.Black, true));
        private static readonly short HpBarLostColor = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Red), Painter.Instance.Paint(ConsoleColor.Black, true));
        private static readonly int UiRightX = Game.CurrentLoadedMap.Background.GetLength(1) - 2;
        private static readonly int UiTopY = Game.CurrentLoadedMap.Background.GetLength(0) + 1;
        private static int _uiBotY = Console.WindowHeight - 2;

        public static void DrawUi(Buffer outputbuffer, Player player1 /*Player player2*/)
        {
            //This IF sets the maximum height of the UI to 5
            if (_uiBotY - UiTopY > 7)
            {
                _uiBotY = UiTopY + 7;
            }
            Draw.FillRectangle(UiBoxColors, 0, Console.WindowWidth - 1, UiTopY - 2, Console.WindowHeight - 1, outputbuffer);
            Draw.Box(UiLeftX, UiTopY, UiRightX, _uiBotY, UiBoxColors, outputbuffer);
            DrawPlayerHp(outputbuffer, player1, "player 1", UiLeftX + 2, UiTopY + 2);
        }

        private static void DrawPlayerHp(Buffer outputbuffer, Player player, string playername, int xpos, int ypos)
        {
            outputbuffer.Draw(playername + " HP:", xpos, ypos, UiTextColors);
            //Draw a 10-block wide hp-bar in red, this will be partially covered up by the green current hp.
            outputbuffer.Draw("           ", xpos, ypos + 1, HpBarLostColor);
            //Draw as many green blocks as currentHP/10 (100 HP = 10 Green blocks.)
            for (var i = 0; i <= player.HpCurrent/10; i++)
            {
                outputbuffer.Draw(" ", xpos + i, ypos + 1, HpBarColor);
            }
        }
    }
}