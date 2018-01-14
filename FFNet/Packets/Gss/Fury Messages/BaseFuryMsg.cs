using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Fury_Messages
{
    public class BaseFuryMsg : BasePacket
    {
        public GssHeader Header { get; set; }
        //public virtual byte? MsgID { get { return null; } }
        public virtual string MsgName { get { return Header == null ? "Unk Fury Msg" : MessageNamesLookup.GetMatrixFuryName(Header.MsgID); } }

        public BaseFuryMsg()
        {

        }

        public BaseFuryMsg(GssHeader Header)
        {
            this.Header = Header;
        }

        public virtual void Read(Reader R)
        {

        }

        public virtual void Write(Writer W)
        {

        }
    }
}
