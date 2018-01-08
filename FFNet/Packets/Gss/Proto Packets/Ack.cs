using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Proto_Packets
{
    // Sent to, well acknowledge the receival of a message
    public class Ack : BaseProtoMsg
    {
        public const byte MSG_ID = 0x2;
        public override byte? MsgID { get { return MSG_ID; } }

        public ushort SeqNum { get; set; }
        public ushort AckFor { get; set; }

        public Ack()
        {
            
        }

        public Ack(Reader R)
        {
            Read(R);
        }

        public override void Read(Reader R)
        {
            SeqNum = R.UShort();
            AckFor = R.UShort();
        }

        public override void Write(Writer W)
        {
            W.UShort(SeqNum);
            W.UShort(AckFor);
        }
    }
}
