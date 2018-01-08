using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Matrix
{
    public class AbortMsg : BaseMatrixMessage
    {

        public AbortMsg()
        {
            Type = new char[] { 'A', 'B', 'R', 'T' };
        }

        public AbortMsg(Reader R) : base(R)
        {

        }
    }
}
