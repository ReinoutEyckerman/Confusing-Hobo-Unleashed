// Lidgren Network example
// Made by: Riku Koskinen
// http://xnacoding.blogspot.com/
// Download LidgreNetwork at: http://code.google.com/p/lidgren-network-gen3/

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Confusing_Hobo_Unleashed.User;
using Lidgren.Network;

namespace Confusing_Hobo_Unleashed.Multiplayer
{
    internal class Server
    {
        public static bool Change;
        private static NetServer _server;
        private static NetPeerConfiguration _config;
        private static int _count;

        public static void Start()
        {
            _config = new NetPeerConfiguration("game") {Port = 22401, MaximumConnections = 20};
            _config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            _server = new NetServer(_config);
            _server.Start();
            Console.WriteLine("Server Started");
            Console.WriteLine("Map Height : " + Console.WindowHeight);
            Console.WriteLine("Map Width : " + Console.WindowWidth);
            MainGame.Players = new List<Player>();
            var time = DateTime.Now;
            var timetopass = new TimeSpan(0, 0, 0, 0, 30);

            //CODE DIFFERENT FROM EXAMPLE
            Console.WriteLine("Generating map.");
            MainGame.CurrentLoadedMap = new CustomMap(MainGame.CurrentLoadedMap.Mapheight, Console.WindowWidth, false);
            //TODO:LandTerrain.Redirect(Game.CurrentLoadedMap, 1);
            Gameplay.Push();
            Array.Copy(MainGame.CurrentLoadedMap.CollisionBackUp, MainGame.CurrentLoadedMap.Collision, MainGame.CurrentLoadedMap.Mapheight*MainGame.CurrentLoadedMap.Mapwidth);
            Console.WriteLine("Map generated");
            //

            Console.WriteLine("Waiting for new connections and updateing world state to current ones");
            while (true)
            {
                NetIncomingMessage inc;
                if ((inc = _server.ReadMessage()) != null)
                {
                    switch (inc.MessageType)
                    {
                        case NetIncomingMessageType.ConnectionApproval:
                            if (inc.ReadByte() == (byte) PacketTypes.Login)
                            {
                                Console.WriteLine("Incoming LOGIN");
                                inc.SenderConnection.Approve();
                                var player = new Player(MainGame.CurrentLoadedMap) {Connection = inc.SenderConnection};
                                LidgrenAdaptions.DecompileCore(inc, player);
                                MainGame.Players.Add(player);
                                Console.WriteLine("Player data processed, Player joined the game. \nConnection details are : " + player.Connection);
                                MainGame.Entities.Clear();
                                MainGame.FillEntities();
                                NetOutgoingMessage outmsg;
                                for (short i = 0; i < MainGame.Players.Count - 1; i++)
                                {
                                    outmsg = _server.CreateMessage();
                                    outmsg.Write((byte) PacketTypes.Newplayer);
                                    outmsg.Write((byte) i);
                                    LidgrenAdaptions.CompileCore(outmsg, player);
                                    _server.SendMessage(outmsg, MainGame.Players[i].Connection, NetDeliveryMethod.ReliableOrdered, 0);
                                }
                                outmsg = _server.CreateMessage();
                                outmsg.Write((byte) PacketTypes.Worldstate);
                                //WRITING MAP
                                outmsg.Write((short) MainGame.CurrentLoadedMap.Mapheight);
                                outmsg.Write((short) MainGame.CurrentLoadedMap.Mapwidth);
                                LidgrenAdaptions.OneSendList(outmsg, MainGame.CurrentLoadedMap);
                                //
                                outmsg.Write(Convert.ToInt16(MainGame.Players.Count - 1));
                                foreach (var ch in MainGame.Players)
                                {
                                    LidgrenAdaptions.CompileCore(outmsg, ch);
                                }
                                _server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                                Console.WriteLine("Approved new connection and updated the world status");
                            }

                            break;
                        case NetIncomingMessageType.Data:
                            var packetType = inc.ReadByte();
                            if (packetType == (byte) PacketTypes.Input)
                            {
                                var playerNum = inc.ReadByte();
                                Array.Copy(MainGame.CurrentLoadedMap.CollisionBackUp, MainGame.CurrentLoadedMap.Collision, MainGame.CurrentLoadedMap.Mapheight*MainGame.CurrentLoadedMap.Mapwidth);
                                for (var j = 0; j < MainGame.Entities.Count; j++)
                                    if (playerNum != j)
                                        MainGame.CurrentLoadedMap.Collision[MainGame.Entities[j].Y, MainGame.Entities[j].X] = true;
                                int k;
                                do
                                {
                                    k = inc.ReadByte();
                                    if (k == 1)
                                    {
                                        var input = inc.ReadByte();
                                        Console.WriteLine("Player " + playerNum + " sent " + (Key) Enum.Parse(typeof (Key), input.ToString()));
                                        InputHandler.GameInputHandling(playerNum, (Key) Enum.Parse(typeof (Key), input.ToString()));
                                    }
                                } while (k != 0);
                            }
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            // In case status changed
                            // It can be one of these
                            // NetConnectionStatus.Connected;
                            // NetConnectionStatus.Connecting;
                            // NetConnectionStatus.Disconnected;
                            // NetConnectionStatus.Disconnecting;
                            // NetConnectionStatus.None;

                            Console.WriteLine(inc.SenderConnection + " status changed. " + inc.SenderConnection.Status);
                            if (inc.SenderConnection.Status == NetConnectionStatus.Disconnected || inc.SenderConnection.Status == NetConnectionStatus.Disconnecting)
                            {
                                // Find disconnected character and remove it
                                foreach (var cha in MainGame.Players)
                                {
                                    if (cha.Connection == inc.SenderConnection)
                                    {
                                        MainGame.Players.Remove(cha);
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Not Important Message");
                            break;
                    }
                }
                if ((time + timetopass) < DateTime.Now)
                {
                    if (_server.ConnectionsCount != 0)
                    {
                        //CALCULATING 
                        Array.Copy(MainGame.CurrentLoadedMap.CollisionBackUp, MainGame.CurrentLoadedMap.Collision, MainGame.CurrentLoadedMap.Mapheight*MainGame.CurrentLoadedMap.Mapwidth);
                        foreach (var bullet in MainGame.Bullets)
                        {
                            bullet.Rendered = true;
                        }
                        MainGame.UpdateGame();
                        //
                        var outmsg = SendData();
                        _server.SendMessage(outmsg, _server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                    }
                    time = DateTime.Now;
                }

                // While loops run as fast as your computer lets. While(true) can lock your computer up. Even 1ms sleep, lets other programs have piece of your CPU time
            }
        }

        public static NetOutgoingMessage SendData()
        {
            _count++;
            var outmsg = _server.CreateMessage();
            outmsg.Write((byte) PacketTypes.Worldstate2);
            outmsg.Write((short) MainGame.Players.Count);
            foreach (var ch2 in MainGame.Players)
                LidgrenAdaptions.CompileCore(outmsg, ch2);
            outmsg.Write((short) MainGame.Bullets.Count);
            foreach (var bullet in MainGame.Bullets)
                LidgrenAdaptions.CompileBullet(outmsg, bullet);

            if (_count == 300 || Change)
            {
                outmsg.Write(true);
                _count = 0;
                Change = false;
                LidgrenAdaptions.VarSendList(outmsg);
            }
            else outmsg.Write(false);
            return outmsg;
        }
    }
}