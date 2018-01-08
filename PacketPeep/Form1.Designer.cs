namespace PacketPeep
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.BttOpenPcap = new DarkUI.Controls.DarkButton();
            this.PacketInspector = new PacketPeep.PacketInspector();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BttServerConnect = new DarkUI.Controls.DarkButton();
            this.TBServerIP = new DarkUI.Controls.DarkTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(1365, 2);
            this.darkSeparator1.TabIndex = 1;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // BttOpenPcap
            // 
            this.BttOpenPcap.Location = new System.Drawing.Point(3, 4);
            this.BttOpenPcap.Name = "BttOpenPcap";
            this.BttOpenPcap.Padding = new System.Windows.Forms.Padding(5);
            this.BttOpenPcap.Size = new System.Drawing.Size(75, 23);
            this.BttOpenPcap.TabIndex = 2;
            this.BttOpenPcap.Text = "Open Pcap";
            this.BttOpenPcap.Click += new System.EventHandler(this.BttOpenPcap_Click);
            // 
            // PacketInspector
            // 
            this.PacketInspector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketInspector.BackColor = System.Drawing.Color.Black;
            this.PacketInspector.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.PacketInspector.Location = new System.Drawing.Point(0, 33);
            this.PacketInspector.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PacketInspector.Name = "PacketInspector";
            this.PacketInspector.Size = new System.Drawing.Size(1365, 765);
            this.PacketInspector.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BttServerConnect);
            this.panel1.Controls.Add(this.TBServerIP);
            this.panel1.Controls.Add(this.BttOpenPcap);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1365, 32);
            this.panel1.TabIndex = 4;
            // 
            // BttServerConnect
            // 
            this.BttServerConnect.Location = new System.Drawing.Point(305, 4);
            this.BttServerConnect.Name = "BttServerConnect";
            this.BttServerConnect.Padding = new System.Windows.Forms.Padding(5);
            this.BttServerConnect.Size = new System.Drawing.Size(112, 23);
            this.BttServerConnect.TabIndex = 6;
            this.BttServerConnect.Text = "Connect To Server";
            // 
            // TBServerIP
            // 
            this.TBServerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.TBServerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBServerIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TBServerIP.Location = new System.Drawing.Point(84, 6);
            this.TBServerIP.Name = "TBServerIP";
            this.TBServerIP.Size = new System.Drawing.Size(215, 20);
            this.TBServerIP.TabIndex = 5;
            this.TBServerIP.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 797);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PacketInspector);
            this.Controls.Add(this.darkSeparator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PacketPeep :3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkButton BttOpenPcap;
        private PacketInspector PacketInspector;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkButton BttServerConnect;
        private DarkUI.Controls.DarkTextBox TBServerIP;
    }
}

