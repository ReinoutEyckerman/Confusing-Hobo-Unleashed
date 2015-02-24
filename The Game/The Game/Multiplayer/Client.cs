using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.User;
using Lidgren.Network;
using Timer = System.Timers.Timer;

// Lidgren Network example
// Made by: Riku Koskinen
// http://xnacoding.blogspot.com/
// Download LidgreNetwork at: http://code.google.com/p/lidgren-network-gen3/
//
// You can use this code in anyway you want
// Code is not perfect, but it works
// It's example of console based game, where new players can join and move
// Movement is updated to all clients.

namespace Confusing_Hobo_Unleashed.Multiplayer
{
    internal class Client
    {
        private static NetClient _client;
        private static Timer _update;
        public static int PlayerNumber;
        public static Key[] Input = new Key[9];
        private static readonly Stopwatch FrameTimer = new Stopwatch();

        public static void Start()
        {
            Console.ForegroundColor = Painter.Instance.Paint(ConsoleColor.White);
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Enter IP To Connect");
            string hostip;
            do
            {
                hostip = Console.ReadLine();
                if (Uri.CheckHostName(hostip) != UriHostNameType.IPv4)
                    Console.WriteLine("Faulty IP entered. Please try again.");
            } while (Uri.CheckHostName(hostip) != UriHostNameType.IPv4);
            var config = new NetPeerConfiguration("game");
            _client = new NetClient(config);
            var outmsg = _client.CreateMessage();
            _client.Start();
            outmsg.Write((byte) PacketTypes.Login);
            var user = new Player(Game.CurrentLoadedMap, 3, 3, 100,
                Encoding.GetEncoding(437).GetChars(new byte[] {001})[0],
                Painter.Instance.Paint(ConsoleColor.Black),
                Painter.Instance.Paint(ConsoleColor.White,true));
            LidgrenAdaptions.CompileCore(outmsg, user);
            _client.Connect(hostip, 22401, outmsg);
            Console.WriteLine("Client Started");
            Game.Players = new List<Player>();
            _update = new Timer(50);
            _update.Elapsed += update_Elapsed;
            WaitForStartingInfo();
            _update.Start();
            while (true)
            {
                Game.Render();
                GetInput();
            }
        }

        private static void update_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckServerMessages();
        }

        private static void WaitForStartingInfo()
        {
            var canStart = false;
            while (!canStart)
            {
                NetIncomingMessage inc;
                if ((inc = _client.ReadMessage()) != null)
                {
                    switch (inc.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            if (inc.ReadByte() == (byte) PacketTypes.Worldstate)
                            {
                                Console.WriteLine("PLAYERNUMBER ARRIVED");
                                //READING MAP
                                int mapheight = inc.ReadInt16();
                                int mapwidth = inc.ReadInt16();
                                Game.CurrentLoadedMap = new CustomMap(mapheight, mapwidth, false);
                                LidgrenAdaptions.OneReadList(inc);
                                //
                                PlayerNumber = inc.ReadInt16();
                                var count = Convert.ToInt16(PlayerNumber + 1);
                                for (var i = 0; i < count; i++)
                                {
                                    // Create new character to hold the data
                                    var ch = new Player(Game.CurrentLoadedMap);
                                    // Read all properties ( Server writes characters all props, so now we can read em here. Easy )
                                    LidgrenAdaptions.DecompileCore(inc, ch);
                                    // Add it to list
                                    Game.Players.Add(ch);
                                }
                                Game.FillEntities();
                                canStart = true;
                            }
                            break;

                        default:
                            Console.WriteLine(inc.ReadString() + " Strange message");
                            break;
                    }
                }
            }
        }

        private static void CheckServerMessages()
        {
            NetIncomingMessage inc;
            while ((inc = _client.ReadMessage()) != null)
            {
                if (inc.MessageType == NetIncomingMessageType.Data)
                {
                    var packet = inc.ReadByte();
                    if (packet == (byte) PacketTypes.Worldstate2)
                    {
                        var count = inc.ReadInt16();
                        for (var i = 0; i < count; i++)
                        {
                            LidgrenAdaptions.DecompileCore(inc, Game.Players[i]);
                        }
                        count = inc.ReadInt16();
                        Game.Bullets = new List<BulletCore>();
                        for (var i = 0; i < count; i++)
                        {
                            var bullet = new BulletCore();
                            LidgrenAdaptions.DeCompileBullet(inc, bullet);
                            Game.Bullets.Add(bullet);
                        }
                        var change = inc.ReadBoolean();
                        if (change)
                            LidgrenAdaptions.VarReadList(inc);
                    }
                    else if (packet == (byte) PacketTypes.Newplayer)
                    {
                        PlayerNumber = inc.ReadByte();
                        Game.Players.Add(new Player(Game.CurrentLoadedMap));
                        Game.Entities.Clear();
                        Game.FillEntities();
                        LidgrenAdaptions.DecompileCore(inc, Game.Players[Game.Players.Count - 1]);
                    }
                }
            }
        }

        // Get input from player and send it to server

        private static void GetInput()
        {
            FrameTimer.Restart();
            var outmsg = _client.CreateMessage();
            outmsg.Write((byte) PacketTypes.Input);
            outmsg.Write((byte) PlayerNumber);
            for (byte i = 0; i < Input.GetLength(0); i++)
            {
                Input[i] = (byte) Key.None;
            }
            InputHandler.GameInputHandling();
            for (byte i = 0; i < Input.GetLength(0); i++)
            {
                if (Input[i] != Key.None)
                {
                    outmsg.Write((byte) 1);
                    outmsg.Write((byte) Input[i]);
                }
            }
            outmsg.Write((byte) 0);
            for (byte i = 0; i < Input.GetLength(0); i++)
            {
                if (Input[i] != Key.None)
                {
                    _client.SendMessage(outmsg, NetDeliveryMethod.ReliableSequenced);
                    break;
                }
            }
            if (FrameTimer.ElapsedMilliseconds < VarDatabase.FrameTimeMs)
            {
                Thread.Sleep(VarDatabase.FrameTimeMs - (int) FrameTimer.ElapsedMilliseconds);
            }
        }
    }

    internal enum PacketTypes
    {
        Login,
        Move,
        Worldstate,
        Playernumber,
        Input,
        Worldstate2,
        Newplayer
    }
}