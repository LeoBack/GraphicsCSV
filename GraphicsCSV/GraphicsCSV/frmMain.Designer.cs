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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chrGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.lblBaseTime = new System.Windows.Forms.Label();
            this.cmbFileSelected = new System.Windows.Forms.ComboBox();
            this.cmbBaseTime = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tlpPanel.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrGraphic)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.tlpTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 431);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(831, 163);
            this.dgvList.TabIndex = 0;
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpPanel.Controls.Add(this.msMain, 0, 0);
            this.tlpPanel.Controls.Add(this.ssStatus, 0, 3);
            this.tlpPanel.Controls.Add(this.chrGraphic, 0, 1);
            this.tlpPanel.Controls.Add(this.dgvList, 0, 2);
            this.tlpPanel.Controls.Add(this.pnlTools, 1, 2);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 4;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPanel.Size = new System.Drawing.Size(1137, 630);
            this.tlpPanel.TabIndex = 1;
            // 
            // ssStatus
            // 
            this.tlpPanel.SetColumnSpan(this.ssStatus, 2);
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 600);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1137, 30);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // msMain
            // 
            this.tlpPanel.SetColumnSpan(this.msMain, 2);
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1137, 32);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(86, 25);
            this.tsslStatus.Text = "tsslStatus";
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
            this.tsmiExit.Size = new System.Drawing.Size(210, 30);
            this.tsmiExit.Text = "Exit";
            // 
            // chrGraphic
            // 
            chartArea2.Name = "ChartArea1";
            this.chrGraphic.ChartAreas.Add(chartArea2);
            this.tlpPanel.SetColumnSpan(this.chrGraphic, 2);
            this.chrGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrGraphic.Legends.Add(legend2);
            this.chrGraphic.Location = new System.Drawing.Point(3, 35);
            this.chrGraphic.Name = "chrGraphic";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrGraphic.Series.Add(series2);
            this.chrGraphic.Size = new System.Drawing.Size(1131, 390);
            this.chrGraphic.TabIndex = 3;
            this.chrGraphic.Text = "chrGraphic";
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.tlpTools);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTools.Location = new System.Drawing.Point(840, 431);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(294, 163);
            this.pnlTools.TabIndex = 4;
            // 
            // tlpTools
            // 
            this.tlpTools.ColumnCount = 2;
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTools.Controls.Add(this.lblFileSelected, 0, 1);
            this.tlpTools.Controls.Add(this.lblBaseTime, 0, 2);
            this.tlpTools.Controls.Add(this.cmbFileSelected, 1, 1);
            this.tlpTools.Controls.Add(this.cmbBaseTime, 1, 2);
            this.tlpTools.Controls.Add(this.btnApply, 1, 3);
            this.tlpTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTools.Location = new System.Drawing.Point(0, 0);
            this.tlpTools.Name = "tlpTools";
            this.tlpTools.RowCount = 4;
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTools.Size = new System.Drawing.Size(294, 163);
            this.tlpTools.TabIndex = 0;
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.AutoSize = true;
            this.lblFileSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileSelected.Location = new System.Drawing.Point(3, 32);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(82, 32);
            this.lblFileSelected.TabIndex = 0;
            this.lblFileSelected.Text = "File";
            this.lblFileSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBaseTime
            // 
            this.lblBaseTime.AutoSize = true;
            this.lblBaseTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaseTime.Location = new System.Drawing.Point(3, 64);
            this.lblBaseTime.Name = "lblBaseTime";
            this.lblBaseTime.Size = new System.Drawing.Size(82, 32);
            this.lblBaseTime.TabIndex = 1;
            this.lblBaseTime.Text = "BaseTime";
            this.lblBaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFileSelected
            // 
            this.cmbFileSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFileSelected.FormattingEnabled = true;
            this.cmbFileSelected.Location = new System.Drawing.Point(91, 35);
            this.cmbFileSelected.Name = "cmbFileSelected";
            this.cmbFileSelected.Size = new System.Drawing.Size(200, 28);
            this.cmbFileSelected.TabIndex = 2;
            // 
            // cmbBaseTime
            // 
            this.cmbBaseTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaseTime.FormattingEnabled = true;
            this.cmbBaseTime.Location = new System.Drawing.Point(91, 67);
            this.cmbBaseTime.Name = "cmbBaseTime";
            this.cmbBaseTime.Size = new System.Drawing.Size(200, 28);
            this.cmbBaseTime.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(198, 101);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 59);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
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
        private System.Windows.Forms.Label lblFileSelected;
        private System.Windows.Forms.Label lblBaseTime;
        private System.Windows.Forms.ComboBox cmbFileSelected;
        private System.Windows.Forms.ComboBox cmbBaseTime;
        private System.Windows.Forms.Button btnApply;
    }
}

