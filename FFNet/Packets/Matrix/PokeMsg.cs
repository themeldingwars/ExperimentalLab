using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flare.Binary;

namespace FFNet.Packets.Matrix
{
    public class PokeMsg : BaseMatrixMessage
    {
        public uint ProtcolVersion { get; set; }

        public PokeMsg()
        {
            Type = new char[] { 'P', 'O', 'K', 'E' };
        }

        public PokeMsg(uint ProtoVersion) : this()
        {
            ProtcolVersion = ProtoVersion;
        }

        public PokeMsg(Reader R)
        {
            this.Read(R);
        }

        public override void Read(Reader R)
        {
            base.Read(R);
            ProtcolVersion = R.UInt();
        }

        public override void Write(Writer W)
        {
            base.Write(W);
            W.UInt(ProtcolVersion);
        }
    }
}
