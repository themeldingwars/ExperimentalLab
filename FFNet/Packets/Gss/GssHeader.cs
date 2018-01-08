using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss
{
    public class GssHeader
    {
        public byte Flags { get; set; }
        private byte LenByte;

        public uint Length
        {
            get
            {
                return ((uint)((Flags % 16) * 256) + LenByte) - 2;
            }
        }
        public byte Type
        {
            get
            {
                return (byte)((Flags & 0xF0) >> 4);
            }
        }
        public byte Channel
        {
            get
            {
                return (byte)((Flags & 0xF0) >> 4);
            }
        }
        public byte ResendCount
        {
            get
            {
                return (byte)((Flags & 0x30) >> 4);
            }
        }

        public bool IsProtocolPacket
        {
            get
            {
                return Type == 0x0;
            }
        }

        public byte MsgID { get; set; }
        public ushort SeqNum { get; set; }

        public GssHeader(Reader R)
        {
            Read(R);
        }

        public void Read(Reader R)
        {
            Flags = R.Byte();
            LenByte = R.Byte();

            if (IsProtocolPacket)
            {
                MsgID = ReadResentByte(R);
            }
            else // Has a seq num
            {
                SeqNum = R.UShort();
                MsgID = ReadResentByte(R);
            }
        }

        public void Write(Writer W)
        {
            W.Byte(Flags);
            W.Byte(LenByte);

            if (IsProtocolPacket)
            {
                W.Byte(MsgID);
            }
            else
            {
                W.UShort(SeqNum);
                W.Byte(MsgID);
            }
        }

        private byte ReadResentByte(Reader R)
        {
            var b = R.Byte();

            if (ResendCount != 0) // Is a resend
            {
                b = (byte)(b ^ FFSocket.ResendXors[ResendCount]);
            }

            return b;
        }
    }
}
