using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Be.Windows.Forms;
using FFNet.Packets.Gss.Proto_Packets;
using FFNet;
using FFNet.Packets.Matrix;
using FFNet.Packets.Gss.Fury_Messages;

namespace PacketPeep
{
    public partial class PacketInspector : UserControl
    {
        // Static data
        //----------------------------------------------------

        // Lets have some nice colors for the list
        private int PacketColorIdx = 0;
        private byte[][] PacketIDColors = new byte[][]
        {
            new byte[] {80, 185, 157},
            new byte[] {200, 72, 159},
            new byte[] {99, 188, 82},
            new byte[] {170, 97, 204},
            new byte[] {180, 180, 68},
            new byte[] {112, 112, 199},
            new byte[] {217, 144, 50},
            new byte[] {102, 156, 213},
            new byte[] {207, 78, 52},
            new byte[] {71, 136, 68},
            new byte[] {205, 67, 100},
            new byte[] {125, 126, 55},
            new byte[] {190, 109, 147},
            new byte[] {155, 94, 47},
            new byte[] {223, 147, 112}
        };

        private int HexHighlightColorIdx = 0;
        private byte[][] HexHiglightColors = new byte[][]
        {
            new byte[] {125,62,25},
            new byte[] {72,60,202},
            new byte[] {45,98,9},
            new byte[] {115,32,192},
            new byte[] {31,81,19},
            new byte[] {52,26,150},
            new byte[] {86,88,17},
            new byte[] {142,26,160},
            new byte[] {44,77,30},
            new byte[] {100,26,138},
            new byte[] {43,99,63},
            new byte[] {75,61,168},
            new byte[] {175,48,7},
            new byte[] {44,27,120},
            new byte[] {76,69,19},
            new byte[] {130,54,142},
            new byte[] {16,50,20},
            new byte[] {148,25,112},
            new byte[] {43,52,18},
            new byte[] {77,39,121},
            new byte[] {160,30,29},
            new byte[] {52,72,141},
            new byte[] {147,49,28},
            new byte[] {39,31,91},
            new byte[] {106,72,31},
            new byte[] {97,31,98},
            new byte[] {56,80,58},
            new byte[] {159,28,77},
            new byte[] {45,84,81},
            new byte[] {156,35,53},
            new byte[] {51,81,108},
            new byte[] {104,24,18},
            new byte[] {33,43,79},
            new byte[] {134,54,50},
            new byte[] {27,48,59},
            new byte[] {120,25,81},
            new byte[] {25,41,30},
            new byte[] {101,67,123},
            new byte[] {85,82,53},
            new byte[] {57,22,71},
            new byte[] {63,45,19},
            new byte[] {122,57,91},
            new byte[] {51,38,27},
            new byte[] {119,32,59},
            new byte[] {88,70,100},
            new byte[] {74,28,21},
            new byte[] {125,68,79},
            new byte[] {62,31,49},
            new byte[] {101,66,60},
            new byte[] {82,20,37 }
        };

        private Color[] BackgroundColors = new Color[]
        {
            Color.FromArgb(60, 63, 65),
            Color.FromArgb(72, 76, 78)
        };

        private float[] SplitterWidths = new float[2]
        {
            0.25f,  0.3333333f
        };

        private const int RowHeight = 22;

        // Sate vars
        //----------------------------------------------------
        private PacketRecord CurrentSelectedPacket { get; set; } = new PacketRecord() { };
        private List<PacketRecord> PacketRecords = new List<PacketRecord>();
        private int RawPacketIdx = 0;

        public PacketInspector()
        {
            InitializeComponent();

            HexView.ByteProvider = new DynamicByteProvider(new byte[] { });
            PacketList.View = View.Details;

            // Trick to set the height of the row
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, RowHeight);
            PacketList.SmallImageList = imgList;
            Font = new Font(Font, FontStyle.Bold);

            SetSplitterWidth(MainSplitter, SplitterWidths[0]);
            //SetSplitterWidth(splitContainer1, SplitterWidths[1]);

            SetColumWidths();

            MainSplitter.SplitterWidth = 2;
            PacketColorIdx = new Random().Next(0, PacketIDColors.Length);

            //TestAddPackets();
        }

        public void ParsePacketBytes(byte[] PacketBytes)
        {
            if (PacketBytes != null)
            {
                var packets = PacketParser.Decode(PacketBytes);

                foreach (var packetMeta in packets)
                {
                    if (packetMeta.PacketType == PacketParser.PacketTypes.MATRIX)
                    {

                    }
                }
            }
        }

        public void AddPacketRecordToUI(PacketRecord Record)
        {
            // Raw packet header
            Record.Name = Record.IsMatrixMessage ? "Matrix Message" : "GSS Message";
            var isFromServer = Record.Source == PacketFrom.Server;
            AddPacketLogToList(isFromServer, RawPacketIdx, Record.Name);
            PacketRecords.Add(Record);
            Record.Index = PacketRecords.Count - 1;
            RawPacketIdx++;

            // Now the sub packets
            var packets = PacketParser.Decode(Record.Data, true);

            if (packets != null)
            {
                foreach (var packetMeta in packets)
                {
                    if (packetMeta.PacketType == PacketParser.PacketTypes.MATRIX)
                    {
                        PacketRecord subRecord = new PacketRecord();
                        var matrixMessage = packetMeta.Packet as BaseMatrixMessage;
                        var name = new string(matrixMessage.Type);
                        subRecord.Data = packetMeta.Debug.RawBytes;
                        subRecord.Packet = matrixMessage;

                        var color = GetNextHexHighlightColor();
                        AddPacketLogToList(isFromServer, PacketRecords.Count, name, Record.Index, color);
                        PacketRecords.Add(subRecord);

                        Record.HexHighLights.Add(new HexBox.HighlightedRegion((int)packetMeta.Debug.Offset, packetMeta.Debug.RawBytes.Length, color));
                    }
                    else if (packetMeta.PacketType == PacketParser.PacketTypes.PROTO)
                    {
                        PacketRecord subRecord = new PacketRecord();
                        var protoMessage = packetMeta.Packet as BaseProtoMsg;
                        subRecord.Data = packetMeta.Debug.RawBytes;
                        subRecord.Packet = protoMessage;

                        var color = GetNextHexHighlightColor();
                        AddPacketLogToList(isFromServer, PacketRecords.Count, protoMessage.MsgName, Record.Index, color);
                        PacketRecords.Add(subRecord);

                        Record.HexHighLights.Add(new HexBox.HighlightedRegion((int)packetMeta.Debug.Offset, packetMeta.Debug.RawBytes.Length, color));
                    }
                    else if (packetMeta.PacketType == PacketParser.PacketTypes.UNKNOWN)
                    {
                        PacketRecord subRecord = new PacketRecord();
                        var protoMessage = packetMeta.Packet as FuryUnknownMsg;
                        subRecord.Data = packetMeta.Debug.RawBytes;
                        subRecord.Packet = protoMessage;

                        var color = GetNextHexHighlightColor();
                        AddPacketLogToList(isFromServer, PacketRecords.Count, protoMessage.MsgName, Record.Index, color);
                        PacketRecords.Add(subRecord);

                        Record.HexHighLights.Add(new HexBox.HighlightedRegion((int)packetMeta.Debug.Offset, packetMeta.Debug.RawBytes.Length, color));
                    }
                }
            }
        }

        private void SetColumWidths()
        {
            int col1 = 40;
            int col2 = 8;
            int col3 = MainSplitter.SplitterDistance - (col1 + col2 +
                    (IsPacketListHorzScrollShown() ? SystemInformation.VerticalScrollBarWidth : 0)
                ) + 5;

            PacketList.Columns[0].Width = col1;
            PacketList.Columns[1].Width = col2;
            PacketList.Columns[2].Width = col3;
        }

        private bool IsPacketListHorzScrollShown()
        {
            int height = PacketList.Items.Count * RowHeight;
            int clientAreaHeight = PacketList.ClientSize.Height;

            return height > clientAreaHeight;
        }

        private void SetSplitterWidth(SplitContainer Splitter, float Width)
        {
            int width = (int)Math.Floor(this.Width * Width);
            Splitter.SplitterDistance = width;
        }

        private void TestAddPackets()
        {
            AddPacketLogToList(true, 1, "Parent Raw Packet");
            AddPacketLogToList(true, 2, "Test 1", 0);
            AddPacketLogToList(true, 3, "Test 2", 0);
            AddPacketLogToList(true, 4, "Test 3", 0);

            AddPacketLogToList(false, 2, "Client Parent Raw Packet");
            AddPacketLogToList(false, 6, "Test 1", 4);
            AddPacketLogToList(false, 7, "Test 2", 4);
            AddPacketLogToList(false, 8, "Test 3", 4);

            /*for (int i = 0; i < 10; i++)
            {
                AddPacketLogToList(false, 5, "Client Parent Raw Packet");
                AddPacketLogToList(false, 6, "Test 1", 4);
                AddPacketLogToList(false, 7, "Test 2", 4);
                AddPacketLogToList(false, 8, "Test 3", 4);
            }*/

            // Add some random bytes to the hex view
            int size = 1000;
            byte[] buffer = new byte[size];
            new Random().NextBytes(buffer);
            buffer[0] = 0xFF; buffer[1] = 0xFF; buffer[2] = 0xFF; buffer[3] = 0xFF;
            HexView.ByteProvider.InsertBytes(0, buffer);
            CurrentSelectedPacket.Data = buffer;

            // Test the higlighted regions
            HexView.HighligedRegions = new List<HexBox.HighlightedRegion>();
            int lastPos = 0;
            const int higlightedBytesLen = 4;
            foreach (var color in HexHiglightColors)
            {
                HexView.HighligedRegions.Add(new HexBox.HighlightedRegion(lastPos, higlightedBytesLen, GetColorFromRGBArr(color)));
                lastPos += higlightedBytesLen;
            }

            InspectorPropertyGrid.SelectedObject = new TimeSyncResponse(200);

            var children = InspectorPropertyGrid.Controls.OfType<Control>();
        }

        private int AddPacketLogToList(bool FromServer, int Idx, string Name, long ParentPacketIdx = -1, Color? AccentColor = null)
        {
            Color foreColor = Color.WhiteSmoke;

            string from = FromServer ? "> S" : "< C";
            Color baseColor = ParentPacketIdx != -1 ? PacketList.Items[(int)ParentPacketIdx].BackColor : GetNextColor();
            Color subItemColor = ParentPacketIdx == -1 ? baseColor : 
                Idx % 2 == 0 ? BackgroundColors[0] : BackgroundColors[1];

            ListViewItem item = new ListViewItem(from);
            item.ForeColor = foreColor;
            item.BackColor = baseColor;
            item.UseItemStyleForSubItems = false;

            string idxStr = ParentPacketIdx == -1 ? $"{Idx}" : "";
            item.SubItems.Add(idxStr, foreColor, AccentColor == null ? subItemColor : AccentColor.Value, Font);

            item.SubItems.Add(Name, foreColor, subItemColor, Font);

            int listItemIdx = PacketList.Items.Add(item).Index;

            //PacketList.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            return listItemIdx;
        }

        public void Clear()
        {
            PacketList.Items.Clear();
            PacketRecords.Clear();
        }

        private Color GetNextColor()
        {
            // Get index for the color
            PacketColorIdx++;
            if (PacketColorIdx >= PacketIDColors.Length) { PacketColorIdx = 0; }

            var rgb = PacketIDColors[PacketColorIdx];
            var color = GetColorFromRGBArr(rgb);

            return color;
        }

        private Color GetNextHexHighlightColor()
        {
            // Get index for the color
            HexHighlightColorIdx++;
            if (HexHighlightColorIdx >= PacketIDColors.Length) { HexHighlightColorIdx = 0; }

            var rgb = PacketIDColors[HexHighlightColorIdx];
            var color = GetColorFromRGBArr(rgb);

            return color;
        }

        private Color GetColorFromRGBArr(byte[] RGB)
        {
            var color = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
            return color;
        }

        private void SplitterPaint(object sender, PaintEventArgs e)
        {
            SplitContainer s = sender as SplitContainer;
            if (s != null)
            {
                var pen = new Pen(DarkUI.Config.Colors.LightBorder, 3);
                int top = 0;
                int bottom = s.Height;
                int left = s.SplitterDistance;
                int right = left + s.SplitterWidth - 1;
                e.Graphics.DrawLine(pen, left, top, left, bottom);
                //e.Graphics.DrawLine(pen, right, top, right, bottom);
            }
        }

        private void MainSplitter_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            
        }

        private void MainSplitter_SplitterMoving(object sender, SplitterEventArgs e)
        {
            SetColumWidths();
        }

        private void HexView_SelectionLengthChanged(object sender, EventArgs e)
        {
            if (CurrentSelectedPacket != null && CurrentSelectedPacket.Data != null)
            {
                var selectedBytes = new byte[HexView.SelectionLength];
                Array.Copy(CurrentSelectedPacket.Data, HexView.SelectionStart, selectedBytes, 0, HexView.SelectionLength);

                ValueDisplayLE.ParseBytes(selectedBytes);
                ValueDisplayBE.ParseBytes(selectedBytes);

                HexSelOffset.Text = $"Offset: {HexView.SelectionStart}";
                HexSelLen.Text = $"Sel Len: {HexView.SelectionLength}";
            }
        }

        private void PacketList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PacketList.SelectedIndices.Count == 1)
            {
                var selectedIdx = PacketList.SelectedIndices[0];
                CurrentSelectedPacket = PacketRecords[selectedIdx];

                HexView.ByteProvider.DeleteBytes(0, HexView.ByteProvider.Length);
                if (CurrentSelectedPacket.Data != null)
                {
                    HexView.HighligedRegions = CurrentSelectedPacket.HexHighLights;
                    HexView.ByteProvider.InsertBytes(0, CurrentSelectedPacket.Data);
                }
                HexView.Refresh();

                if (CurrentSelectedPacket.Packet != null)
                {
                    InspectorPropertyGrid.SelectedObject = CurrentSelectedPacket.Packet;
                }
                else
                {
                    InspectorPropertyGrid.SelectedObject = null;
                }
            }
        }
    }
}
