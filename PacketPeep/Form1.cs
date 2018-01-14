using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacketPeep
{
    public partial class Form1 : DarkUI.Forms.DarkForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void packetInspector1_Load(object sender, EventArgs e)
        {

        }

        private void LoadPCap(string FilePath)
        {
            var capLoader = new PcapLoader(FilePath);
            var packets = capLoader.GetPacketBytes();

            PacketInspector.Clear();

            foreach (var packetBytes in packets)
            {
                PacketInspector.AddPacketRecordToUI(new PacketRecord()
                {
                    Name = "",
                    Source = packetBytes.IsFromServer ? PacketFrom.Server : PacketFrom.Client,
                    Data = packetBytes.Data,
                    Time = packetBytes.Time,
                    IsMatrixMessage = packetBytes.IsMatrixMessage
                });

                //PacketInspector.ParsePacketBytes(packetBytes);
            }
        }

        private void BttOpenPcap_Click(object sender, EventArgs e)
        {
            var ofileDialog = new OpenFileDialog();
            ofileDialog.ShowDialog();

            if (ofileDialog.CheckFileExists)
            {
                var path = ofileDialog.FileName;
                LoadPCap(path);
            }
        }
    }
}
