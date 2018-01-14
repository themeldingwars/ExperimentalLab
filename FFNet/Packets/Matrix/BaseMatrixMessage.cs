using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Matrix
{
    public class BaseMatrixMessage : BasePacket
    {
        public char[] Type;

        public BaseMatrixMessage()
        {

        }


        public BaseMatrixMessage(Reader R)
        {
            this.Read(R);
        }

        public virtual void Read(Reader R)
        {
            Type = R.Char(4);
        }

        public virtual void Write(Writer W)
        {
            W.Char(Type);
        }
    }
}
