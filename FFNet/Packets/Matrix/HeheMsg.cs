using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Matrix
{
    public class HeheMsg : BaseMatrixMessage
    {
        public uint SocketID { get; set; }

        public HeheMsg()
        {
            Type = new char[] { 'H', 'E', 'H', 'E' };
        }

        public HeheMsg(uint SocketID) : this()
        {
            this.SocketID = SocketID;
        }

        public HeheMsg(Reader R) 
        {
            this.Read(R);
        }

        public override void Read(Reader R)
        {
            base.Read(R);
            SocketID = R.UInt();
        }

        public override void Write(Writer W)
        {
            base.Write(W);
            W.UInt(SocketID);
        }
    }
}
