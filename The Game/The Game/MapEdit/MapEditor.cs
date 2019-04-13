using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.Colors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Keyboard = System.Windows.Input.Keyboard;

namespace Confusing_Hobo_Unleashed.MapEdit
{
    internal class MapEditor
    {
        public static short UiBorderColors = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.DarkGreen), Painter.Instance.Paint(ConsoleColor.White, true));
        public static short UiTextColors = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.DarkGreen), Painter.Instance.Paint(ConsoleColor.White, true));
        public static short UiActiveLayer = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Yellow), Painter.Instance.Paint(ConsoleColor.Black, true));
        public static short UiInactiveLayer = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Black), Painter.Instance.Paint(ConsoleColor.Gray, true));
        public static short UiActiveButDisabledLayer = Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Black), Painter.Instance.Paint(ConsoleColor.Red, true));
        public static int Ww = Console.WindowWidth;
        public static int KeypressTimer;
        public static TaskCompletionSource<object> ContinueCommand { get; set; }
        public static CustomMap CurrentMapInEditor { get; set; }
        public static PaintBrush HuidigeCursor { get; set; }
        public static Buffer MapBuffer { get; set; }
        private static int ActiveLayer { get; set; }

        public static void WorkingSpace()
        {
            Endgame.PlayMusic();
            Init();
            Console.CursorVisible = true;
            Console.CursorSize = 100;
            StartDraw();
            Console.SetCursorPosition(HuidigeCursor.X, HuidigeCursor.Y);

            while (true)
            {
                InputHandling();
                Console.SetCursorPosition(HuidigeCursor.X, HuidigeCursor.Y);
                Thread.Sleep(33);
            }
        }

        public static void Init()
        {
            MapBuffer = new Buffer(Ww, Wh, Ww, Wh);
            HuidigeCursor = new PaintBrush(0, 0);
            ContinueCommand = new TaskCompletionSource<object>();
            ActiveLayer = 1;
        }

        public static void StartWorkingSpace()
        {
            Console.Clear();
            //Writes ---          
            for (var xui = 0; xui < Console.WindowWidth; xui++)
            {
                MapBuffer.Draw("-", xui, UiLine, UiBorderColors);
            }

            //Colours UI
            Draw.FillRectangle(UiTextColors, 0, Ww - 1, UiControls, Wh - 1, MapBuffer);

            MapBuffer.Draw("Press F10 to see a list of all commands", 1, UiControls, UiTextColors);

            DrawActiveLayers();
        }

        public static void UpdateUiCurrentPix()
        {
            ClearConsoleLine(UiCurrentPixel, UiTextColors);
            HuidigeCursor.UpdateCursorValues(CurrentMapInEditor, ActiveLayer);
            var currentPixelValues = String.Format("Current Pixel: BG:{0} FG:{1} Char:{2} Coll:{3} Destr:{4} X:{5} Y:{6}", HuidigeCursor.CurrentPosBgColor, HuidigeCursor.CurrentPosFgColor, HuidigeCursor.CurrentPosChar, HuidigeCursor.CurrentPosColl, HuidigeCursor.CurrentPosDestr, HuidigeCursor.X, HuidigeCursor.Y);

            MapBuffer.Draw(currentPixelValues, 1, UiCurrentPixel, UiTextColors);
            MapBuffer.Print();
        }

        public static void UpdateUiPaintPrefs()
        {
            //First line
            ClearConsoleLine(UiPaints, UiTextColors);

            MapBuffer.Draw("Current Paint: (-)BG:", 1, UiPaints, UiTextColors);
            for (var i = 0; i < Painter.Instance.Kleuren.Length; i++)
            {
                var drawColor = (ConsoleColor) Painter.Instance.Kleuren.GetValue(i);
                var drawColorShort = Painter.Instance.ColorsToAttribute(drawColor, ConsoleColor.White);

                MapBuffer.Draw(" ", 24 + i, UiPaints, drawColorShort);
            }

            MapBuffer.Draw(" (-)FG:", 45, UiPaints, UiTextColors);

            for (var i = 0; i < Painter.Instance.Kleuren.Length; i++)
            {
                var drawColor = (ConsoleColor) Painter.Instance.Kleuren.GetValue(i);
                var drawColorShort = Painter.Instance.ColorsToAttribute(drawColor, ConsoleColor.White);

                MapBuffer.Draw(" ", 54 + i, UiPaints, drawColorShort);
            }

            var paintPrefs = String.Format(" ()Char:{0} ()Coll:{1} ()Destr:{2} Preview:", HuidigeCursor.PaintChar, HuidigeCursor.PaintCollision, HuidigeCursor.PaintDestruct);
            MapBuffer.Draw(paintPrefs, 70, UiPaints, UiTextColors);

            var preview = Convert.ToString(HuidigeCursor.PaintChar);
            var previewColor = Painter.Instance.ColorsToAttribute(HuidigeCursor.PaintBgColor, HuidigeCursor.PaintFgColor);
            MapBuffer.Draw(preview, 115, UiPaints, previewColor);

            //Second line, only the indicators for the colors on the line above.
            ClearConsoleLine(UiPaints + 1, UiTextColors);

            var bGindex = Array.IndexOf(Painter.Instance.Kleuren, HuidigeCursor.PaintBgColor);
            MapBuffer.Draw("^", 24 + bGindex, UiPaints + 1, UiTextColors);

            var fGindex = Array.IndexOf(Painter.Instance.Kleuren, HuidigeCursor.PaintFgColor);
            MapBuffer.Draw("^", 54 + fGindex, UiPaints + 1, UiTextColors);
            MapBuffer.Print();
        }

        public static void UpdateUiLayer()
        {
            ClearConsoleLine(UiLayers, UiTextColors);
            MapBuffer.Draw("Layers: ", 1, UiLayers, UiTextColors);
            var index = 9;

            foreach (var layer in CurrentMapInEditor.Layers)
            {
                //Air and clouds are Locked when generated at runtime.
                if (layer.Key == Maplayers.Air && CurrentMapInEditor.DayNightEnabled)
                {
                    MapBuffer.Draw("Air (LOCKED)", index, UiLayers, UiInactiveLayer);
                    index += 10;
                }
                else if (layer.Key == Maplayers.Clouds && CurrentMapInEditor.CloudsEnabled)
                {
                    MapBuffer.Draw("Clouds (LOCKED)", index, UiLayers, UiInactiveLayer);
                    index += 10;
                }
                //Active Layer and enabled.
                else if (layer.Value.IsEnabled && layer.Key == (Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(ActiveLayer)))
                {
                    MapBuffer.Draw(layer.Key.ToString(), index, UiLayers, UiActiveLayer);
                }
                //Active Layer but disabled
                else if (!layer.Value.IsEnabled && layer.Key == (Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(ActiveLayer)))
                {
                    MapBuffer.Draw(layer.Key.ToString(), index, UiLayers, UiActiveButDisabledLayer);
                }
                //Disabled Layer
                else if (!layer.Value.IsEnabled)
                {
                    MapBuffer.Draw(layer.Key.ToString(), index, UiLayers, UiInactiveLayer);
                }
                //Enabled layer
                else
                {
                    MapBuffer.Draw(layer.Key.ToString(), index, UiLayers, UiTextColors);
                }
                index += layer.Key.ToString().Length + 1;
            }
            MapBuffer.Print();
        }

        public static void ClearConsoleLine(int row, short colors)
        {
            for (var i = 0; i < Ww; i++)
            {
                MapBuffer.Draw(" ", i, row, colors);
            }
        }

        public static void SystemMessage(string message)
        {
            ClearConsoleLine(UiSysMes, UiTextColors);

            var Message = String.Format("System Message:{0}", message);
            MapBuffer.Draw(Message, 1, UiSysMes, UiTextColors);
            MapBuffer.Print();
        }

        public static void NextLayer()
        {
            if (ActiveLayer >= CurrentMapInEditor.Layers.Count - 1)
            {
                ActiveLayer = 0;
            }
            else
            {
                ActiveLayer++;
            }

            //If a layer is generated at runtime, it can't be selected in mapeditor.
            if (CurrentMapInEditor.DayNightEnabled && ActiveLayer == 0)
            {
                NextLayer();
            }
            if (CurrentMapInEditor.CloudsEnabled && ActiveLayer == 4)
            {
                NextLayer();
            }
        }

        public static void ToggleLayer()
        {
            CurrentMapInEditor.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(ActiveLayer))].IsEnabled = !CurrentMapInEditor.Layers[(Maplayers) Enum.Parse(typeof (Maplayers), Convert.ToString(ActiveLayer))].IsEnabled;
            DrawActiveLayers();
        }

        public static void DrawActiveLayers()
        {
            ClearMapBuffer();
            foreach (var layer in CurrentMapInEditor.Layers)
            {
                if (layer.Value.IsEnabled)
                {
                    layer.Value.LayerToBuffer(MapBuffer);
                }
            }

            MapBuffer.Print();
        }

        public static void ClearMapBuffer()
        {
            for (var i = 0; i < CurrentMapInEditor.Layers[Maplayers.Collision].Background.GetLength(0); i++)
            {
                MapBuffer.ClearRow(i);
            }
        }

        public static async void DrawLineCommand()
        {
            SystemMessage("Select the first point and press enter.");

            //Create a ContinueCommand Task so we can await keypresses.
            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var x1 = HuidigeCursor.X;
            var y1 = HuidigeCursor.Y;

            SystemMessage("Select the second point and press enter.");

            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var x2 = HuidigeCursor.X;
            var y2 = HuidigeCursor.Y;

            Draw.Line(CurrentMapInEditor, ActiveLayer, MapBuffer, HuidigeCursor, x1, x2, y1, y2);
            SystemMessage(" ");
            UpdateUiCurrentPix();
            DrawActiveLayers();
        }

        public static async void DrawCircleCommand()
        {
            SystemMessage("Select the center point and press enter.");

            //Create a ContinueCommand Task so we can await keypresses.
            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var x1 = HuidigeCursor.X;
            var y1 = HuidigeCursor.Y;

            SystemMessage("Select a point on the circle and press enter.");

            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var radiusX = HuidigeCursor.X;
            var radiusY = HuidigeCursor.Y;

            Draw.CircleCenterRadius(CurrentMapInEditor, ActiveLayer, MapBuffer, HuidigeCursor, x1, y1, radiusX, radiusY);
            SystemMessage(" ");
            UpdateUiCurrentPix();
            DrawActiveLayers();
        }

        public static async void DrawRectangleCommand()
        {
            SystemMessage("Select the first corner point and press enter.");

            //Create a ContinueCommand Task so we can await keypresses.
            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var x1 = HuidigeCursor.X;
            var y1 = HuidigeCursor.Y;

            SystemMessage("Select the second corner and press enter.");

            ContinueCommand = new TaskCompletionSource<object>();
            await ContinueCommand.Task;

            var x2 = HuidigeCursor.X;
            var y2 = HuidigeCursor.Y;

            Draw.FillRectangle(CurrentMapInEditor, ActiveLayer, MapBuffer, HuidigeCursor, x1, x2, y1, y2);
            SystemMessage(" ");
            UpdateUiCurrentPix();
            DrawActiveLayers();
        }

        public static void SaveMapCommand()
        {
            if (CurrentMapInEditor.NewFile)
            {
                while (true)
                {
                    //Empty the input buffer before reading a key. Thanks to Monsieur Tim Dams.
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(false);
                    }
                    SystemMessage("Filename (without extension):");
                    Console.SetCursorPosition(50, Console.WindowHeight - 2);
                    var filename = Console.ReadLine();

                    //Check if the filename entered is valid
                    var isValid = !String.IsNullOrEmpty(filename) && filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && !File.Exists(Path.Combine("maps", filename));

                    //if valid set filename and newfile=false.
                    if (isValid)
                    {
                        filename += ".xml";
                        CurrentMapInEditor.FileName = filename;
                        CurrentMapInEditor.NewFile = false;

                        CurrentMapInEditor.SaveMap();

                        break;
                    }
                }
            }
            else
            {
                CurrentMapInEditor.SaveMap();
            }
        }

        public static void HelpScreen()
        {
            Draw.Box(1, 1, Ww - 8, 30, UiTextColors, MapBuffer);
            Draw.FillRectangle(UiTextColors, 2, Ww - 9, 2, 29, MapBuffer);

            const int column1 = 5;
            const int starty1 = 5;
            const int starty2 = 17;
            const int column2 = 60;

            MapBuffer.Draw("Paintbrush Options", column1, starty1, UiTextColors);
            MapBuffer.Draw("--------------------------------", column1, starty1 + 1, UiTextColors);
            MapBuffer.Draw("(A-Z) Change Background Color", column1, starty1 + 2, UiTextColors);
            MapBuffer.Draw("(F-G) Change Foreground Color", column1, starty1 + 3, UiTextColors);
            MapBuffer.Draw("(W) Change Collidible", column1, starty1 + 5, UiTextColors);
            MapBuffer.Draw("(X) Change Destructible", column1, starty1 + 6, UiTextColors);
            MapBuffer.Draw("(T) Change Paint Character", column1, starty1 + 8, UiTextColors);
            MapBuffer.Draw("(Delete) Set Paint Character to Eraser", column1, starty1 + 9, UiTextColors);

            MapBuffer.Draw("Layer Options", column1, starty2, UiTextColors);
            MapBuffer.Draw("--------------------------------", column1, starty2 + 1, UiTextColors);
            MapBuffer.Draw("(E) Change Layer", column1, starty2 + 2, UiTextColors);
            MapBuffer.Draw("(D) Toggle Layer", column1, starty2 + 3, UiTextColors);
            MapBuffer.Draw("(E) Change Layer", column1, starty2 + 4, UiTextColors);

            MapBuffer.Draw("Commands", column2, starty1, UiTextColors);
            MapBuffer.Draw("--------------------------------", column2, starty1 + 1, UiTextColors);
            MapBuffer.Draw("(V) Fill Rectangle Command", column2, starty1 + 2, UiTextColors);
            MapBuffer.Draw("(L) Draw Line Command", column2, starty1 + 3, UiTextColors);
            MapBuffer.Draw("(C) Draw Circle Command", column2, starty1 + 4, UiTextColors);
            MapBuffer.Draw("(Space) Paint Single Pixel", column2, starty1 + 5, UiTextColors);
            MapBuffer.Draw("(F1) Save Map", column2, starty1 + 7, UiTextColors);

            MapBuffer.Print();
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Console.ReadKey(false);
            MapBuffer.ClearRow(30);
            StartDraw();
        }

        public static void StartDraw()
        {
            StartWorkingSpace();
            UpdateUiCurrentPix();
            UpdateUiPaintPrefs();
            UpdateUiLayer();
        }

        public static void InputHandling()
        {
            var controller = GamePad.GetState(PlayerIndex.One).IsConnected;

            if (Keyboard.IsKeyDown(Key.Right) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1)))
            {
                if (HuidigeCursor.X + 1 < CurrentMapInEditor.Layers[Maplayers.Collision].Background.GetLength(1))
                {
                    HuidigeCursor.X++;
                    HuidigeCursor.UpdateCursorValues(CurrentMapInEditor, ActiveLayer);
                    UpdateUiCurrentPix();
                }
            }
            if (Keyboard.IsKeyDown(Key.Left) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1)))
            {
                if (HuidigeCursor.X - 1 >= 0)
                {
                    HuidigeCursor.X--;
                    HuidigeCursor.UpdateCursorValues(CurrentMapInEditor, ActiveLayer);
                    UpdateUiCurrentPix();
                }
            }
            if (Keyboard.IsKeyDown(Key.Up) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1)))
            {
                if (HuidigeCursor.Y - 1 >= 0)
                {
                    HuidigeCursor.Y--;
                    HuidigeCursor.UpdateCursorValues(CurrentMapInEditor, ActiveLayer);
                    UpdateUiCurrentPix();
                }
            }
            if (Keyboard.IsKeyDown(Key.Down) || (controller && (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1)))
            {
                if (HuidigeCursor.Y + 1 < CurrentMapInEditor.Layers[Maplayers.Collision].Background.GetLength(0))
                {
                    HuidigeCursor.Y++;
                    HuidigeCursor.UpdateCursorValues(CurrentMapInEditor, ActiveLayer);
                    UpdateUiCurrentPix();
                }
            }

            //Keyboard buttons that should have some delay.
            if (KeypressTimer == 0 && HuidigeCursor.Locked == false)
            {
                if (Keyboard.IsKeyDown(Key.A))
                {
                    HuidigeCursor.ToggleBgColor(false);
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.Delete))
                {
                    HuidigeCursor.PaintChar = null;
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }

                else if (Keyboard.IsKeyDown(Key.Z))
                {
                    HuidigeCursor.ToggleBgColor(true);
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.Q))
                {
                    HuidigeCursor.ToggleFgColor(false);
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.S))
                {
                    HuidigeCursor.ToggleFgColor(true);
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.T))
                {
                    HuidigeCursor.ToggleChar();
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.W))
                {
                    HuidigeCursor.ToggleCollide();
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.X))
                {
                    HuidigeCursor.ToggleDestructible();
                    UpdateUiPaintPrefs();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.E))
                {
                    NextLayer();
                    UpdateUiLayer();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.D))
                {
                    ToggleLayer();
                    UpdateUiLayer();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.Space))
                {
                    Draw.PaintPixel(CurrentMapInEditor, HuidigeCursor, ActiveLayer);
                    UpdateUiCurrentPix();
                    DrawActiveLayers();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.L))
                {
                    DrawLineCommand();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.C))
                {
                    DrawCircleCommand();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.V))
                {
                    DrawRectangleCommand();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.F1))
                {
                    SaveMapCommand();
                    KeypressTimer = 10;
                }
                else if (Keyboard.IsKeyDown(Key.F10))
                {
                    HelpScreen();
                    KeypressTimer = 10;
                }

                else if (Keyboard.IsKeyDown(Key.Enter))
                {
                    if (ContinueCommand != null)
                    {
                        ContinueCommand.TrySetResult(null);
                    }
                    KeypressTimer = 10;
                }
            }

            if (KeypressTimer > 0)
            {
                KeypressTimer--;
            }
        }

        public static int Wh = Console.WindowHeight;
        public static int UiLine = Wh - 12;
        public static int UiControls = Wh - 11;
        public static int UiCurrentPixel = Wh - 9;
        public static int UiPaints = Wh - 7;
        public static int UiLayers = Wh - 5;
        public static int UiSysMes = Wh - 3;
    }
}