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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chrGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
            this.cmbBaseTime = new System.Windows.Forms.ComboBox();
            this.lblBaseTime = new System.Windows.Forms.Label();
            this.cmbFileSelected = new System.Windows.Forms.ComboBox();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
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
            this.dgvList.Location = new System.Drawing.Point(3, 443);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(407, 151);
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
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
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
            this.tsmiExit.Size = new System.Drawing.Size(210, 30);
            this.tsmiExit.Text = "Exit";
            // 
            // ssStatus
            // 
            this.ssStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 600);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1137, 30);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(86, 25);
            this.tsslStatus.Text = "tsslStatus";
            // 
            // chrGraphic
            // 
            chartArea1.Name = "ChartArea1";
            this.chrGraphic.ChartAreas.Add(chartArea1);
            this.chrGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrGraphic.Legends.Add(legend1);
            this.chrGraphic.Location = new System.Drawing.Point(3, 35);
            this.chrGraphic.Name = "chrGraphic";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrGraphic.Series.Add(series1);
            this.chrGraphic.Size = new System.Drawing.Size(1131, 362);
            this.chrGraphic.TabIndex = 3;
            this.chrGraphic.Text = "chrGraphic";
            // 
            // pnlTools
            // 
            this.pnlTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTools.Controls.Add(this.tlpTools);
            this.pnlTools.Location = new System.Drawing.Point(3, 403);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(915, 34);
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
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTools.Size = new System.Drawing.Size(915, 34);
            this.tlpTools.TabIndex = 0;
            // 
            // cmbBaseTime
            // 
            this.cmbBaseTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaseTime.FormattingEnabled = true;
            this.cmbBaseTime.Location = new System.Drawing.Point(503, 3);
            this.cmbBaseTime.Name = "cmbBaseTime";
            this.cmbBaseTime.Size = new System.Drawing.Size(309, 28);
            this.cmbBaseTime.TabIndex = 3;
            // 
            // lblBaseTime
            // 
            this.lblBaseTime.AutoSize = true;
            this.lblBaseTime.Location = new System.Drawing.Point(393, 0);
            this.lblBaseTime.Name = "lblBaseTime";
            this.lblBaseTime.Size = new System.Drawing.Size(80, 20);
            this.lblBaseTime.TabIndex = 1;
            this.lblBaseTime.Text = "BaseTime";
            this.lblBaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFileSelected
            // 
            this.cmbFileSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFileSelected.FormattingEnabled = true;
            this.cmbFileSelected.Location = new System.Drawing.Point(78, 3);
            this.cmbFileSelected.Name = "cmbFileSelected";
            this.cmbFileSelected.Size = new System.Drawing.Size(309, 28);
            this.cmbFileSelected.TabIndex = 2;
            this.cmbFileSelected.SelectedIndexChanged += new System.EventHandler(this.cmbFileSelected_SelectedIndexChanged);
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
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnApply.Location = new System.Drawing.Point(818, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 26);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
    }
}

