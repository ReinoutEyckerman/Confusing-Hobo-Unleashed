using System;

namespace Confusing_Hobo_Unleashed.Map
{
    public class Layer
    {
        public Layer(bool isEnabled, int sizex, int sizey)
        {
            IsEnabled = isEnabled;
            Background = new ConsoleColor[sizey, sizex];
            Foreground = new ConsoleColor[sizey, sizex];
            Characters = new char?[sizey, sizex];
            Colors = new short[sizey, sizex];
        }

        public bool IsEnabled { get; set; }
        public ConsoleColor[,] Background { get; set; }
        public ConsoleColor[,] Foreground { get; set; }
        public char?[,] Characters { get; set; }
        public short[,] Colors { get; set; }

        public void LayerToBuffer(buffer outputbuffer)
        {
            for (int i = 0; i < Background.GetLength(0); i++)
            {
                for (int j = 0; j < Background.GetLength(1); j++)
                {
                    if (Characters[i, j].HasValue)
                    {
                        string charToString = Convert.ToString(Characters[i, j]);
                        outputbuffer.Draw(charToString, j, i, Colors[i, j]);
                    }
                }
            }
        }
    }
}