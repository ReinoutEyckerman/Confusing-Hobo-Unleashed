using System;
using System.Threading;

namespace Confusing_Hobo_Unleashed
{
    public class MapGeneration
    {
        private static int _x1;
        private static int _x2;
        private static int _x3;
        private static int _x4;
        private static int _x5;
        private static int _x6;
        private static int _x7;
        public static int DeadEndAmount;
        public static int MaxDeadEnd;
        public static int Approved;
        public static double ApprovementReq = 75;
        public static int FailureCounter;

        public static void Clearvars()
        {
            foreach (var t in StartMenu.Configuration)
                if (t.Name == "Spawn Point")
                {
                    MapDrawing.Xposcurrent = t.TextBoxList[0].VarChanger[0];
                    MapDrawing.Yposcurrent = t.TextBoxList[0].VarChanger[1];
                }
            Corridors = new bool[RoomsHorizontal, RoomsVertical, 5];
            Counter = new bool[RoomsHorizontal, RoomsVertical, 5];
            EnableMoreCorridors = new int[RoomsHorizontal*RoomsVertical, 2];
            FailureCounter = 0;
            Terrains = new int[RoomsHorizontal, RoomsVertical];
            Approved = 0;
            _x1 = 0;
            _x2 = 0;
            _x3 = 0;
            _x4 = 0;
            _x5 = 0;
            _x6 = 0;
            _x7 = 0;
            DeadEndAmount = 0;
        }

        //MAPGENERATING AND FIXING MAIN METHOD
        public static void MainMapFix(int xPos, int yPos, int[,] enableMoreCorridors)
        {
            if (VarDatabase.ShowDeadEnd)
                ShowDead();
            if (VarDatabase.ShowApprovementRate)
            {
                Console.WriteLine(Convert.ToDouble((ApprovementReq)/(Convert.ToDouble(RoomsHorizontal*RoomsVertical))*100));
            }
            if (VarDatabase.ShowSideMatrix)
            {
                ShowMatrix();
            }
            Tester(MapDrawing.Xposcurrent, MapDrawing.Yposcurrent, Counter, enableMoreCorridors);
            _x7 = _x6;
            _x6 = _x5;
            _x5 = _x4;
            _x4 = _x3;
            _x3 = _x2;
            _x2 = _x1;
            _x1 = Approved;
            var testvar = Convert.ToInt32(RoomsHorizontal*RoomsVertical*ApprovementReq/100);

            if (Approved >= testvar)
            {
                return;
            }
            if ((_x1 + _x2 + _x3 + _x4 + _x5 + _x6 + _x7)/7 == _x1)
            {
                if (VarDatabase.Debug)
                {
                    Console.WriteLine("Advanced Generation Failed.");
                    Console.WriteLine("Regenerating...");
                }
                Array.Clear(Corridors, 0, RoomsHorizontal*RoomsVertical*5);
                _x1 = _x2 = _x3 = _x4 = _x5 = _x6 = _x7 = 0;
                FailureCounter++;
                if (FailureCounter >= 35)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Map generation took too long. Are you sure you configured it right? Rebooting in 5 seconds, please check the configuration.");
                    Thread.Sleep(5000);
                }
                GenerateCorridors();
            }
            if (DeadEndAmount >= 1)
            {
                Thread.Sleep(20);
                FixMap(enableMoreCorridors);
            }
            DeadEndAmount = 0;
            Approved = 0;
            Array.Clear(Counter, 0, RoomsHorizontal*RoomsVertical*5);

            MainMapFix(xPos, yPos, enableMoreCorridors);
        }

        //GENERATES BASIC MAP (THIS IS THE BASIC MAP, THIS IS NOT FIXED FOR COMPLETION.)
        public static void GenerateCorridors()
        {
            for (var yCoord = 0; yCoord < RoomsVertical; yCoord++)
            {
                for (var xCoord = 0; xCoord < RoomsHorizontal; xCoord++)
                {
                    var random = new Random();
                    var randomEast = random.Next(6);
                    var randomSouth = random.Next(6);
                    //0: Disabled. 1: Enabled. 2: Forced enabled
                    int west;
                    int north;
                    var east = 1;
                    var south = 1;
                    //Fixing 0 Coords
                    if (xCoord > 0 && Corridors[xCoord - 1, yCoord, 2])
                    {
                        west = 2;
                    }
                    else west = 0;
                    if (west == 2)
                    {
                        Corridors[xCoord, yCoord, 0] = true;
                    }
                    else Corridors[xCoord, yCoord, 0] = false;

                    //Fixing 1 Coords
                    if (yCoord > 0 && Corridors[xCoord, yCoord - 1, 3])

                    {
                        north = 1;
                    }
                    else north = 0;
                    if (north == 1)
                    {
                        Corridors[xCoord, yCoord, 1] = true;
                    }
                    else Corridors[xCoord, yCoord, 1] = false;
                    //Fixing 2 Coords

                    if (xCoord == RoomsHorizontal - 1 || randomEast > 1)
                    {
                        east = 0;
                    }
                    if (east == 1 || east == 2)
                    {
                        Corridors[xCoord, yCoord, 2] = true;
                    }
                    else Corridors[xCoord, yCoord, 2] = false;
                    //Fixing 3 Coords
                    if (yCoord == RoomsVertical - 1 || randomSouth < 4)
                    {
                        south = 0;
                    }
                    if (south == 1 || south == 2)
                    {
                        Corridors[xCoord, yCoord, 3] = true;
                    }
                    else Corridors[xCoord, yCoord, 3] = false;
                    Thread.Sleep(10);
                }
            }
        }

        //CHECKS IF GENERATED/FIXED MAP FULFILLS REQUIREMENTS BY TRACING THE AMOUNT OF ROOMS REACHABLE FROM STARTING POINT X Y
        public static void Tester(int xPos, int yPos, bool[,,] counter, int[,] enableMoreCorridors)
        {
            if (counter[xPos, yPos, 0] != true && counter[xPos, yPos, 1] != true && counter[xPos, yPos, 2] != true && counter[xPos, yPos, 3] != true)
            {
                if (counter[xPos, yPos, 4] != true)
                {
                    Approved += 1;
                    counter[xPos, yPos, 4] = true;
                }

                if (Corridors[xPos, yPos, 0] && counter[xPos, yPos, 0] != true)
                {
                    counter[xPos, yPos, 0] = true;
                    if (xPos > 0)
                    {
                        Tester(xPos - 1, yPos, counter, enableMoreCorridors);
                    }
                }
                if (Corridors[xPos, yPos, 1] && counter[xPos, yPos, 1] != true)
                {
                    counter[xPos, yPos, 1] = true;

                    if (yPos > 0)
                    {
                        Tester(xPos, yPos - 1, counter, enableMoreCorridors);
                    }
                }
                if (Corridors[xPos, yPos, 2] && counter[xPos, yPos, 2] != true)
                {
                    counter[xPos, yPos, 2] = true;
                    if (xPos < RoomsHorizontal - 1)
                    {
                        Tester(xPos + 1, yPos, counter, enableMoreCorridors);
                    }
                }
                if (Corridors[xPos, yPos, 3] && counter[xPos, yPos, 3] != true)
                {
                    counter[xPos, yPos, 3] = true;

                    if (yPos < RoomsVertical - 1)
                    {
                        Tester(xPos, yPos + 1, counter, enableMoreCorridors);
                    }
                }
                var y = 0;
                for (var x = 0; x <= 3; x++)
                {
                    if (counter[xPos, yPos, x])
                    {
                        y++;
                    }
                }
                counter[xPos, yPos, 4] = true;
                if ((xPos != 0 && yPos != 0) || (xPos != 0 && yPos != RoomsVertical) || (xPos != RoomsHorizontal && yPos != 0) || (xPos != RoomsHorizontal && yPos != RoomsVertical) && (y <= 1))
                {
                    enableMoreCorridors[DeadEndAmount, 0] = xPos;
                    enableMoreCorridors[DeadEndAmount, 1] = yPos;
                    DeadEndAmount++;
                }
            }
        }

        //--DO NOT TOUCH-- MAP FIXING ALGORITHM, GETS CLOSER TO FULFILLING REQUIREMENTS OF THE MAP --DO NOT TOUCH--
        public static void FixMap(int[,] enableMoreCorridors)
        {
            var error = false;
            var randomNum = new Random();
            if (DeadEndAmount > MaxDeadEnd)
            {
                DeadEndAmount = MaxDeadEnd;
            }

            for (var x = 0; x < DeadEndAmount; x += 3)
            {
                var fixMapX = enableMoreCorridors[x, 0];
                var fixMapY = enableMoreCorridors[x, 1];
                if (Corridors[fixMapX, fixMapY, 0])
                {
                    do
                    {
                        var random = randomNum.Next(5);
                        switch (random)
                        {
                            case 0:
                                if (fixMapY > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 1] = true;
                                    Corridors[fixMapX, fixMapY - 1, 3] = true;
                                    error = true;
                                }
                                else random = 1;
                                break;
                            case 1:
                                if (fixMapX < RoomsHorizontal - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 2] = true;
                                    Corridors[fixMapX + 1, fixMapY, 0] = true;
                                    error = true;
                                }
                                else random = 2;
                                break;
                            case 2:
                                if (fixMapY < RoomsVertical - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 3] = true;
                                    Corridors[fixMapX, fixMapY + 1, 1] = true;
                                    error = true;
                                }
                                else random = 0;
                                break;
                        }
                    } while (error == false);
                }
                else if (Corridors[fixMapX, fixMapY, 1])
                {
                    do
                    {
                        var random = randomNum.Next(5);
                        switch (random)
                        {
                            case 0:

                                if (fixMapY < RoomsVertical - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 3] = true;
                                    Corridors[fixMapX, fixMapY + 1, 1] = true;
                                    error = true;
                                }
                                else random = 1;
                                break;
                            case 1:
                                if (fixMapX < RoomsHorizontal - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 2] = true;
                                    Corridors[fixMapX + 1, fixMapY, 0] = true;
                                    error = true;
                                }
                                else random = 2;
                                break;
                            case 2:
                                if (fixMapX > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 0] = true;
                                    Corridors[fixMapX - 1, fixMapY, 2] = true;
                                    error = true;
                                }
                                else random = 0;
                                break;
                        }
                    } while (error == false);
                }
                else if (Corridors[fixMapX, fixMapY, 2])
                {
                    do
                    {
                        var random = randomNum.Next(5);
                        switch (random)
                        {
                            case 0:
                                if (fixMapX > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 0] = true;
                                    Corridors[fixMapX - 1, fixMapY, 2] = true;
                                    error = true;
                                }
                                else random = 1;

                                break;
                            case 1:
                                if (fixMapY < RoomsVertical - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 3] = true;
                                    Corridors[fixMapX, fixMapY + 1, 1] = true;
                                    error = true;
                                }
                                else random = 2;
                                break;
                            case 2:
                                if (fixMapY > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 1] = true;
                                    Corridors[fixMapX, fixMapY - 1, 3] = true;
                                    error = true;
                                }
                                else random = 0;
                                break;
                        }
                    } while (error == false);
                }
                else if (Corridors[fixMapX, fixMapY, 3])
                {
                    do
                    {
                        var random = randomNum.Next(5);
                        switch (random)
                        {
                            case 0:
                                if (fixMapX > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 0] = true;
                                    Corridors[fixMapX - 1, fixMapY, 2] = true;
                                    error = true;
                                }
                                else random = 1;
                                break;
                            case 1:
                                if (fixMapY > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 1] = true;
                                    Corridors[fixMapX, fixMapY - 1, 3] = true;
                                    error = true;
                                }
                                else random = 2;
                                break;
                            case 2:
                                if (fixMapX < RoomsHorizontal - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 2] = true;
                                    Corridors[fixMapX + 1, fixMapY, 0] = true;
                                    error = true;
                                }
                                else random = 0;
                                break;
                        }
                    } while (error == false);
                }
                else
                {
                    do
                    {
                        var random = randomNum.Next(5);
                        switch (random)
                        {
                            case 0:
                                if (fixMapX > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 0] = true;
                                    Corridors[fixMapX - 1, fixMapY, 2] = true;
                                    error = true;
                                }
                                break;
                            case 1:
                                if (fixMapY > 0)
                                {
                                    Corridors[fixMapX, fixMapY, 1] = true;
                                    Corridors[fixMapX, fixMapY - 1, 3] = true;
                                    error = true;
                                }
                                break;
                            case 2:
                                if (fixMapX < RoomsHorizontal - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 2] = true;
                                    Corridors[fixMapX + 1, fixMapY, 0] = true;
                                    error = true;
                                }
                                break;
                            case 3:
                                if (fixMapY < RoomsVertical - 1)
                                {
                                    Corridors[fixMapX, fixMapY, 3] = true;
                                    Corridors[fixMapX, fixMapY + 1, 1] = true;
                                    error = true;
                                }
                                break;
                        }
                    } while (error == false);
                }
                Thread.Sleep(20);
            }
        }

        // USED FOR ATTEMPTING TO FIX THE MAP ALGORITHMS IN CASE YOU TOUCHED IT
        public static void ShowDead()
        {
            var x = 0;
            foreach (var item in EnableMoreCorridors)
            {
                Console.WriteLine("Dead end" + x/2 + ":".PadRight(30) + item);
                x++;
            }
            Console.ReadLine();
        }

        //F USED FOR ATTEMPTING TO FIX THE MAP ALGORITHMS IN CASE YOU TOUCHED IT
        public static void ShowMatrix()
        {
            Console.WriteLine("WEST MATRIX");
            for (var yCoord = 0; yCoord < RoomsVertical; yCoord++)
            {
                for (var xCoord = 0; xCoord < RoomsHorizontal; xCoord++)
                {
                    Console.Write(Corridors[xCoord, yCoord, 0]);
                }
                Console.Write('\n');
            }
            Console.WriteLine("\n NORTH MATRIX");
            for (var yCoord = 0; yCoord < RoomsVertical; yCoord++)
            {
                for (var xCoord = 0; xCoord < RoomsHorizontal; xCoord++)
                {
                    Console.Write(Corridors[xCoord, yCoord, 1]);
                }
                Console.Write('\n');
            }
            Console.WriteLine("\n EAST MATRIX");
            for (var yCoord = 0; yCoord < RoomsVertical; yCoord++)
            {
                for (var xCoord = 0; xCoord < RoomsHorizontal; xCoord++)
                {
                    Console.Write(Corridors[xCoord, yCoord, 2]);
                }
                Console.Write('\n');
            }
            Console.WriteLine("\n SOUTH MATRIX");
            for (var yCoord = 0; yCoord < RoomsVertical; yCoord++)
            {
                for (var xCoord = 0; xCoord < RoomsHorizontal; xCoord++)
                {
                    Console.Write(Corridors[xCoord, yCoord, 3]);
                }
                Console.Write('\n');
            }
            Console.ReadLine();
        }

        public static int RoomsHorizontal = 7;
        public static int RoomsVertical = 4;
        public static bool[,,] Corridors = new bool[RoomsHorizontal, RoomsVertical, 5];
        public static bool[,,] Counter = new bool[RoomsHorizontal, RoomsVertical, 5];
        public static int[,] EnableMoreCorridors = new int[RoomsHorizontal*RoomsVertical, 2];
        public static int[,] Terrains = new int[RoomsHorizontal, RoomsVertical];
    }
}