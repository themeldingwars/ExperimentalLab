using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Proto_Packets
{
    public class TimeSyncRequest : BaseProtoMsg
    {
        public const byte MSG_ID = 0x4;
        public override byte? MsgID { get { return MSG_ID; } }

        public long ClientTimeUnix { get; set; } // Not ulong??

        public TimeSyncRequest(Reader R)
        {
            Read(R);
        }

        public override void Read(Reader R)
        {
            ClientTimeUnix = R.Long();
        }

        public override void Write(Writer W)
        {
            W.Long(ClientTimeUnix);
        }
    }
}
