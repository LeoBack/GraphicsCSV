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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chrGraphicStatistical = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslFile = new System.Windows.Forms.ToolStripLabel();
            this.tscmbFileSelected = new System.Windows.Forms.ToolStripComboBox();
            this.tslblBaseTime = new System.Windows.Forms.ToolStripLabel();
            this.tscmbBaseTime = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnApply = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDetails = new System.Windows.Forms.ToolStripButton();
            this.tsmiColumns = new System.Windows.Forms.ToolStripButton();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProcessStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsddbStop = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmsGraphics = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExportImage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tlpPanel.SuspendLayout();
            this.msMain.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrGraphicStatistical)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.cmsGraphics.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 343);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(1244, 143);
            this.dgvList.TabIndex = 0;
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 1;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1256F));
            this.tlpPanel.Controls.Add(this.msMain, 0, 0);
            this.tlpPanel.Controls.Add(this.toolStripContainer1, 0, 1);
            this.tlpPanel.Controls.Add(this.ssStatus, 0, 2);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpPanel.Size = new System.Drawing.Size(1256, 602);
            this.tlpPanel.TabIndex = 1;
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.toolsToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1256, 32);
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
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 28);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1250, 489);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 35);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1250, 522);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.56079F));
            this.tableLayoutPanel1.Controls.Add(this.chrGraphicStatistical, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.65066F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.34934F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 489);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chrGraphicStatistical
            // 
            chartArea1.Name = "ChartArea1";
            this.chrGraphicStatistical.ChartAreas.Add(chartArea1);
            this.chrGraphicStatistical.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrGraphicStatistical.Legends.Add(legend1);
            this.chrGraphicStatistical.Location = new System.Drawing.Point(3, 3);
            this.chrGraphicStatistical.Name = "chrGraphicStatistical";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrGraphicStatistical.Series.Add(series1);
            this.chrGraphicStatistical.Size = new System.Drawing.Size(1244, 334);
            this.chrGraphicStatistical.TabIndex = 3;
            this.chrGraphicStatistical.Text = "chrGraphicStatistical";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslFile,
            this.tscmbFileSelected,
            this.tslblBaseTime,
            this.tscmbBaseTime,
            this.tsbtnApply,
            this.tsbtnDetails,
            this.tsmiColumns});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 33);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslFile
            // 
            this.tslFile.AutoSize = false;
            this.tslFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tslFile.Name = "tslFile";
            this.tslFile.Size = new System.Drawing.Size(70, 30);
            this.tslFile.Text = "File";
            this.tslFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tscmbFileSelected
            // 
            this.tscmbFileSelected.Name = "tscmbFileSelected";
            this.tscmbFileSelected.Size = new System.Drawing.Size(140, 33);
            this.tscmbFileSelected.SelectedIndexChanged += new System.EventHandler(this.tscmbFileSelected_SelectedIndexChanged);
            // 
            // tslblBaseTime
            // 
            this.tslblBaseTime.AutoSize = false;
            this.tslblBaseTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tslblBaseTime.Name = "tslblBaseTime";
            this.tslblBaseTime.Size = new System.Drawing.Size(100, 30);
            this.tslblBaseTime.Text = "BaseTime";
            this.tslblBaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tscmbBaseTime
            // 
            this.tscmbBaseTime.Name = "tscmbBaseTime";
            this.tscmbBaseTime.Size = new System.Drawing.Size(140, 33);
            // 
            // tsbtnApply
            // 
            this.tsbtnApply.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnApply.Image")));
            this.tsbtnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnApply.Name = "tsbtnApply";
            this.tsbtnApply.Size = new System.Drawing.Size(87, 30);
            this.tsbtnApply.Text = "Apply";
            this.tsbtnApply.Click += new System.EventHandler(this.tsbtnApply_Click);
            // 
            // tsbtnDetails
            // 
            this.tsbtnDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDetails.Image")));
            this.tsbtnDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDetails.Name = "tsbtnDetails";
            this.tsbtnDetails.Size = new System.Drawing.Size(85, 30);
            this.tsbtnDetails.Text = "Detail";
            this.tsbtnDetails.Click += new System.EventHandler(this.tsbtnDetails_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProcessStatus,
            this.tsslDescription,
            this.tsslStatus,
            this.tspbProgress,
            this.tsddbStop});
            this.ssStatus.Location = new System.Drawing.Point(0, 571);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1256, 31);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslProcessStatus
            // 
            this.tsslProcessStatus.AutoSize = false;
            this.tsslProcessStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslProcessStatus.Name = "tsslProcessStatus";
            this.tsslProcessStatus.Size = new System.Drawing.Size(80, 26);
            this.tsslProcessStatus.Text = "Process";
            // 
            // tsslDescription
            // 
            this.tsslDescription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDescription.Name = "tsslDescription";
            this.tsslDescription.Size = new System.Drawing.Size(923, 26);
            this.tsslDescription.Spring = true;
            this.tsslDescription.Text = "Description";
            this.tsslDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslStatus
            // 
            this.tsslStatus.AutoSize = false;
            this.tsslStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(45, 26);
            this.tsslStatus.Text = "0%";
            // 
            // tspbProgress
            // 
            this.tspbProgress.AutoSize = false;
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 25);
            // 
            // tsddbStop
            // 
            this.tsddbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsddbStop.Image")));
            this.tsddbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbStop.Name = "tsddbStop";
            this.tsddbStop.Size = new System.Drawing.Size(91, 29);
            this.tsddbStop.Text = "Stop";
            this.tsddbStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // cmsGraphics
            // 
            this.cmsGraphics.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsGraphics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportImage});
            this.cmsGraphics.Name = "cmsGraphics";
            this.cmsGraphics.Size = new System.Drawing.Size(216, 34);
            // 
            // tsmiExportImage
            // 
            this.tsmiExportImage.Name = "tsmiExportImage";
            this.tsmiExportImage.Size = new System.Drawing.Size(215, 30);
            this.tsmiExportImage.Text = "Exportar Imagen";
            this.tsmiExportImage.Click += new System.EventHandler(this.tsmiExportImage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 602);
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
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrGraphicStatistical)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.cmsGraphics.ResumeLayout(false);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chrGraphicStatistical;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.ToolStripStatusLabel tsslDescription;
        private System.Windows.Forms.ToolStripDropDownButton tsddbStop;
        private System.Windows.Forms.ToolStripStatusLabel tsslProcessStatus;
        private System.Windows.Forms.ContextMenuStrip cmsGraphics;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslFile;
        private System.Windows.Forms.ToolStripComboBox tscmbFileSelected;
        private System.Windows.Forms.ToolStripLabel tslblBaseTime;
        private System.Windows.Forms.ToolStripComboBox tscmbBaseTime;
        private System.Windows.Forms.ToolStripButton tsbtnApply;
        private System.Windows.Forms.ToolStripButton tsbtnDetails;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton tsmiColumns;
    }
}

