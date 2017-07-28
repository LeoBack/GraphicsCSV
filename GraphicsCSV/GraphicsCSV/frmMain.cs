using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using libCsv;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphicsCSV
{
    public partial class frmMain : Form
    {
        #region Atributos y propiedades

        classManager oCsv = new classManager();
        classItems Items = new classItems();
        //
        BackgroundWorker bkProcess;
        DataTable oData;
        DataTable dtResult;

        string pathLog = Path.Combine(Application.StartupPath, "Logs");
        string fileLog = string.Empty;
        string[] filter = { "15 minutos", "30 minutos", "60 minutos" };

        #endregion

        #region Frm

        public frmMain()
        {
            InitializeComponent();
            //
            bkProcess = new BackgroundWorker();
            bkProcess.DoWork += bkProcess_DoWork;
            bkProcess.ProgressChanged += bkProcess_ProgressChanged;
            bkProcess.RunWorkerCompleted += bkProcess_RunWorkerCompleted;
            bkProcess.WorkerReportsProgress = true;
            bkProcess.WorkerSupportsCancellation = true;
            //
            if (!Directory.Exists(pathLog))
                Directory.CreateDirectory(pathLog);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //
            tsslProcessStatus.Text = "Waiting";
            tsslDescription.Text = "Select a file and apply";
            showRunProcess(false);
            //
            initDataView();
            initGraphicStatistical();
            //
            // cmbFileSelected
            string[] files = Directory.GetFiles(pathLog, "*.csv", SearchOption.TopDirectoryOnly);
            if (files.Length != 0)
                tscmbFileSelected.Items.AddRange(OnlyNamefile(files));
            tscmbFileSelected.Items.Add("Open Directory");

            // cmbBaseTime
            tscmbBaseTime.Items.AddRange(filter);

            GetDataView(Items.PreLoad());
        }

        #endregion

        #region Eventos

        private void tscmbFileSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscmbFileSelected.SelectedIndex == tscmbFileSelected.Items.Count - 1)
            {
                OpenFileDialog oF = new OpenFileDialog();
                oF.InitialDirectory = pathLog;
                oF.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                oF.FilterIndex = 1;
                oF.RestoreDirectory = true;
                oF.Multiselect = false;

                if (oF.ShowDialog() == DialogResult.OK)
                    fileLog = oF.FileName;
            }
            else
            {
                int cfile = 0;
                string[] files = Directory.GetFiles(pathLog, "*.csv", SearchOption.TopDirectoryOnly);
                fileLog = files[cfile];
                while (Convert.ToString(tscmbFileSelected.SelectedItem) != Path.GetFileName(fileLog))
                    fileLog = files[cfile++];
            }
        }

        private void tsbtnApply_Click(object sender, EventArgs e)
        {
            if (fileLog != "")
            {
                Text = "GraphicsCSV - " + Path.GetFileName(fileLog);
                oData = oCsv.ReadFileCSV(classManager.Headers.Disable, fileLog);
                StarProcess();
            }
        }

        private void tsbtnDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strDetail.ToString());
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            if (bkProcess.WorkerSupportsCancellation == true)
                bkProcess.CancelAsync();
        }

        #endregion

        // OK - 28/07/17
        #region Graphic

        /// <summary>
        /// OK - 28/07/17
        /// Habilita la funcion de Zoom para el Grafico.
        /// </summary>
        /// <param name="Enabled"></param>
        void ZoomToggle(bool Enabled)
        {
            // Enable range selection and zooming end user interface
            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorX.Interval = 0;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.ScrollBar.IsPositionedInside = true;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.ResetZoom;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.ScaleView.SmallScrollMinSize = 0;

            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorY.IsUserEnabled = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].CursorY.Interval = 0;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = Enabled;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisY.ScrollBar.IsPositionedInside = true;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.ResetZoom;
            chrGraphicStatistical.ChartAreas["ChartArea1"].AxisY.ScaleView.SmallScrollMinSize = 0;
            if (Enabled == false)
            {
                //Remove the cursor lines
                chrGraphicStatistical.ChartAreas["ChartArea1"].CursorX.SetCursorPosition(double.NaN);
                chrGraphicStatistical.ChartAreas["ChartArea1"].CursorY.SetCursorPosition(double.NaN);
            }
        }

        /// <summary>
        /// OK - 28/07/17
        /// Inicializa el Grafico.
        /// </summary>
        void initGraphicStatistical()
        {
            chrGraphicStatistical.Series.Clear();
            chrGraphicStatistical.Titles.Add("Monitor");
            chrGraphicStatistical.Palette = ChartColorPalette.Excel;
            chrGraphicStatistical.ContextMenuStrip = cmsGraphics;
            ZoomToggle(true);
        }

        /// <summary>
        /// OK - 28/07/17
        /// Recarga el grafico.
        /// </summary>
        void RefreshGraphicStatistical()
        {
            chrGraphicStatistical.DataSource = null;
            chrGraphicStatistical.Series.Clear();
            chrGraphicStatistical.DataSource = dtResult;

            foreach(DataColumn fColumn in dtResult.Columns)
            {
                if (fColumn.ColumnName != dtResult.Columns[0].ColumnName)
                {
                    chrGraphicStatistical.Series.Add(fColumn.ColumnName);
                    chrGraphicStatistical.Series[fColumn.ColumnName].ChartType = SeriesChartType.Line;
                    chrGraphicStatistical.Series[fColumn.ColumnName].YValueMembers = fColumn.ColumnName;
                    chrGraphicStatistical.Series[fColumn.ColumnName].XValueMember = dtResult.Columns[0].ColumnName;
                    chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.Interval = 10;
                    chrGraphicStatistical.DataBind();
                    //chrGraphicStatistical.Series[fColumn.ColumnName].Color = this.ColorData1;
                }
            }
        }

        /// <summary>
        /// OK - 28/07/17
        /// Evento: Exportar el grafico como imagen.
        /// </summary>
        private void tsmiExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveGraphic = new SaveFileDialog();
            saveGraphic.Filter = "jpeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveGraphic.Title = "Guardar Grafico en Imagen";
            saveGraphic.ShowDialog();

            if (saveGraphic.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveGraphic.OpenFile();
                switch (saveGraphic.FilterIndex)
                {
                    case 1:
                        this.chrGraphicStatistical.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        this.chrGraphicStatistical.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        this.chrGraphicStatistical.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }
        
        #endregion

        // Revisar - 28/07/17
        #region Grilla

        private void initDataView()
        {
#if DEBUG
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Item";
            colId.DataPropertyName = "IdItem";
            colId.ReadOnly = true;
            dgvList.Columns.Add(colId);
#endif
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Nombre";
            colName.DataPropertyName = "NameItem";
            colName.ReadOnly = false;
            dgvList.Columns.Add(colName);

            DataGridViewTextBoxColumn colColor = new DataGridViewTextBoxColumn();
            colColor.Name = "Color";
            colColor.DataPropertyName = "ColorItem";
            colColor.ReadOnly = true;
            dgvList.Columns.Add(colColor);

            DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn();
            colChk.Name = "Mostrar";
            colChk.DataPropertyName = "ChkItem";
            colChk.ReadOnly = false;
            colChk.ThreeState = false;
            dgvList.Columns.Add(colChk);

            dgvList.RowHeadersVisible = false;
            dgvList.AutoGenerateColumns = false;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.BorderStyle = BorderStyle.FixedSingle;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.MultiSelect = false;
            dgvList.ReadOnly = false;
            // Solo cuando cambio el contenido y preciono Enter
            dgvList.CellValueChanged += dgvList_CellValueChanged;
            // Solo cuando cambia el contenido 
            dgvList.CurrentCellDirtyStateChanged += dgvList_CurrentCellDirtyStateChanged;
            // 
            dgvList.DataError += dgvList_DataError;
        }

        void dgvList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            string A = "";
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (Convert.ToString(row.Cells[3].Value) == "")
                    row.Cells[3].Value = false;

                A += row.Cells[3].Value.ToString() + "\n";
            }
            MessageBox.Show("Cambio algo en la Grilla\nCurrentCellDirtyStateChanged\n" + A);
        }

        void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Cambio algo en la Grilla\nCellValueChanged");
        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show(this, e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void GetDataView(DataTable data)
        {
            //SourceBinding.CurrentItemChanged -= SourceBinding_CurrentItemChanged;
            //dgvList.DataSource = null;
            //SourceBinding.DataSource = data;
            //dgvList.DataSource = SourceBinding;
            //SourceBinding.CurrentItemChanged += SourceBinding_CurrentItemChanged;
            dgvList.DataSource = data;

            CellColor(data);
        }

        void CellColor(DataTable dT)
        {
            //for (int P = 0; P < dgvList.Rows.Count; P++)
            //    dgvList.Rows[P].Cells[2].Style.BackColor = Color.FromName(Convert.ToString(dgvList.Rows[P].Cells[2].Value));

            //for (int P = 0; P < dgvList.Rows.Count; P++)
            //    dgvList.Rows[P].Cells[2].Style.BackColor = Color.FromName(dT.Rows[P].ToString());

            //OK
            //dgvList.Rows[0].Cells[2].Style.BackColor = Color.Blue;
            //dgvList.Rows[1].Cells[2].Style.BackColor = Color.Red;
            //dgvList.Rows[2].Cells[2].Style.BackColor = Color.Green;

        }

        #endregion

        // OK - 28/07/17
        #region bkProgess

        int cRecordsErrors = 0;
        bool iError = false;
        StringBuilder strDetail = new StringBuilder();

        /// <summary>
        /// OK - 28/07/17
        /// Disparador de ejecucion del Subproceso.
        /// </summary>
        void StarProcess()
        {
            tsslDescription.Text = "";
            if (bkProcess.IsBusy != true)
            {
                showRunProcess(true);
                tsslProcessStatus.Text = "Loaded";
                tspbProgress.Maximum = oData.Rows.Count;
                bkProcess.RunWorkerAsync();
            }
        }

        /// <summary>
        /// OK - 28/07/17
        /// Evento cuando finaliza el Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                tsslProcessStatus.Text = "Cancelled";
                tsslDescription.Text = "Records: " + oData.Rows.Count.ToString();
                strDetail.Clear();
                strDetail.AppendLine("Canceled by user request.");
                MessageBox.Show(strDetail.ToString());
            }
            else if (e.Error != null)
            {
                tsslProcessStatus.Text = "Error";
                strDetail.Clear();
                strDetail.AppendLine("Error message with process.");
                strDetail.AppendLine(e.Error.Message);
                MessageBox.Show(strDetail.ToString());
            }
            else
            {
                tsslProcessStatus.Text = "Finalized";
                tsslDescription.Text = "Records: " + oData.Rows.Count.ToString();
                strDetail.Clear();
                strDetail.AppendLine("Records Processed: " + oData.Rows.Count.ToString());
                strDetail.AppendLine("Correct records = " + dtResult.Rows.Count.ToString());
                strDetail.AppendLine("Records with errors = " + cRecordsErrors.ToString());
                MessageBox.Show(strDetail.ToString());       
                RefreshGraphicStatistical();
            }
            showRunProcess(false);
        }

        /// <summary>
        /// OK - 28/07/17
        /// Evento durante la ejecucion del Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsslProcessStatus.Text = "Working";
            tsslDescription.Text = "Records: " + e.ProgressPercentage.ToString() + "/" + oData.Rows.Count.ToString();
            tsslStatus.Text = (((e.ProgressPercentage * 100) / oData.Rows.Count).ToString() + " %");
            tspbProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// OK - 28/07/17
        /// Evento del Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            cRecordsErrors = 0;
            

            int cRow = 0;
            BackgroundWorker worker = sender as BackgroundWorker;

            dtResult = new DataTable("Result");

            foreach (DataColumn column in oData.Columns)
                dtResult.Columns.Add(new DataColumn(column.ColumnName));

            foreach (DataRow row in oData.Rows)
            {
                iError = false;
                worker.ReportProgress(++cRow);

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    dtResult = null;
                    break;
                }
                else
                {
                    DataRow newRow = dtResult.NewRow();
                    newRow[0] = processDateTime(row[0].ToString()).ToShortTimeString(); // Columna Fecha  
                    newRow[1] = processNumber(row[1].ToString());   // Columna Temperatura
                    newRow[2] = processNumber(row[2].ToString());   // Columna Humedad

                    if (!iError)
                        dtResult.Rows.Add(newRow);
                    else
                        cRecordsErrors++;
                }
            }
        }

        #endregion

        // OK - 28/07/17
        #region  Metodos

        /// <summary>
        /// OK - 28/07/17
        /// Mostrar o Ocultar los indicadores de proceso en ejecucion.
        /// </summary>
        /// <param name="Show"></param>
        void showRunProcess(bool Show)
        {
            tspbProgress.Value = 0;
            tspbProgress.Visible = Show;
            tsslStatus.Text = "0 %";
            tsslStatus.Visible = Show;
            tsddbStop.Visible = Show;
        }

        /// <summary>
        /// OK - 28/07/17
        /// Devuelve: DateTime desde un string con el siguiente formato (2017,7,6-19,07,30).
        /// </summary>
        /// <param name="vDateTime"></param>
        /// <returns></returns>
        DateTime processDateTime(string vDateTime)
        {
            DateTime newDate = new DateTime();
            if (vDateTime != "")
            {
                // Dia,Mes,Año-Hora,Min,Seg ( @"2017,7,6-19,07,30"; )
                string colDateTime = vDateTime.Replace('-', ',');
                string[] nDateTime = colDateTime.Split(',');

                try
                {
                    newDate = new DateTime(
                        Convert.ToInt32(nDateTime[0]),
                        Convert.ToInt32(nDateTime[1]),
                        Convert.ToInt32(nDateTime[2]),
                        Convert.ToInt32(nDateTime[3]),
                        Convert.ToInt32(nDateTime[4]),
                        Convert.ToInt32(nDateTime[5]));
                }
                catch (IndexOutOfRangeException) { iError = true; }
                catch (FormatException) { iError = true; }
            }
            return newDate;
        }

        /// <summary>
        /// OK - 28/07/17
        /// Devuelve: Numero con decimales. 
        /// </summary>
        /// <param name="vNumber"></param>
        /// <returns></returns>
        double processNumber(string vNumber)
        {
            return Convert.ToDouble(vNumber.Replace('.', ','));
        }

        /// <summary>
        /// OK - 28/07/17
        /// Devuelve: Array con solo los nombres de los archivos y extencion. 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        string[] OnlyNamefile(string[] files)
        {
            string[] sP = new string[files.Length];
            for (int C = 0; C < files.Length; C++)
                sP[C] = Path.GetFileName(files[C]);
            return sP;
        }

        #endregion
    }
}
