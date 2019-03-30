using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.Windows;
using Microsoft.Win32.SafeHandles;

namespace Confusing_Hobo_Unleashed
{
    /*
     * Copyright [2012] [Jeff R Baker]
     * ADDITIONS AND CHANGES BY OLIVER HOFKENS
     * 
     * 
     * Licensed under the Apache License, Version 2.0 (the "License");
     * you may not use this file except in compliance with the License.
     * You may obtain a copy of the License at    
     * 
     *          http://www.apache.org/licenses/LICENSE-2.0
     * 
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     * 
     * v 1.2.0
     */

    /// <summary>
    ///     This class allows for a double buffer in Visual C# cmd promt.
    ///     The buffer is persistent between frames.
    /// </summary>
    public class Buffer
    {
        private readonly SafeFileHandle _h;
        private readonly int _height;
        private readonly int _width;
        private readonly int _windowHeight;
        private readonly int _windowWidth;
        private CharInfo[] _buf;
        private SmallRect _rect;

        public Buffer(int width, int height, int windowWidth, int windowHeight)
        {
            if (width > windowWidth || height > windowHeight)
            {
                throw new ArgumentException("The buffer width and height can not be greater than the window width and height.");
            }
            
            _h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            _width = width;
            _height = height;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
            _buf = new CharInfo[_width*_height];
            _rect = new SmallRect();
            _rect.SetDrawCord(0, 0);
            _rect.SetWindowSize((short) _windowWidth, (short) _windowHeight);
            Clear();
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] uint fileAccess, [MarshalAs(UnmanagedType.U4)] uint fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] int flags, IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(SafeFileHandle hConsoleOutput, CharInfo[] lpBuffer, Coord dwBufferSize, Coord dwBufferCoord, ref SmallRect lpWriteRegion);

        public void Draw(String str, int width, int height, ColorPoint color) //Draws the image to the buffer
        {
            if (width > _windowWidth - 1 || height > _windowHeight - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if (str != null)
            {
                char[] charArray = str.ToCharArray();
                int letterPos = 0;
                
                
                foreach (char letter in charArray)
                {
                    _buf[(width + letterPos) + (height*_width)].Char.AsciiChar = (byte) letter;
                    //Height * width is to get to the correct spot (1D Array).
//                    if (attribute != 0)
                    {
                        _buf[(width + letterPos) + (height*_width)].Attributes = ColorsToAttribute(color,(width + letterPos) , (height*_width));//TODO
                    }
                    letterPos++;
                }
            }
        }

        public void Print() 
        {
            if (!_h.IsInvalid)
            {
                WriteConsoleOutput(_h, _buf, new Coord((short) _width, (short) _height), new Coord(0, 0), ref _rect);
            }
        }

        public void Clear()
        {
            for (var i = 0; i < _buf.Length; i++)
            {
                _buf[i].Attributes = 1;
                _buf[i].Char.AsciiChar = 32;
            }
        }

        public void SetBuf(CharInfo[] b)
        {
            if (b == null)
            {
                throw new ArgumentNullException();
            }

            _buf = b;
        }

        public void SetDrawCord(short x, short y)
        {
            _rect.SetDrawCord(x, y);
        }

        public void ClearRow(int row)
        {
            for (var i = (row*_width); i < ((row*_width + _width)); i++)
            {
                if (row > _windowHeight - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _buf[i].Attributes = 0;
                _buf[i].Char.AsciiChar = 32;
            }
        }

        public void ClearColumn(int col)//TODO fun times?
        {
            if (col > _windowWidth - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (var i = col; i < _windowHeight*_windowWidth; i += _windowWidth)
            {
                _buf[i].Attributes = 0;
                _buf[i].Char.AsciiChar = 32;
            }
        }

        /// <summary>
        ///     This function return the character and attribute at given location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>
        ///     byte character
        ///     byte attribute
        /// </returns>
        public KeyValuePair<byte, byte> GetCharAt(int x, int y)
        {
            if (x > _windowWidth || y > _windowHeight)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new KeyValuePair<byte, byte>(_buf[((y*_width + x))].Char.AsciiChar, (byte) _buf[((y*_width + x))].Attributes);
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            private readonly short X;
            private readonly short Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect//TODO ?
        {
            private short Left;
            private short Top;
            private short Right;
            private short Bottom;

            public void SetDrawCord(short l, short t)
            {
                Left = l;
                Top = t;
            }

            public void SetWindowSize(short r, short b)
            {
                Right = r;
                Bottom = b;
            }
        }
        
        private short ColorsToAttribute(ColorPoint color, int x, int y)
        {
            ConsoleColor backgroundColor;
            ConsoleColor foregroundColor; 
            if (color.GetBackgroundColor() == BaseColor.Void)
            {
                backgroundColor = getConsoleColor((BaseColor)(GetCharAt(x, y).Value/16));
            }
            else
            {
                backgroundColor = getConsoleColor(color.GetBackgroundColor());
            }
            if (color.GetForegroundColor() == BaseColor.Void)
            {
                foregroundColor = getConsoleColor((BaseColor)(GetCharAt(x, y).Value%16));
            }
            else
            {
                foregroundColor = getConsoleColor(color.GetForegroundColor());
            }
            
            var bgValue = (byte)(backgroundColor);
            var fgValue = (byte)(foregroundColor);
            var attribute = Convert.ToInt16((bgValue) * 16 + fgValue);
            return attribute;
        }
        
        private ConsoleColor getConsoleColor(BaseColor drawColor)
        {
            ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), drawColor.ToString());
            return consoleColor;
        }
    }
}