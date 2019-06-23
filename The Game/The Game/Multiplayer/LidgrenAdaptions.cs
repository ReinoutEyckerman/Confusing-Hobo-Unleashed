using System;
using Confusing_Hobo_Unleashed.AI;
using Lidgren.Network;

namespace Confusing_Hobo_Unleashed.Multiplayer
{
    /*
    internal class LidgrenAdaptions
    {
        public static void Write2DArray(char?[,] ar, NetOutgoingMessage outmsg)
        {
            outmsg.Write((byte) ar.GetLength(0));
            outmsg.Write((byte) ar.GetLength(1));
            foreach (var variable in ar)
            {
                if (variable.HasValue)
                    outmsg.Write(Convert.ToInt16(variable));
                else outmsg.Write((short) 256);
            }
        }

        public static void Write2DArray(short[,] ar, NetOutgoingMessage outmsg)
        {
            outmsg.Write((byte) ar.GetLength(0));
            outmsg.Write((byte) ar.GetLength(1));

            foreach (var variable in ar)
            {
                outmsg.Write((byte) variable);
            }
        }

        public static void Write2DArray(ConsoleColor[,] ar, NetOutgoingMessage outmsg)
        {
            outmsg.Write((byte) ar.GetLength(0));
            outmsg.Write((byte) ar.GetLength(1));
            foreach (var variable in ar)
            {
                outmsg.Write((byte) variable);
            }
        }

        public static void Write2DArray(bool[,] ar, NetOutgoingMessage outmsg)
        {
            outmsg.Write((byte) ar.GetLength(0));
            outmsg.Write((byte) ar.GetLength(1));
            foreach (var variable in ar)
            {
                outmsg.Write(variable);
            }
        }

        public static void OneSendList(NetOutgoingMessage outmsg, CustomMap map)
        {
            outmsg.WriteAllProperties(map);
            Write2DArray(MainGame.CurrentLoadedMap.Grav, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Air].Characters, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Air].Colors, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Characters, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Colors, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Clouds].Characters, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Clouds].Colors, outmsg);
            VarSendList(outmsg);
        }

        public static void VarSendList(NetOutgoingMessage outmsg)
        {
            Write2DArray(MainGame.CurrentLoadedMap.Collision, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Destructible].Characters, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Destructible].Colors, outmsg);
            Write2DArray(MainGame.CurrentLoadedMap.Destructible, outmsg);
        }

        public static void Read2DArray(char?[,] ar, NetIncomingMessage inmsg)
        {
            int i = inmsg.ReadByte();
            int j = inmsg.ReadByte();
            for (var a = 0; a < i; a++)
                for (var b = 0; b < j; b++)
                {
                    var charData = inmsg.ReadInt16();
                    if (charData < 256 && charData >= 0)
                        ar[a, b] = Convert.ToChar(charData);
                    else ar[a, b] = null;
                }
        }

        public static void Read2DArray(short[,] ar, NetIncomingMessage inmsg)
        {
            int i = inmsg.ReadByte();
            int j = inmsg.ReadByte();
            for (var a = 0; a < i; a++)
                for (var b = 0; b < j; b++)
                    ar[a, b] = Convert.ToInt16(inmsg.ReadByte());
        }

        public static void Read2DArray(ConsoleColor[,] ar, NetIncomingMessage inmsg)
        {
            int i = inmsg.ReadByte();
            int j = inmsg.ReadByte();
            for (var a = 0; a < i; a++)
                for (var b = 0; b < j; b++)
                    ar[a, b] = (ConsoleColor) Enum.Parse(typeof (ConsoleColor), inmsg.ReadByte().ToString());
        }

        public static void Read2DArray(bool[,] ar, NetIncomingMessage inmsg)
        {
            int i = inmsg.ReadByte();
            int j = inmsg.ReadByte();
            for (var a = 0; a < i; a++)
                for (var b = 0; b < j; b++)
                    ar[a, b] = inmsg.ReadBoolean();
        }

        public static void OneReadList(NetIncomingMessage inmsg)
        {
            inmsg.ReadAllProperties(MainGame.CurrentLoadedMap);
            Read2DArray(MainGame.CurrentLoadedMap.Grav, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Air].Characters, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Air].Colors, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Characters, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Collision].Colors, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Clouds].Characters, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Clouds].Colors, inmsg);
            VarReadList(inmsg);
        }

        public static void VarReadList(NetIncomingMessage inmsg)
        {
            Read2DArray(MainGame.CurrentLoadedMap.Collision, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Destructible].Characters, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Layers[Maplayers.Destructible].Colors, inmsg);
            Read2DArray(MainGame.CurrentLoadedMap.Destructible, inmsg);
        }

        public static void DeCompileBullet(NetIncomingMessage inc, BulletCore bullet)
        {
            bullet.X = inc.ReadInt16();
            bullet.Y = inc.ReadInt16();
            bullet.BulletColor = inc.ReadInt16();
            bullet.Character = (char) inc.ReadByte();
        }

        public static void DecompileCore(NetIncomingMessage inc, AiCore core)
        {
            core.X = inc.ReadInt16();
            core.Y = inc.ReadInt16();
            core.PlayerColor = inc.ReadInt16();
            core.DrawChar = (char) inc.ReadByte();
            if (core.HpTotal == null)
                core.HpTotal = core.HpCurrent = inc.ReadInt32();
            else core.HpCurrent = inc.ReadInt32();
        }

        public static void CompileCore(NetOutgoingMessage outmsg, AiCore core)
        {
            outmsg.Write(core.X);
            outmsg.Write(core.Y);
            outmsg.Write(core.PlayerColor);
            outmsg.Write((byte) core.DrawChar);
            outmsg.Write(core.HpCurrent);
        }

        public static void CompileBullet(NetOutgoingMessage outmsg, BulletCore bullet)
        {
            outmsg.Write(bullet.X);
            outmsg.Write(bullet.Y);
            outmsg.Write(bullet.BulletColor);
            outmsg.Write((byte) bullet.Character);
        }
    }
    */
}