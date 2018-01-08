using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Matrix
{
    public class HuggMsg : BaseMatrixMessage
    {
        public ushort SequenceStart { get; set; }
        public ushort GameServerPort { get; set; }

        public HuggMsg()
        {
            Type = new char[] { 'H', 'U', 'G', 'G' };
        }

        public HuggMsg(Reader R)
        {
            this.Read(R);
        }

        public HuggMsg(ushort SeqStart, ushort GSSPort) : this()
        {
            SequenceStart = SeqStart;
            GameServerPort = GSSPort;
        }

        public override void Read(Reader R)
        {
            base.Read(R);
            SequenceStart = R.UShort();
            GameServerPort = R.UShort();
        }

        public override void Write(Writer W)
        {
            base.Write(W);
            W.UShort(SequenceStart);
            W.UShort(GameServerPort);
        }
    }
}
