using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacketPeep
{
    public partial class ValueDisplay : UserControl
    {
        private bool _IsLittleEndian = true;
        public bool IsLittleEndian { get { return _IsLittleEndian; } set
            {
                _IsLittleEndian = value;
                Panel.SectionHeader = IsLittleEndian ? "Little Endian" : "Big Endian";
            }
        }

        public ValueDisplay()
        {
            InitializeComponent();

            ValuesTable2.Location = new Point(1, ValuesTable.Bounds.Y + ValuesTable.Bounds.Size.Height - 15);

            ParseBytes(new byte[0]);
        }

        // Take in a byte array and try to pull out cast data
        public void ParseBytes(byte[] Bytes)
        {
            if (Bytes.Length >= 1)
            {
                SByte.Text = $"{(sbyte)Bytes[0]}";
                UByte.Text = $"{Bytes[0]}";
            }
            else
            {
                SByte.Text = "-";
                UByte.Text = "-";
            }

            if (Bytes.Length >= 2)
            {
                byte[] subBytes = new byte[2];
                Array.Copy(Bytes, subBytes, subBytes.Length);
                if (IsLittleEndian) { Array.Reverse(subBytes); }

                Short.Text = $"{BitConverter.ToInt16(subBytes, 0)}";
                UShort.Text = $"{BitConverter.ToUInt16(subBytes, 0)}";
            }
            else
            {
                Short.Text = "-";
                UShort.Text = "-";
            }

            if (Bytes.Length >= 4)
            {
                byte[] subBytes = new byte[4];
                Array.Copy(Bytes, subBytes, subBytes.Length);
                if (IsLittleEndian) { Array.Reverse(subBytes); }

                Int.Text = $"{BitConverter.ToInt32(subBytes, 0)}";
                UInt.Text = $"{BitConverter.ToUInt32(subBytes, 0)}";

                Float.Text = $"{BitConverter.ToSingle(subBytes, 0)}";
            }
            else
            {
                Int.Text = "-";
                UInt.Text = "-";

                Float.Text = "-";
            }

            if (Bytes.Length >= 8)
            {
                byte[] subBytes = new byte[8];
                Array.Copy(Bytes, subBytes, subBytes.Length);
                if (IsLittleEndian) { Array.Reverse(subBytes); }

                Int64.Text = $"{BitConverter.ToInt64(subBytes, 0)}";
                UInt64.Text = $"{BitConverter.ToUInt64(subBytes, 0)}";

                Double.Text = $"{BitConverter.ToDouble(subBytes, 0)}";
            }
            else
            {
                Int64.Text = "-";
                UInt64.Text = "-";

                Double.Text = "-";
            }
        }

        private void SByte_Click(object sender, EventArgs e)
        {

        }

        private void Int64_Click(object sender, EventArgs e)
        {
            if (sender is DarkUI.Controls.DarkLabel)
            {
                var label = sender as DarkUI.Controls.DarkLabel;
                Clipboard.SetText(label.Text);
            }
        }
    }
}
