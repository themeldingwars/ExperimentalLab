namespace PacketPeep
{
    partial class ValueDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new DarkUI.Controls.DarkSectionPanel();
            this.ValuesTable2 = new System.Windows.Forms.TableLayoutPanel();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.Int64 = new DarkUI.Controls.DarkLabel();
            this.UInt64 = new DarkUI.Controls.DarkLabel();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.Float = new DarkUI.Controls.DarkLabel();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.Double = new DarkUI.Controls.DarkLabel();
            this.ValuesTable = new System.Windows.Forms.TableLayoutPanel();
            this.UByte = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.SByte = new DarkUI.Controls.DarkLabel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.Short = new DarkUI.Controls.DarkLabel();
            this.Int = new DarkUI.Controls.DarkLabel();
            this.UShort = new DarkUI.Controls.DarkLabel();
            this.UInt = new DarkUI.Controls.DarkLabel();
            this.Panel.SuspendLayout();
            this.ValuesTable2.SuspendLayout();
            this.ValuesTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.ValuesTable2);
            this.Panel.Controls.Add(this.ValuesTable);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.SectionHeader = null;
            this.Panel.Size = new System.Drawing.Size(501, 424);
            this.Panel.TabIndex = 0;
            // 
            // ValuesTable2
            // 
            this.ValuesTable2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesTable2.BackColor = System.Drawing.Color.Transparent;
            this.ValuesTable2.ColumnCount = 2;
            this.ValuesTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable2.Controls.Add(this.darkLabel10, 0, 0);
            this.ValuesTable2.Controls.Add(this.Int64, 1, 0);
            this.ValuesTable2.Controls.Add(this.UInt64, 1, 1);
            this.ValuesTable2.Controls.Add(this.darkLabel11, 0, 1);
            this.ValuesTable2.Controls.Add(this.darkLabel8, 0, 2);
            this.ValuesTable2.Controls.Add(this.Float, 1, 2);
            this.ValuesTable2.Controls.Add(this.darkLabel9, 0, 3);
            this.ValuesTable2.Controls.Add(this.Double, 1, 3);
            this.ValuesTable2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.ValuesTable2.Location = new System.Drawing.Point(3, 74);
            this.ValuesTable2.Margin = new System.Windows.Forms.Padding(0);
            this.ValuesTable2.Name = "ValuesTable2";
            this.ValuesTable2.RowCount = 4;
            this.ValuesTable2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable2.Size = new System.Drawing.Size(497, 62);
            this.ValuesTable2.TabIndex = 20;
            // 
            // darkLabel10
            // 
            this.darkLabel10.AutoSize = true;
            this.darkLabel10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(0, 0);
            this.darkLabel10.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(49, 15);
            this.darkLabel10.TabIndex = 10;
            this.darkLabel10.Text = "Int64:";
            // 
            // Int64
            // 
            this.Int64.AutoSize = true;
            this.Int64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Int64.Location = new System.Drawing.Point(59, 0);
            this.Int64.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Int64.Name = "Int64";
            this.Int64.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Int64.Size = new System.Drawing.Size(19, 15);
            this.Int64.TabIndex = 12;
            this.Int64.Text = "0";
            this.Int64.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // UInt64
            // 
            this.UInt64.AutoSize = true;
            this.UInt64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.UInt64.Location = new System.Drawing.Point(59, 15);
            this.UInt64.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.UInt64.Name = "UInt64";
            this.UInt64.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UInt64.Size = new System.Drawing.Size(19, 15);
            this.UInt64.TabIndex = 19;
            this.UInt64.Text = "0";
            this.UInt64.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // darkLabel11
            // 
            this.darkLabel11.AutoSize = true;
            this.darkLabel11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(0, 15);
            this.darkLabel11.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(56, 15);
            this.darkLabel11.TabIndex = 11;
            this.darkLabel11.Text = "UInt64:";
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(0, 30);
            this.darkLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(49, 15);
            this.darkLabel8.TabIndex = 8;
            this.darkLabel8.Text = "Float:";
            // 
            // Float
            // 
            this.Float.AutoSize = true;
            this.Float.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Float.Location = new System.Drawing.Point(59, 30);
            this.Float.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Float.Name = "Float";
            this.Float.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Float.Size = new System.Drawing.Size(19, 15);
            this.Float.TabIndex = 18;
            this.Float.Text = "0";
            this.Float.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(0, 45);
            this.darkLabel9.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(56, 15);
            this.darkLabel9.TabIndex = 9;
            this.darkLabel9.Text = "Double:";
            // 
            // Double
            // 
            this.Double.AutoSize = true;
            this.Double.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Double.Location = new System.Drawing.Point(59, 45);
            this.Double.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Double.Name = "Double";
            this.Double.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Double.Size = new System.Drawing.Size(19, 15);
            this.Double.TabIndex = 17;
            this.Double.Text = "0";
            this.Double.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // ValuesTable
            // 
            this.ValuesTable.BackColor = System.Drawing.Color.Transparent;
            this.ValuesTable.ColumnCount = 4;
            this.ValuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ValuesTable.Controls.Add(this.UByte, 3, 0);
            this.ValuesTable.Controls.Add(this.darkLabel2, 2, 0);
            this.ValuesTable.Controls.Add(this.darkLabel1, 0, 0);
            this.ValuesTable.Controls.Add(this.SByte, 1, 0);
            this.ValuesTable.Controls.Add(this.darkLabel4, 0, 1);
            this.ValuesTable.Controls.Add(this.darkLabel5, 2, 1);
            this.ValuesTable.Controls.Add(this.darkLabel6, 0, 2);
            this.ValuesTable.Controls.Add(this.darkLabel7, 2, 2);
            this.ValuesTable.Controls.Add(this.Short, 1, 1);
            this.ValuesTable.Controls.Add(this.Int, 1, 2);
            this.ValuesTable.Controls.Add(this.UShort, 3, 1);
            this.ValuesTable.Controls.Add(this.UInt, 3, 2);
            this.ValuesTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.ValuesTable.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValuesTable.Location = new System.Drawing.Point(1, 25);
            this.ValuesTable.Name = "ValuesTable";
            this.ValuesTable.RowCount = 3;
            this.ValuesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValuesTable.Size = new System.Drawing.Size(499, 47);
            this.ValuesTable.TabIndex = 0;
            // 
            // UByte
            // 
            this.UByte.AutoSize = true;
            this.UByte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.UByte.Location = new System.Drawing.Point(137, 0);
            this.UByte.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.UByte.Name = "UByte";
            this.UByte.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UByte.Size = new System.Drawing.Size(19, 15);
            this.UByte.TabIndex = 3;
            this.UByte.Text = "0";
            this.UByte.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(78, 0);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(49, 15);
            this.darkLabel2.TabIndex = 2;
            this.darkLabel2.Text = "UByte:";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(0, 0);
            this.darkLabel1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(42, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Byte:";
            // 
            // SByte
            // 
            this.SByte.AutoSize = true;
            this.SByte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SByte.Location = new System.Drawing.Point(56, 0);
            this.SByte.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.SByte.Name = "SByte";
            this.SByte.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.SByte.Size = new System.Drawing.Size(19, 15);
            this.SByte.TabIndex = 1;
            this.SByte.Text = "0";
            this.SByte.Click += new System.EventHandler(this.SByte_Click);
            this.SByte.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(0, 15);
            this.darkLabel4.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(49, 15);
            this.darkLabel4.TabIndex = 4;
            this.darkLabel4.Text = "Short:";
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(78, 15);
            this.darkLabel5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(56, 15);
            this.darkLabel5.TabIndex = 5;
            this.darkLabel5.Text = "UShort:";
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(0, 30);
            this.darkLabel6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(35, 15);
            this.darkLabel6.TabIndex = 6;
            this.darkLabel6.Text = "Int:";
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(78, 30);
            this.darkLabel7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(42, 15);
            this.darkLabel7.TabIndex = 7;
            this.darkLabel7.Text = "UInt:";
            // 
            // Short
            // 
            this.Short.AutoSize = true;
            this.Short.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Short.Location = new System.Drawing.Point(56, 15);
            this.Short.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Short.Name = "Short";
            this.Short.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Short.Size = new System.Drawing.Size(19, 15);
            this.Short.TabIndex = 16;
            this.Short.Text = "0";
            this.Short.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // Int
            // 
            this.Int.AutoSize = true;
            this.Int.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Int.Location = new System.Drawing.Point(56, 30);
            this.Int.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Int.Name = "Int";
            this.Int.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Int.Size = new System.Drawing.Size(19, 15);
            this.Int.TabIndex = 15;
            this.Int.Text = "0";
            this.Int.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // UShort
            // 
            this.UShort.AutoSize = true;
            this.UShort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.UShort.Location = new System.Drawing.Point(137, 15);
            this.UShort.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.UShort.Name = "UShort";
            this.UShort.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UShort.Size = new System.Drawing.Size(19, 15);
            this.UShort.TabIndex = 14;
            this.UShort.Text = "0";
            this.UShort.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // UInt
            // 
            this.UInt.AutoSize = true;
            this.UInt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.UInt.Location = new System.Drawing.Point(137, 30);
            this.UInt.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.UInt.Name = "UInt";
            this.UInt.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UInt.Size = new System.Drawing.Size(19, 15);
            this.UInt.TabIndex = 13;
            this.UInt.Text = "0";
            this.UInt.DoubleClick += new System.EventHandler(this.Int64_Click);
            // 
            // ValueDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Name = "ValueDisplay";
            this.Size = new System.Drawing.Size(501, 424);
            this.Panel.ResumeLayout(false);
            this.ValuesTable2.ResumeLayout(false);
            this.ValuesTable2.PerformLayout();
            this.ValuesTable.ResumeLayout(false);
            this.ValuesTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel Panel;
        private System.Windows.Forms.TableLayoutPanel ValuesTable;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkLabel darkLabel11;
        private DarkUI.Controls.DarkLabel Int64;
        private DarkUI.Controls.DarkLabel UInt64;
        private DarkUI.Controls.DarkLabel Float;
        private DarkUI.Controls.DarkLabel Double;
        private System.Windows.Forms.TableLayoutPanel ValuesTable2;
        private DarkUI.Controls.DarkLabel UByte;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel SByte;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkLabel Short;
        private DarkUI.Controls.DarkLabel Int;
        private DarkUI.Controls.DarkLabel UShort;
        private DarkUI.Controls.DarkLabel UInt;
    }
}
