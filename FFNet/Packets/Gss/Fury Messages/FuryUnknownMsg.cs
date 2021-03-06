﻿using Flare.Binary;
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
        private int Length = 0;

        public FuryUnknownMsg()
        {

        }

        public FuryUnknownMsg(GssHeader Header, Reader R, int? Length = null)
        {
            this.Header = Header;
            Length = Length.Value;
            Read(R);
        }

        public override void Read(Reader R)
        {
            Payload = R.Byte(Length);
        }

        public override void Write(Writer W)
        {
            W.Byte(Payload);
        }
    }
}
