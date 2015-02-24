using System;

namespace Confusing_Hobo_Unleashed
{
    public class MapDrawing
    {
        public static bool Map = false;
        public static bool MapRetrievable = false;
        public static bool FindRooms = false;
        public static bool MapDrawn;
        public static int Xposcurrent = MapGeneration.RoomsHorizontal/2;
        public static int Yposcurrent = MapGeneration.RoomsVertical/2;
        public static bool[,] RoomFound = new bool[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical];
        //MAIN MAP DRAWING METHOD
        public static void ShowMap()
        {
            if (Map) MapFound();
            else if (FindRooms)
                DrawRoomsFound();
            else
            {
                MapControls.DrawMapBg();
                DrawRooms(Xposcurrent, Yposcurrent);
            }
        }

        //EXECUTE IF MAP ENABLED/FOUND
        public static void MapFound()
        {
            for (var xpos = 0; xpos < MapGeneration.RoomsHorizontal; xpos++)
            {
                for (var ypos = 0; ypos < MapGeneration.RoomsVertical; ypos++)
                {
                    if (MapGeneration.Counter[xpos, ypos, 4])
                    {
                        if (!MapDrawn)
                        {
                            DrawRooms(xpos, ypos);
                        }
                    }
                }
            }
            MapDrawn = true;
        }

        //EXECUTES IF ROOMS FOUND IS ENABLED
        public static void DrawRoomsFound()
        {
            for (var xpos = 0; xpos < MapGeneration.RoomsHorizontal; xpos++)
            {
                for (var ypos = 0; ypos < MapGeneration.RoomsVertical; ypos++)
                {
                    if (MapGeneration.Corridors[xpos, ypos, 4])
                    {
                        DrawRooms(xpos, ypos);
                    }
                }
            }
        }

        //DRAWS ROOMS LOCATED IN/FOUND

        public static void DrawRooms(int xpos, int ypos)
        {
            var xposLoc = Xposmin + xpos*(HorizontalBlockLength + 2);
            var yposLoc = Yposmin + ypos*(VerticalBlockLength + 2);

            if (MapGeneration.Corridors[xpos, ypos, 0])
            {
                for (var z = 0; z <= VerticalBlockLength/2; z++)
                {
                    Console.SetCursorPosition(xposLoc, z + yposLoc);
                    Console.Write("|");
                }
                for (var z = VerticalBlockLength/2 + 2; z <= VerticalBlockLength; z++)
                {
                    Console.SetCursorPosition(xposLoc, z + yposLoc);
                    Console.Write("|");
                }
            }
            else
            {
                for (var z = 0; z <= VerticalBlockLength; z++)
                {
                    Console.SetCursorPosition(xposLoc, z + yposLoc);
                    Console.Write("|");
                }
            }
            if (MapGeneration.Corridors[xpos, ypos, 1])
            {
                for (var z = 1; z <= HorizontalBlockLength/2 - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc);

                    Console.Write("-");
                }
                for (var z = HorizontalBlockLength/2 + 2; z <= HorizontalBlockLength - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc);

                    Console.Write("-");
                }
            }
            else
            {
                for (var z = 1; z <= HorizontalBlockLength - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc);

                    Console.Write("-");
                }
            }
            if (MapGeneration.Corridors[xpos, ypos, 2])
            {
                for (var z = 0; z <= VerticalBlockLength/2; z++)
                {
                    Console.SetCursorPosition(xposLoc + HorizontalBlockLength, z + yposLoc);
                    Console.Write("|");
                }
                for (var z = VerticalBlockLength/2 + 2; z <= VerticalBlockLength; z++)
                {
                    Console.SetCursorPosition(xposLoc + HorizontalBlockLength, z + yposLoc);
                    Console.Write("|");
                }
            }
            else
            {
                for (var z = 0; z <= VerticalBlockLength; z++)
                {
                    Console.SetCursorPosition(xposLoc + HorizontalBlockLength, z + yposLoc);
                    Console.Write("|");
                }
            }
            if (MapGeneration.Corridors[xpos, ypos, 3])
            {
                for (var z = 1; z <= HorizontalBlockLength/2 - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc + VerticalBlockLength);

                    Console.Write("-");
                }
                for (var z = HorizontalBlockLength/2 + 2; z <= HorizontalBlockLength - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc + VerticalBlockLength);
                    Console.Write("-");
                }
            }
            else
            {
                for (var z = 1; z <= HorizontalBlockLength - 1; z++)
                {
                    Console.SetCursorPosition(xposLoc + z, yposLoc + VerticalBlockLength);
                    Console.Write("-");
                }
            }
        }

        //LIST OF REQUIRED VARS PER METHOD:
        //MapFound: Corridors
        //DrawRoomsFound: RoomsHorizontal, RoomsVertical, Corridors, MapRegister
        //DrawRooms: XPOS, YPOS, Corridors
        public static int HorizontalBlockLength = 11;
        public static int VerticalBlockLength = 7;

        public static int Xposmin = (Console.WindowWidth - ((HorizontalBlockLength + 2)*MapGeneration.RoomsHorizontal))/
                                    2;

        public static int Yposmin = (Game.CurrentLoadedMap.Mapheight -
                                     (VerticalBlockLength + 2)*MapGeneration.RoomsVertical)/2;
    }
}