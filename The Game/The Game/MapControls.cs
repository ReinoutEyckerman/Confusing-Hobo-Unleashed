using System;
using Confusing_Hobo_Unleashed.Map;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed
{
    public class MapControls
    {
        public static void DrawMap()
        {
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
            Console.Clear();
            Game.CurrentLoadedMap = new CustomMap(Console.WindowHeight, Console.WindowWidth, false);
            TerrainSelection.Redirect(Game.CurrentLoadedMap, 202);
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
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkCyan;
            Console.SetCursorPosition(MapDrawing.Xposmin - 1, MapDrawing.Yposmin - 1);

            for (int x = MapDrawing.Xposmin - 1; x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal + 1; x++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(MapDrawing.Xposmin - 1, MapDrawing.Yposmin + (MapDrawing.VerticalBlockLength + 2)*MapGeneration.RoomsVertical + 1);
            for (int x = MapDrawing.Xposmin - 1;
                x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal + 1;
                x++)
            {
                Console.Write("-");
            }
            for (int y = MapDrawing.Yposmin; y <= MapDrawing.Yposmin + (MapDrawing.VerticalBlockLength + 2)*MapGeneration.RoomsVertical; y++)
            {
                Console.SetCursorPosition(MapDrawing.Xposmin, y);
                for (int x = MapDrawing.Xposmin; x <= MapDrawing.Xposmin + (MapDrawing.HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal; x++)
                {
                    Console.Write(" ");
                }
            }
        }

        public static void MoveUser()
        {
            MapDrawing.ShowMap();
            int xpostemp = MapDrawing.Xposcurrent;
            int ypostemp = MapDrawing.Yposcurrent;
            int preXCalc = (MapDrawing.Xposmin + MapDrawing.Xposcurrent*(MapDrawing.HorizontalBlockLength + 2) +
                            MapDrawing.HorizontalBlockLength/2);
            int preYCalc = (MapDrawing.Yposmin + MapDrawing.Yposcurrent*(MapDrawing.VerticalBlockLength + 2) +
                            MapDrawing.VerticalBlockLength/2);

            Console.SetCursorPosition(preXCalc, preYCalc);
            DrawPerson();
            Buttons input = InputHandler.ControlInputHandling();
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
            Console.BackgroundColor = MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] ? VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen : VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;

            Console.Write("   ");
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
        }

        public static void DrawPerson()
        {
            Console.BackgroundColor = MapDrawing.RoomFound[MapDrawing.Xposcurrent, MapDrawing.Yposcurrent] ? VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkGreen : VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].DarkRed;
            Console.Write(MapDrawing.HorizontalBlockLength >= 7 ? "'-'" : "o");
            Console.BackgroundColor = VarDatabase.ColorScheme.BackGroundList[VarDatabase.ColorSchemenumber].Black;
        }
    }
}