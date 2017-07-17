namespace GraphicsCSV
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProcessStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddbMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.chrGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.cmbFileSelected = new System.Windows.Forms.ComboBox();
            this.lblBaseTime = new System.Windows.Forms.Label();
            this.cmbBaseTime = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tlpPanel.SuspendLayout();
            this.msMain.SuspendLayout();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrGraphic)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.tlpTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 439);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(1131, 150);
            this.dgvList.TabIndex = 0;
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 1;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.Controls.Add(this.msMain, 0, 0);
            this.tlpPanel.Controls.Add(this.ssStatus, 0, 4);
            this.tlpPanel.Controls.Add(this.chrGraphic, 0, 1);
            this.tlpPanel.Controls.Add(this.dgvList, 0, 3);
            this.tlpPanel.Controls.Add(this.pnlTools, 0, 2);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 5;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpPanel.Size = new System.Drawing.Size(1137, 630);
            this.tlpPanel.TabIndex = 1;
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1137, 32);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(50, 28);
            this.tsmiFile.Text = "File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(123, 30);
            this.tsmiExit.Text = "Exit";
            // 
            // ssStatus
            // 
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProcessStatus,
            this.tsslStatus,
            this.tspbProgress,
            this.tsddbMenu,
            this.tsslDescription});
            this.ssStatus.Location = new System.Drawing.Point(0, 600);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1137, 30);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslProcessStatus
            // 
            this.tsslProcessStatus.AutoSize = false;
            this.tsslProcessStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslProcessStatus.Name = "tsslProcessStatus";
            this.tsslProcessStatus.Size = new System.Drawing.Size(80, 25);
            this.tsslProcessStatus.Text = "Process";
            // 
            // tsslStatus
            // 
            this.tsslStatus.AutoSize = false;
            this.tsslStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(45, 25);
            this.tsslStatus.Text = "0%";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 24);
            // 
            // tsslDescription
            // 
            this.tsslDescription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslDescription.Name = "tsslDescription";
            this.tsslDescription.Size = new System.Drawing.Size(102, 25);
            this.tsslDescription.Text = "Description";
            // 
            // tsddbMenu
            // 
            this.tsddbMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDetails,
            this.tsmiStop});
            this.tsddbMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsddbMenu.Image")));
            this.tsddbMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMenu.Name = "tsddbMenu";
            this.tsddbMenu.Size = new System.Drawing.Size(42, 28);
            this.tsddbMenu.Text = "toolStripDropDownButton1";
            // 
            // tsmiDetails
            // 
            this.tsmiDetails.Name = "tsmiDetails";
            this.tsmiDetails.Size = new System.Drawing.Size(210, 30);
            this.tsmiDetails.Text = "Details";
            this.tsmiDetails.Click += new System.EventHandler(this.tsmiDetails_Click);
            // 
            // tsmiStop
            // 
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(210, 30);
            this.tsmiStop.Text = "Stop";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // chrGraphic
            // 
            chartArea2.Name = "ChartArea1";
            this.chrGraphic.ChartAreas.Add(chartArea2);
            this.chrGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrGraphic.Legends.Add(legend2);
            this.chrGraphic.Location = new System.Drawing.Point(3, 35);
            this.chrGraphic.Name = "chrGraphic";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrGraphic.Series.Add(series2);
            this.chrGraphic.Size = new System.Drawing.Size(1131, 358);
            this.chrGraphic.TabIndex = 3;
            this.chrGraphic.Text = "chrGraphic";
            // 
            // pnlTools
            // 
            this.pnlTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTools.Controls.Add(this.tlpTools);
            this.pnlTools.Location = new System.Drawing.Point(3, 399);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(1131, 34);
            this.pnlTools.TabIndex = 4;
            // 
            // tlpTools
            // 
            this.tlpTools.ColumnCount = 5;
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTools.Controls.Add(this.btnApply, 4, 0);
            this.tlpTools.Controls.Add(this.lblFileSelected, 0, 0);
            this.tlpTools.Controls.Add(this.cmbFileSelected, 1, 0);
            this.tlpTools.Controls.Add(this.lblBaseTime, 2, 0);
            this.tlpTools.Controls.Add(this.cmbBaseTime, 3, 0);
            this.tlpTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTools.Location = new System.Drawing.Point(0, 0);
            this.tlpTools.Name = "tlpTools";
            this.tlpTools.RowCount = 1;
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTools.Size = new System.Drawing.Size(1131, 34);
            this.tlpTools.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApply.Location = new System.Drawing.Point(1034, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 26);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.AutoSize = true;
            this.lblFileSelected.Location = new System.Drawing.Point(3, 0);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(34, 20);
            this.lblFileSelected.TabIndex = 0;
            this.lblFileSelected.Text = "File";
            this.lblFileSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFileSelected
            // 
            this.cmbFileSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFileSelected.FormattingEnabled = true;
            this.cmbFileSelected.Location = new System.Drawing.Point(78, 3);
            this.cmbFileSelected.Name = "cmbFileSelected";
            this.cmbFileSelected.Size = new System.Drawing.Size(417, 28);
            this.cmbFileSelected.TabIndex = 2;
            this.cmbFileSelected.SelectedIndexChanged += new System.EventHandler(this.cmbFileSelected_SelectedIndexChanged);
            // 
            // lblBaseTime
            // 
            this.lblBaseTime.AutoSize = true;
            this.lblBaseTime.Location = new System.Drawing.Point(501, 0);
            this.lblBaseTime.Name = "lblBaseTime";
            this.lblBaseTime.Size = new System.Drawing.Size(80, 20);
            this.lblBaseTime.TabIndex = 1;
            this.lblBaseTime.Text = "BaseTime";
            this.lblBaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBaseTime
            // 
            this.cmbBaseTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaseTime.FormattingEnabled = true;
            this.cmbBaseTime.Location = new System.Drawing.Point(611, 3);
            this.cmbBaseTime.Name = "cmbBaseTime";
            this.cmbBaseTime.Size = new System.Drawing.Size(417, 28);
            this.cmbBaseTime.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 630);
            this.Controls.Add(this.tlpPanel);
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Text = "Graphics CSV";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrGraphic)).EndInit();
            this.pnlTools.ResumeLayout(false);
            this.tlpTools.ResumeLayout(false);
            this.tlpTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrGraphic;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.TableLayoutPanel tlpTools;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblFileSelected;
        private System.Windows.Forms.ComboBox cmbFileSelected;
        private System.Windows.Forms.Label lblBaseTime;
        private System.Windows.Forms.ComboBox cmbBaseTime;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.ToolStripStatusLabel tsslDescription;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiStop;
        private System.Windows.Forms.ToolStripStatusLabel tsslProcessStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetails;
    }
}

