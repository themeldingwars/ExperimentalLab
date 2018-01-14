using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss
{
    public class GssUnknown : BasePacket
    {
        public byte[] Payload { get; set; }

    }
}
