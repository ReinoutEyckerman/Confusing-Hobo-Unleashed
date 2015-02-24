using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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
    public class buffer
    {
        private readonly SafeFileHandle _h;
        private readonly int _height;
        private readonly int _width;
        private readonly int _windowHeight;
        private readonly int _windowWidth;
        private CharInfo[] _buf;
        private SmallRect _rect;

        /// <summary>
        ///     Consctructor class for the buffer. Pass in the width and height you want the buffer to be.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// ///
        /// <param name="wWidth"></param>
        /// <param name="wHeight"></param>
        public buffer(int width, int height, int wWidth, int wHeight)
            // Create and fill in a multideminsional list with blank spaces.
        {
            if (width > wWidth || height > wHeight)
            {
                throw new ArgumentException("The buffer width and height can not be greater than the window width and height.");
            }
            _h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            _width = width;
            _height = height;
            _windowWidth = wWidth;
            _windowHeight = wHeight;
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

        /// <summary>
        ///     This method draws any text to the buffer with given color.
        ///     To chance the color, pass in a value above 0. (0 being black text, 15 being white text).
        ///     Put in the starting width and height you want the input string to be.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="attribute"></param>
        public void Draw(String str, int width, int height, short attribute) //Draws the image to the buffer
        {
            if (width > _windowWidth - 1 || height > _windowHeight - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (str != null)
            {
                var temp = str.ToCharArray();
                var tc = 0;
                foreach (var le in temp)
                {
                    _buf[(width + tc) + (height*_width)].Char.AsciiChar = (byte) le;
                    //Height * width is to get to the correct spot (since this array is not two dimensions).
                    if (attribute != 0)
                        _buf[(width + tc) + (height*_width)].Attributes = attribute;
                    tc++;
                }
            }
        }

        /// <summary>
        ///     Prints the buffer to the screen.
        /// </summary>
        public void Print() //Paint the image
        {
            if (!_h.IsInvalid)
            {
                WriteConsoleOutput(_h, _buf, new Coord((short) _width, (short) _height), new Coord(0, 0), ref _rect);
            }
        }

        /// <summary>
        ///     Clears the buffer and resets all character values back to 32, and attribute values to 1.
        /// </summary>
        public void Clear()
        {
            for (var i = 0; i < _buf.Length; i++)
            {
                _buf[i].Attributes = 1;
                _buf[i].Char.AsciiChar = 32;
            }
        }

        /// <summary>
        ///     Pass in a buffer to change the current buffer.
        /// </summary>
        /// <param name="b"></param>
        public void SetBuf(CharInfo[] b)
        {
            if (b == null)
            {
                throw new ArgumentNullException();
            }

            _buf = b;
        }

        /// <summary>
        ///     Set the x and y cordnants where you wish to draw your buffered image.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetDrawCord(short x, short y)
        {
            _rect.SetDrawCord(x, y);
        }

        /// <summary>
        ///     Clear the designated row and make all attribues = 1.
        /// </summary>
        /// <param name="row"></param>
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

        /// <summary>
        ///     Clear the designated column and make all attribues = 1.
        /// </summary>
        /// <param name="col"></param>
        public void ClearColumn(int col)
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
        public struct SmallRect
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
    }
}