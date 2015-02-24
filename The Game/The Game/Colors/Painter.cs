﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confusing_Hobo_Unleashed.Colors
{
  public  class Painter:ColorSchemes
    {
        public  ColorScheme ColorScheme = 0;
        public  bool Bw = false;
      private static Painter _instance;

      public Painter()
      {
          Refresh();
      }
      public static Painter Instance
      {
          get { return _instance ?? (_instance = new Painter()); }
      }
        public ConsoleColor Paint(ConsoleColor color, bool foreground = false)
        {
            return foreground ? ForeGroundList[ColorScheme][color] : BackGroundList[ColorScheme][color];
        }
        public  short ColorsToAttribute(ConsoleColor bg, ConsoleColor fg)
        {
            var bgValue = (byte)(bg);
            var fgValue = (byte)(fg);
            var attribute = Convert.ToInt16((bgValue) * 16 + fgValue);
            return attribute;
        }
        public  ConsoleColor BackgroundFromAttribute(short attribute)
        {
            var bgvalue = Convert.ToInt16(attribute / 16);
            return (ConsoleColor)(bgvalue);
        }

        public  ConsoleColor ForegroundFromAttribute(short attribute)
        {
            var fgvalue = Convert.ToInt16(attribute % 16);
            return (ConsoleColor)(fgvalue);
        }
    }
}
