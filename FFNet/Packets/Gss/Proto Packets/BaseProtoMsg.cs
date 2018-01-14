using FFNet.Packets.Gss.Fury_Messages;
using Flare.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Proto_Packets
{
    public class BaseProtoMsg : BasePacket
    {
        public GssHeader Header { get; set; }
        public virtual byte? MsgID { get { return null; } }
        public virtual string MsgName { get { return Header == null ? "UnkProtoMsg" : MessageNamesLookup.GetMatrixFuryName(Header.MsgID); } }

        public BaseProtoMsg()
        {

        }

        public virtual void Read(Reader R)
        {
            
        }

        public virtual void Write(Writer W)
        {
           
        }

        public virtual byte[] ToBytes()
        {
            using (var ms = new MemoryStream())
            {
                using (var w = new Writer(ms, Endianness.BigEndian))
                {
                    Write(w);
                    return ms.ToArray();
                }
            }
        }
    }
}
