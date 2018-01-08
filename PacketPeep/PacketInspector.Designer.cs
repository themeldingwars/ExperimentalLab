namespace PacketPeep
{
    partial class PacketInspector
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
            this.MainSplitter = new System.Windows.Forms.SplitContainer();
            this.PacketList = new System.Windows.Forms.ListView();
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Idx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PacketName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.HexSplitter = new System.Windows.Forms.SplitContainer();
            this.HexView = new Be.Windows.Forms.HexBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ValueDisplayLE = new PacketPeep.ValueDisplay();
            this.ValueDisplayBE = new PacketPeep.ValueDisplay();
            this.InspectorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).BeginInit();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HexSplitter)).BeginInit();
            this.HexSplitter.Panel1.SuspendLayout();
            this.HexSplitter.Panel2.SuspendLayout();
            this.HexSplitter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitter
            // 
            this.MainSplitter.BackColor = System.Drawing.Color.Transparent;
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.MainSplitter.Name = "MainSplitter";
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.MainSplitter.Panel1.Controls.Add(this.PacketList);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.MainSplitter.Panel2.Controls.Add(this.splitContainer1);
            this.MainSplitter.Size = new System.Drawing.Size(2133, 997);
            this.MainSplitter.SplitterDistance = 514;
            this.MainSplitter.SplitterWidth = 7;
            this.MainSplitter.TabIndex = 0;
            this.MainSplitter.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.MainSplitter_SplitterMoving);
            this.MainSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MainSplitter_SplitterMoving);
            this.MainSplitter.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitterPaint);
            // 
            // PacketList
            // 
            this.PacketList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PacketList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.PacketList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PacketList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Source,
            this.Idx,
            this.PacketName});
            this.PacketList.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketList.FullRowSelect = true;
            this.PacketList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PacketList.HideSelection = false;
            this.PacketList.LabelWrap = false;
            this.PacketList.Location = new System.Drawing.Point(-5, 0);
            this.PacketList.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.PacketList.MultiSelect = false;
            this.PacketList.Name = "PacketList";
            this.PacketList.ShowGroups = false;
            this.PacketList.Size = new System.Drawing.Size(519, 997);
            this.PacketList.TabIndex = 0;
            this.PacketList.UseCompatibleStateImageBehavior = false;
            this.PacketList.View = System.Windows.Forms.View.Details;
            this.PacketList.SelectedIndexChanged += new System.EventHandler(this.PacketList_SelectedIndexChanged);
            // 
            // Source
            // 
            this.Source.Text = "Src";
            this.Source.Width = 61;
            // 
            // Idx
            // 
            this.Idx.Text = "Idx";
            this.Idx.Width = 79;
            // 
            // PacketName
            // 
            this.PacketName.Text = "Name";
            this.PacketName.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.splitContainer1.Panel1.Controls.Add(this.HexSplitter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.InspectorPropertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1612, 997);
            this.splitContainer1.SplitterDistance = 975;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitterPaint);
            // 
            // HexSplitter
            // 
            this.HexSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HexSplitter.Location = new System.Drawing.Point(0, 0);
            this.HexSplitter.Name = "HexSplitter";
            this.HexSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HexSplitter.Panel1
            // 
            this.HexSplitter.Panel1.Controls.Add(this.HexView);
            // 
            // HexSplitter.Panel2
            // 
            this.HexSplitter.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HexSplitter.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.HexSplitter.Size = new System.Drawing.Size(975, 997);
            this.HexSplitter.SplitterDistance = 800;
            this.HexSplitter.TabIndex = 1;
            // 
            // HexView
            // 
            this.HexView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.HexView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HexView.ColumnInfoVisible = true;
            this.HexView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HexView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HexView.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.HexView.GroupSeparatorVisible = true;
            this.HexView.Location = new System.Drawing.Point(0, 0);
            this.HexView.Margin = new System.Windows.Forms.Padding(0);
            this.HexView.Name = "HexView";
            this.HexView.ReadOnly = true;
            this.HexView.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(103)))), ((int)(((byte)(216)))));
            this.HexView.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.HexView.Size = new System.Drawing.Size(975, 800);
            this.HexView.StringViewVisible = true;
            this.HexView.TabIndex = 0;
            this.HexView.UseFixedBytesPerLine = true;
            this.HexView.VScrollBarVisible = true;
            this.HexView.SelectionLengthChanged += new System.EventHandler(this.HexView_SelectionLengthChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ValueDisplayLE, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ValueDisplayBE, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 193);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ValueDisplayLE
            // 
            this.ValueDisplayLE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueDisplayLE.IsLittleEndian = true;
            this.ValueDisplayLE.Location = new System.Drawing.Point(0, 0);
            this.ValueDisplayLE.Margin = new System.Windows.Forms.Padding(0);
            this.ValueDisplayLE.Name = "ValueDisplayLE";
            this.ValueDisplayLE.Size = new System.Drawing.Size(487, 193);
            this.ValueDisplayLE.TabIndex = 0;
            // 
            // ValueDisplayBE
            // 
            this.ValueDisplayBE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueDisplayBE.IsLittleEndian = false;
            this.ValueDisplayBE.Location = new System.Drawing.Point(487, 0);
            this.ValueDisplayBE.Margin = new System.Windows.Forms.Padding(0);
            this.ValueDisplayBE.Name = "ValueDisplayBE";
            this.ValueDisplayBE.Size = new System.Drawing.Size(488, 193);
            this.ValueDisplayBE.TabIndex = 1;
            // 
            // InspectorPropertyGrid
            // 
            this.InspectorPropertyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.InspectorPropertyGrid.CategoryForeColor = System.Drawing.SystemColors.ControlLight;
            this.InspectorPropertyGrid.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.InspectorPropertyGrid.CommandsForeColor = System.Drawing.SystemColors.ControlLight;
            this.InspectorPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.InspectorPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InspectorPropertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.InspectorPropertyGrid.HelpForeColor = System.Drawing.SystemColors.ControlLight;
            this.InspectorPropertyGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.InspectorPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.InspectorPropertyGrid.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.InspectorPropertyGrid.Name = "InspectorPropertyGrid";
            this.InspectorPropertyGrid.Size = new System.Drawing.Size(630, 997);
            this.InspectorPropertyGrid.TabIndex = 0;
            this.InspectorPropertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.InspectorPropertyGrid.ViewForeColor = System.Drawing.SystemColors.ControlLight;
            // 
            // PacketInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.MainSplitter);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "PacketInspector";
            this.Size = new System.Drawing.Size(2133, 997);
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).EndInit();
            this.MainSplitter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.HexSplitter.Panel1.ResumeLayout(false);
            this.HexSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HexSplitter)).EndInit();
            this.HexSplitter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid InspectorPropertyGrid;
        private System.Windows.Forms.ListView PacketList;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Idx;
        private System.Windows.Forms.ColumnHeader PacketName;
        private Be.Windows.Forms.HexBox HexView;
        private System.Windows.Forms.SplitContainer HexSplitter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ValueDisplay ValueDisplayLE;
        private ValueDisplay ValueDisplayBE;
    }
}
