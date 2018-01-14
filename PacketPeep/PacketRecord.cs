using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketPeep
{
    public enum PacketFrom
    {
        Client,
        Server
    }

    public class PacketRecord
    {
        public string Name;
        public DateTime Time;
        public byte[] Data;
        public PacketFrom Source;
        public bool IsRawNetworkPacket; // If true then it hasn't been split into sub packets
        public long ParentPacketIdx; // The index of the packet that this one was subed from
        public long Index;
        public bool IsMatrixMessage;
        public object Packet;

        public List<HexBox.HighlightedRegion> HexHighLights = new List<HexBox.HighlightedRegion>();
    }
}
