using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Fury_Messages
{
    public class FuryUnknownMsg : BaseFuryMsg
    {
        public byte[] Payload { get; set; }
    }
}
