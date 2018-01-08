using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Proto_Packets
{
    public class CloseConnectionMsg : BaseProtoMsg
    {
        public const byte MSG_ID = 0x0;
        public override byte? MsgID { get { return MSG_ID; } }

        public byte[] Zeros { get; set; }

        public CloseConnectionMsg()
        {
            Zeros = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
        }

        public CloseConnectionMsg(Reader R)
        {
            Read(R);
        }

        public override void Read(Reader R)
        {
            Zeros = R.Byte(8);
        }

        public override void Write(Writer W)
        {
            W.Byte(new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 });
        }

        public bool IsValidClose()
        {
            return Zeros == new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
        }
    }
}
