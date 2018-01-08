using FFNet;
using FFNet.Packets.Gss.Fury_Messages;
using Flare.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoneLoadTest
{
    public class OldZoneLoad
    {
        public static void Start()
        {
            FFMatrix Matrix = new FFMatrix();
            Matrix.Start();

            Matrix.OnMatrixConnection += Matrix_OnMatrixConnection;

            Console.WriteLine("Old Zoneload test");
        }

        private static void Matrix_OnMatrixConnection(MatrixConnection Connection)
        {
            //Connection.Socket.OnGssRawMsgRecv += Socket_OnGssMsgRecv;
            Connection.Socket.OnGssProtoMsgRecv += Socket_OnGssProtoMsgRecv;
            Connection.Socket.OnGssFuryRecv += Socket_OnGssFuryRecv;
            Console.WriteLine($"Got a Gss Connection");
        }

        private static void Socket_OnGssFuryRecv(FFNet.Packets.Gss.GssHeader Header, FFNet.Packets.Gss.Fury_Messages.BaseFuryMsg GssMessage, FFSocket Socket)
        {
            Console.WriteLine($"Fury Msg: {MessageNamesLookup.GetMatrixFuryName(Header.MsgID)}");

            if (Header.MsgID == 0x11)
            {
                Console.WriteLine($"Login");
                Socket.SendAck();
                //SendZoneLoad(Socket);
            }
        }

        private static void Socket_OnGssProtoMsgRecv(FFNet.Packets.Gss.GssHeader Header, FFNet.Packets.Gss.Proto_Packets.BaseProtoMsg GssMessage, FFSocket Socket)
        {
            if (GssMessage != null)
            {
                // Console.WriteLine(GssMessage.GetType().Name);
            }
        }

        private static void Socket_OnGssMsgRecv(FFNet.Packets.Gss.GssHeader Header, object GssMessage, FFSocket Socket)
        {
            Console.WriteLine($"Got a Gss message :>");
        }

        private static void SendZoneLoad(FFSocket Socket)
        {
            using (var ms = new MemoryStream())
            {
                using (var w = new Writer(ms, Endianness.BigEndian))
                {
                    w.UInt(Socket.SocketID);
                    w.Byte(0x40);
                    w.Byte(0x11);
                    w.UShort((ushort)(Socket.NextSendSeqNum()));
                    w.Byte(new byte[] { 0x23, 0x00, 0x47, 0xDB, 0x74, 0x1B, 0x5B, 0x58, 0x46, 0x00, 0x00, 0x00, 0x00 });


                    var arr = new byte[] {
                        0x40, 0x7E, 0xDB, 0x7F, 0x25, 0xFB, 0x00, 0x08, 0x74, 0x1B, 0x5B, 0x58, 0x46, 0x65, 0x04, 0x00,
                        0x00, 0x7B, 0x6E, 0xB2, 0x3B, 0x54, 0x01, 0x00, 0x00, 0x00, 0x72, 0x35, 0x5F, 0x65, 0x78, 0x65,
                        0x63, 0x00, 0x5F, 0x4C, 0xF5, 0xC9, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0xF6, 0x49, 0xE3, 0x23, 0x42, 0x61, 0x74, 0x74, 0x6C, 0x65, 0x6C, 0x61, 0x62, 0x5F,
                        0x30, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x41,
                        0xAE, 0x43, 0x65, 0x3F, 0x1F, 0xE9, 0xD8, 0x2F, 0x34, 0x44, 0x05, 0x00, 0x1F, 0xE9, 0xD8, 0x2F,
                        0x34, 0x44, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                    };

                    byte[] bytes = BitConverter.GetBytes(Socket.NextSendSeqNum());
                    arr[2] = bytes[1];
                    arr[3] = bytes[0];
                    w.Byte(arr);

                    var res = ms.ToArray();
                    Socket.SendRaw(res);

                    Console.WriteLine("Sent Zone Load");
                }
            }
        }
    }
}
