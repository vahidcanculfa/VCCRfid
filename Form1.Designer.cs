namespace VCCRfid2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.ColumnReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalTags = new System.Windows.Forms.Label();
            this.txtPromptMessage = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBaud = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.panelTopControls = new System.Windows.Forms.Panel();
            this.tmrScan = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelTopControls.SuspendLayout();
            this.SuspendLayout();
            

            this.btnConnect.Location = new System.Drawing.Point(400, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            


            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(486, 10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(80, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            


            this.btnScan.Location = new System.Drawing.Point(572, 10);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(80, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            


            this.btnStop.Location = new System.Drawing.Point(658, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            


            this.btnClearData.Location = new System.Drawing.Point(744, 10);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(80, 23);
            this.btnClearData.TabIndex = 4;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            


            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReaderName,
            this.ColumnEPC,
            this.ColumnTID,
            this.ColumnUserData,
            this.ColumnAnt,
            this.ColumnRSSI,
            this.ColumnReadTime,
            this.ColumnReserved});
            this.dgvTags.Location = new System.Drawing.Point(12, 53);
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.ReadOnly = true;
            this.dgvTags.RowHeadersWidth = 51;
            this.dgvTags.RowTemplate.Height = 24;
            this.dgvTags.Size = new System.Drawing.Size(833, 300);
            this.dgvTags.TabIndex = 5;
            



            this.ColumnReaderName.HeaderText = "Reader Name";
            this.ColumnReaderName.MinimumWidth = 6;
            this.ColumnReaderName.Name = "ColumnReaderName";
            this.ColumnReaderName.ReadOnly = true;
            this.ColumnReaderName.Width = 125;
            



            this.ColumnEPC.HeaderText = "EPC";
            this.ColumnEPC.MinimumWidth = 6;
            this.ColumnEPC.Name = "ColumnEPC";
            this.ColumnEPC.ReadOnly = true;
            this.ColumnEPC.Width = 125;
            



            this.ColumnTID.HeaderText = "TID";
            this.ColumnTID.MinimumWidth = 6;
            this.ColumnTID.Name = "ColumnTID";
            this.ColumnTID.ReadOnly = true;
            this.ColumnTID.Width = 125;
            


            this.ColumnUserData.HeaderText = "User Data";
            this.ColumnUserData.MinimumWidth = 6;
            this.ColumnUserData.Name = "ColumnUserData";
            this.ColumnUserData.ReadOnly = true;
            this.ColumnUserData.Width = 125;
           


            this.ColumnAnt.HeaderText = "Antenna";
            this.ColumnAnt.MinimumWidth = 6;
            this.ColumnAnt.Name = "ColumnAnt";
            this.ColumnAnt.ReadOnly = true;
            this.ColumnAnt.Width = 75;
            


            this.ColumnRSSI.HeaderText = "RSSI";
            this.ColumnRSSI.MinimumWidth = 6;
            this.ColumnRSSI.Name = "ColumnRSSI";
            this.ColumnRSSI.ReadOnly = true;
            this.ColumnRSSI.Width = 75;
            


            this.ColumnReadTime.HeaderText = "Read Time";
            this.ColumnReadTime.MinimumWidth = 6;
            this.ColumnReadTime.Name = "ColumnReadTime";
            this.ColumnReadTime.ReadOnly = true;
            this.ColumnReadTime.Width = 125;
            


            this.ColumnReserved.HeaderText = "Reserved";
            this.ColumnReserved.MinimumWidth = 6;
            this.ColumnReserved.Name = "ColumnReserved";
            this.ColumnReserved.ReadOnly = true;
            this.ColumnReserved.Width = 125;
            


            this.lblTotalTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalTags.AutoSize = true;
            this.lblTotalTags.Location = new System.Drawing.Point(12, 365);
            this.lblTotalTags.Name = "lblTotalTags";
            this.lblTotalTags.Size = new System.Drawing.Size(95, 16);
            this.lblTotalTags.TabIndex = 6;
            this.lblTotalTags.Text = "Total Number: 0";
            


            this.txtPromptMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPromptMessage.Location = new System.Drawing.Point(12, 390);
            this.txtPromptMessage.Name = "txtPromptMessage";
            this.txtPromptMessage.ReadOnly = true;
            this.txtPromptMessage.Size = new System.Drawing.Size(833, 100);
            this.txtPromptMessage.TabIndex = 7;
            this.txtPromptMessage.Text = "";
            



            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelPort,
            this.toolStripStatusLabelBaud});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            


            this.toolStripStatusLabelPort.Name = "toolStripStatusLabelPort";
            this.toolStripStatusLabelPort.Size = new System.Drawing.Size(43, 20);
            this.toolStripStatusLabelPort.Text = "Port: ";
            


            this.toolStripStatusLabelBaud.Name = "toolStripStatusLabelBaud";
            this.toolStripStatusLabelBaud.Size = new System.Drawing.Size(51, 20);
            this.toolStripStatusLabelBaud.Text = "Baud: ";
           



            this.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(60, 10);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 24);
            this.cmbPorts.TabIndex = 9;
            



            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(10, 13);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 16);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(198, 13);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(73, 16);
            this.lblBaudRate.TabIndex = 11;
            this.lblBaudRate.Text = "Baud Rate:";
            



            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(277, 10);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(117, 24);
            this.cmbBaudRate.TabIndex = 12;
            



            this.panelTopControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopControls.Controls.Add(this.cmbBaudRate);
            this.panelTopControls.Controls.Add(this.lblBaudRate);
            this.panelTopControls.Controls.Add(this.lblPort);
            this.panelTopControls.Controls.Add(this.cmbPorts);
            this.panelTopControls.Controls.Add(this.btnConnect);
            this.panelTopControls.Controls.Add(this.btnDisconnect);
            this.panelTopControls.Controls.Add(this.btnScan);
            this.panelTopControls.Controls.Add(this.btnStop);
            this.panelTopControls.Controls.Add(this.btnClearData);
            this.panelTopControls.Location = new System.Drawing.Point(12, 0);
            this.panelTopControls.Name = "panelTopControls";
            this.panelTopControls.Size = new System.Drawing.Size(833, 47);
            this.panelTopControls.TabIndex = 13;
            


            this.tmrScan.Tick += new System.EventHandler(this.tmrScan_Tick);
            



            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 524);
            this.Controls.Add(this.panelTopControls);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtPromptMessage);
            this.Controls.Add(this.lblTotalTags);
            this.Controls.Add(this.dgvTags);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "VCC RFID Reader Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTopControls.ResumeLayout(false);
            this.panelTopControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.Label lblTotalTags;
        private System.Windows.Forms.RichTextBox txtPromptMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBaud;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Panel panelTopControls;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReserved;
        private System.Windows.Forms.Timer tmrScan;
    }
}