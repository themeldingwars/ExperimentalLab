using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Proto_Packets
{
    // Just read and store the unknown bytes
    public class UnkProtoMsg : BaseProtoMsg
    {
        public override string MsgName { get { return "Unk Proto Msg"; } }
        private int Length = 0;
        public byte[] Bytes = null;

        public UnkProtoMsg()
        {

        }

        public UnkProtoMsg(Reader R, int? Length = null)
        {
            Length = Length.Value;
            Read(R);
        }

        public override void Read(Reader R)
        {
            Bytes = R.Byte(Length);
        }

        public override void Write(Writer W)
        {
            W.Byte(Bytes);
        }
    }
}
