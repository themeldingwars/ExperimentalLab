using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetTest.Util;

namespace FFNet.Packets.Gss.Proto_Packets
{
    public class TimeSyncResponse : BaseProtoMsg
    {
        public const byte MSG_ID = 5;
        public override byte? MsgID { get { return MSG_ID; } }

        public long ClientTimeUnix { get; set; }
        public long ServerTimeUnix { get; set; }

        public TimeSyncResponse(Reader R)
        {
            Read(R);
        }

        // Creates a reply to a TimeSyncRequest
        public TimeSyncResponse(long ClientTime)
        {
            ClientTimeUnix = ClientTime;
            ServerTimeUnix = MicroEpoch.CurrentMicroEpoch();
        }

        public override void Read(Reader R)
        {
            ClientTimeUnix = R.Long();
            ServerTimeUnix = R.Long();
        }

        public override void Write(Writer W)
        {
            W.Long(ClientTimeUnix);
            W.Long(ServerTimeUnix);
        }
    }
}
