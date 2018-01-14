using FFNet.Packets;
using FFNet.Packets.Gss;
using FFNet.Packets.Gss.Fury_Messages;
using FFNet.Packets.Gss.Proto_Packets;
using FFNet.Packets.Matrix;
using Flare.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet
{
    public class PacketParser
    {
        // Defs
        public enum PacketTypes : byte
        {
            MATRIX,
            PROTO,
            FURY,
            UNKNOWN
        }

        public sealed class DebugPacketData
        {
            public long Offset;
            public byte[] RawBytes;
        }

        public struct ParsedPacketMeta
        {
            public PacketTypes PacketType;
            public BasePacket Packet;
            public DebugPacketData Debug;
        }

        // Vars
        public static readonly byte[] ResendXors = new byte[] { 0x0, 0xFF, 0xAA, 0xCC }; // Used to decode data in resent pacakets

        public static Queue<ParsedPacketMeta> Decode(byte[] DataIn, bool IsDebug = false)
        {
            using (var r = new Reader(DataIn, Endianness.BigEndian))
            {
                return Decode(r, IsDebug);
            }
        }

        public static Queue<ParsedPacketMeta> Decode(Reader Reader, bool IsDebug = false)
        {
            var packets = new Queue<ParsedPacketMeta>();

            uint sockID = Reader.UInt();

            if (sockID == 0) // Is a matrix message
            {
                DebugPacketData debugData = DebugLogStart(IsDebug, Reader);

                var matrixMsg = DecodeMatrixPacket(Reader); // Does the reading

                packets.Enqueue(new ParsedPacketMeta()
                {
                    PacketType = PacketTypes.MATRIX,
                    Packet = matrixMsg,
                    Debug = DebugLogEnd(IsDebug, Reader, debugData)
                });
            }
            else // Gss or Proto
            {
                do
                {
                    DebugPacketData debugData = DebugLogStart(IsDebug, Reader);

                    var header = new GssHeader(Reader);

                    if (header.IsProtocolPacket)
                    {
                        var protoMsg = DecodeGssProtoMessage(Reader, header);

                        if (protoMsg != null)
                        {
                            packets.Enqueue(new ParsedPacketMeta()
                            {
                                PacketType = PacketTypes.PROTO,
                                Packet = protoMsg,
                                Debug = DebugLogEnd(IsDebug, Reader, debugData)
                            });
                        }
                    }
                    else
                    {
                        var R = DecodeResentData(Reader, header);

                        var unkMsg = new FuryUnknownMsg(header, R, (int)header.Length);

                        packets.Enqueue(new ParsedPacketMeta()
                        {
                            PacketType = PacketTypes.UNKNOWN,
                            Packet = unkMsg,
                            Debug = DebugLogEnd(IsDebug, Reader, debugData, R)
                        });
                    }
                }
                while (Reader.Position < Reader.Length);
            }

            return packets;
        }

        private static BaseMatrixMessage DecodeMatrixPacket(Reader Reader)
        {
            var type = Reader.Char(4);
            Reader.BaseStream.Seek(-4, System.IO.SeekOrigin.Current);
            BaseMatrixMessage matrixMsg = null;

            switch (new string(type))
            {
                case "POKE":
                    matrixMsg = new PokeMsg(Reader);
                    break;

                case "HEHE":
                    matrixMsg = new HeheMsg(Reader);
                    break;

                case "HUGG":
                    matrixMsg = new HuggMsg(Reader);
                    break;

                case "KISS":
                    matrixMsg = new KissMsg(Reader);
                    break;

                case "ABRT":
                    matrixMsg = new AbortMsg(Reader);
                    break;
            }

            return matrixMsg;
        }

        private static BaseProtoMsg DecodeGssProtoMessage(Reader R, GssHeader Header)
        {
            BaseProtoMsg msg = null;

            switch (Header.MsgID)
            {
                case TimeSyncRequest.MSG_ID:
                    msg = new TimeSyncRequest(R);
                    break;

                case CloseConnectionMsg.MSG_ID:
                    msg = new CloseConnectionMsg(R);
                    break;

                case Ack.MSG_ID:
                    msg = new Ack(R);
                    break;

                // Even if we don't know what it is we need to consume those bytes, nom nom
                default:
                    msg = new UnkProtoMsg(R, (int)Header.Length);
                    break;
            }

            return msg;
        }

        private static DebugPacketData DebugLogStart(bool IsDebug, Reader R)
        {
            if (IsDebug)
            {
                var debugData = new DebugPacketData();
                debugData.Offset = R.Position;

                return debugData;
            }

            return null;
        }

        private static DebugPacketData DebugLogEnd(bool IsDebug, Reader R, DebugPacketData DebugData, Reader ScrambledReader = null)
        {
            if (IsDebug)
            {
                long length = R.BaseStream.Position - DebugData.Offset;
                R.BaseStream.Seek(length * -1, System.IO.SeekOrigin.Current);
                DebugData.RawBytes = R.Byte((int)length);

                // Override with the xored unscrambled data
                if (ScrambledReader != null)
                {
                    var data = new byte[length];
                    data = ScrambledReader.Byte(data.Length);
                    Array.Copy(data, 0, DebugData.RawBytes, DebugData.RawBytes.Length - data.Length, 0);
                }

                return DebugData;
            }

            return null;
        }

        private static byte[] XorByteArray(byte[] InArray, byte XorWith)
        {
            for (int i = 0; i < InArray.Length; i++)
            {
                InArray[i] = (byte)(InArray[i] ^ XorWith);
            }

            return InArray;
        }

        private static Reader DecodeResentData(Reader R, GssHeader Header)
        {
            if (Header.ResendCount == 0)
            {
                return R; // Nothing to do :D
            }
            else
            {
                var msgBytes = R.Byte((int)Header.Length);
                var xored = XorByteArray(msgBytes, ResendXors[Header.ResendCount]);
                var ms = new MemoryStream(xored);
                var reader = new Reader(ms);
                return reader;
            }
        }
    }
}
