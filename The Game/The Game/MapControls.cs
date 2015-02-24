using System;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed
{
    public class MapControls
    {
        public static void DrawMap()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            Console.Clear();
            Game.CurrentLoadedMap = new CustomMap(Console.WindowHeight, Console.WindowWidth, false);
            TerrainSelection.Redirect(Game.CurrentLoadedMap, 202, false);
            Gameplay.Push();
            Game.CurrentLoadedMap.Layers[Maplayers.Air].LayerToBuffer(Game.GameBuffer);
            Game.CurrentLoadedMap.Layers[Maplayers.Collision].LayerToBuffer(Game.GameBuffer);
            Game.CurrentLoadedMap.Layers[Maplayers.Destructible].LayerToBuffer(Game.GameBuffer);
            Game.GameBuffer.Print();
            Endgame.PlayMusic();
            DrawMapBg();
            MoveUser();
        }

        public static void DrawMapBg()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.DarkCyan);
            Console.SetCursorPosition(MapDrawing.Xposmin - 1, MapDrawing.Yposmin - 1);

            for (var x = MapDrawing.Xposmin - 1; x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal + 1; x++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(MapDrawing.Xposmin - 1, MapDrawing.Yposmin + (MapDrawing.VerticalBlockLength + 2)*MapGeneration.RoomsVertical + 1);
            for (var x = MapDrawing.Xposmin - 1; x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal + 1; x++)
            {
                Console.Write("-");
            }
            for (var y = MapDrawing.Yposmin; y <= MapDrawing.Yposmin + (MapDrawing.VerticalBlockLength + 2)*MapGeneration.RoomsVertical; y++)
            {
                Console.SetCursorPosition(MapDrawing.Xposmin, y);
                for (var x = MapDrawing.Xposmin; x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal; x++)
                {
                    Console.Write(" ");
                }
            }
        }

        public static void MoveUser()
        {
            MapDrawing.ShowMap();
            var xpostemp = MapDrawing.Xposcurrent;
            var ypostemp = MapDrawing.Yposcurrent;
            var preXCalc = (MapDrawing.Xposmin + MapDrawing.Xposcurrent*(MapDrawing.HorizontalBlockLength + 2) + MapDrawing.HorizontalBlockLength/2);
            var preYCalc = (MapDrawing.Yposmin + MapDrawing.Yposcurrent*(MapDrawing.VerticalBlockLength + 2) + MapDrawing.VerticalBlockLength/2);

            Console.SetCursorPosition(preXCalc, preYCalc);
            DrawPerson();
            var input = InputHandler.ControlInputHandling();
            switch (input)
            {
                case Buttons.DPadDown:
                case Buttons.LeftThumbstickDown:
                    if (MapGeneration.Corridors[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, 3])
                    {
                        Console.SetCursorPosition(preXCalc, preYCalc);
                        LeftoverPerson();
                        MapDrawing.Yposcurrent++;
                    }
                    break;
                case Buttons.DPadLeft:
                case Buttons.LeftThumbstickLeft:
                    if (MapGeneration.Corridors[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, 0])
                    {
                        Console.SetCursorPosition(preXCalc, preYCalc);
                        LeftoverPerson();
                        MapDrawing.Xposcurrent--;
                    }
                    break;
                case Buttons.DPadRight:
                case Buttons.LeftThumbstickRight:
                    if (MapGeneration.Corridors[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, 2])
                    {
                        Console.SetCursorPosition(preXCalc, preYCalc);
                        LeftoverPerson();
                        MapDrawing.Xposcurrent++;
                    }
                    break;
                case Buttons.DPadUp:
                case Buttons.LeftThumbstickUp:
                    if (MapGeneration.Corridors[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, 1])
                    {
                        Console.SetCursorPosition(preXCalc, preYCalc);
                        LeftoverPerson();
                        MapDrawing.Yposcurrent--;
                    }
                    break;
            }
            MapDrawing.ShowMap();
            preXCalc = (MapDrawing.Xposmin + MapDrawing.Xposcurrent*(MapDrawing.HorizontalBlockLength + 2) + MapDrawing.HorizontalBlockLength/2);
            preYCalc = (MapDrawing.Yposmin + MapDrawing.Yposcurrent*(MapDrawing.VerticalBlockLength + 2) + MapDrawing.VerticalBlockLength/2);
            Console.SetCursorPosition(preXCalc, preYCalc);
            DrawPerson();
            if (MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] != true)
            {
                bool corBut;
                do
                {
                    corBut = false;
                    input = InputHandler.ControlInputHandling();
                    switch (input)
                    {
                        case Buttons.A:
                            Game.CurrentLoadedMap = new CustomMap(Console.WindowHeight - 10, Console.WindowWidth, false);

                            Console.Clear();
                            Game.GameBuffer.Clear();
                            corBut = true;
                            TerrainSelection.Redirect(Game.CurrentLoadedMap, MapGeneration.Terrains[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent]);
                            Gameplay.EnableTerrain();
                            MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] = true;
                            DrawMap();
                            break;
                        case Buttons.Back:
                            corBut = true;
                            Console.SetCursorPosition(preXCalc, preYCalc);
                            if (MapDrawing.HorizontalBlockLength >= 7)
                            {
                                LeftoverPerson();
                            }
                            MapDrawing.Xposcurrent = xpostemp;
                            MapDrawing.Yposcurrent = ypostemp;
                            MoveUser();
                            break;
                    }
                } while (!corBut);
            }
            MoveUser();
        }

        public static void LeftoverPerson()
        {
            Console.BackgroundColor = MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] ? Painter.Instance.Paint(ConsoleColor.DarkGreen) : Painter.Instance.Paint(ConsoleColor.DarkRed);

            Console.Write("   ");
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
        }

        public static void DrawPerson()
        {
            Console.BackgroundColor = MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] ? Painter.Instance.Paint(ConsoleColor.DarkGreen) : Painter.Instance.Paint(ConsoleColor.DarkRed);
            Console.Write(MapDrawing.HorizontalBlockLength >= 7 ? "'-'" : "o");
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
        }
    }
}