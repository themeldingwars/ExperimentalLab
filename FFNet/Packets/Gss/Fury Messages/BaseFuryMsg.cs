using Flare.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Fury_Messages
{
    public class BaseFuryMsg
    {
        public virtual byte? MsgID { get { return null; } }

        public BaseFuryMsg()
        {

        }

        public virtual void Read(Reader R)
        {

        }

        public virtual void Write(Writer W)
        {

        }
    }
}
