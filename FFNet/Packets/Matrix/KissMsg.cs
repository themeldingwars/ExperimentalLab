using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Matrix
{
    public class KissMsg : BaseMatrixMessage
    {
        public uint SocketID { get; set; }
        public short StreamingProtcol { get; set; }

        public KissMsg()
        {
            Type = new char[] { 'K', 'I', 'S', 'S' };
        }

        public KissMsg(uint SocketUUID, short StreamProtocolVersion) : this()
        {
            SocketID = SocketUUID;
            StreamingProtcol = StreamProtocolVersion;
        }

        public KissMsg(Reader R)
        {
            this.Read(R);
        }

        public override void Read(Reader R)
        {
            base.Read(R);
            SocketID = R.UInt();
            StreamingProtcol = R.Short();
        }

        public override void Write(Writer W)
        {
            base.Write(W);
            W.UInt(SocketID);
            W.Short(StreamingProtcol);
        }
    }
}
