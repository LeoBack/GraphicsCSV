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

        classManager oCsv;
        List<classItemsPropierties> lItemPropierties;
        List<classItemsStatistics> lStatistics;
        //
        BackgroundWorker bkProcess;
        DataTable dtData;
        DataTable dtResult;
        //
        string pathLog = Path.Combine(Application.StartupPath, "Logs");
        string fileLog = string.Empty;
        string fileLogTemp = string.Empty;
        string[] filter = { "15 minutos", "30 minutos", "60 minutos" };
        bool PrimeraLectura = true;

        #endregion

        #region Frm

        public frmMain()
        {
            InitializeComponent();
            oCsv = new classManager();
            lItemPropierties = new List<classItemsPropierties>();
            lStatistics = new List<classItemsStatistics>();
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
                dtData = oCsv.ReadFileCSV(classManager.Headers.Disable, fileLog);
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

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        // OK - 17/07/28
        #region Graphic

        /// <summary>
        /// OK - 17/07/28
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
        /// OK - 17/07/28
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
        /// OK - 17/07/28
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
                    chrGraphicStatistical.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                    chrGraphicStatistical.DataBind();
                    //chrGraphicStatistical.Series[fColumn.ColumnName].Color = this.ColorData1;
                }
            }
        }

        /// <summary>
        /// OK - 17/07/28
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

        // Revisar - 17/07/28
        #region Grilla

        private void initDataView()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Nº Columna";
            colId.DataPropertyName = "IdStatistics";
            colId.ReadOnly = true;
            dgvList.Columns.Add(colId);

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Nombre";
            colName.DataPropertyName = "ColumnName";
            colName.ReadOnly = true;
            dgvList.Columns.Add(colName);

            DataGridViewTextBoxColumn ColFormat = new DataGridViewTextBoxColumn();
            ColFormat.Name = "Formato";
            ColFormat.DataPropertyName = "DataFormat";
            ColFormat.ReadOnly = true;
            dgvList.Columns.Add(ColFormat);

            DataGridViewTextBoxColumn colMin = new DataGridViewTextBoxColumn();
            colMin.Name = "Min";
            colMin.DataPropertyName = "Min";
            colMin.ReadOnly = true;
            dgvList.Columns.Add(colMin);

            DataGridViewTextBoxColumn colMax = new DataGridViewTextBoxColumn();
            colMax.Name = "Max";
            colMax.DataPropertyName = "Max";
            colMax.ReadOnly = true;
            dgvList.Columns.Add(colMax);

            DataGridViewTextBoxColumn colAvg = new DataGridViewTextBoxColumn();
            colAvg.Name = "Avg";
            colAvg.DataPropertyName = "Avg";
            colAvg.ReadOnly = true;
            dgvList.Columns.Add(colAvg);

            DataGridViewButtonColumn colBtn = new DataGridViewButtonColumn();
            colBtn.Name = "Edit";
            colBtn.Text = "Propiedades";
            colBtn.UseColumnTextForButtonValue = true;
            colBtn.Width = 80;
            dgvList.Columns.Add(colBtn);

            dgvList.RowHeadersVisible = false;
            dgvList.AutoGenerateColumns = false;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.BorderStyle = BorderStyle.FixedSingle;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvList.MultiSelect = false;
            dgvList.ReadOnly = false;
            dgvList.CellContentClick += dgvList_CellContentClick;
        }

        /// <summary>
        /// OK - 17/07/30
        /// Evento ventana propiedades de la columna a graficar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                frmItemProperties frmProp = new frmItemProperties(lItemPropierties[e.RowIndex]);
                if (frmProp.ShowDialog() == DialogResult.OK)
                {
                    lItemPropierties[e.RowIndex] = frmProp.oItems;
                    PrimeraLectura = false;
                    StarProcess();
                }
            }
        }

        void GetDataView(object data)
        {
            //SourceBinding.CurrentItemChanged -= SourceBinding_CurrentItemChanged;
            dgvList.DataSource = null;
            //SourceBinding.DataSource = data;
            //dgvList.DataSource = SourceBinding;
            //SourceBinding.CurrentItemChanged += SourceBinding_CurrentItemChanged;
            dgvList.DataSource = data;

            //CellColor(data);
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

        // Revisar - 17/07/30
        #region bkProgess

        int cRecordsErrors = 0;
        bool iError = false;
        StringBuilder strDetail = new StringBuilder();

        /// <summary>
        /// OK - 17/07/28
        /// Disparador de ejecucion del Subproceso.
        /// </summary>
        void StarProcess()
        {
            tsslDescription.Text = "";
            if (bkProcess.IsBusy != true)
            {
                showRunProcess(true);
                tsslProcessStatus.Text = "Loaded";
                tspbProgress.Maximum = dtData.Rows.Count;
                lStatistics.Clear();
                bkProcess.RunWorkerAsync();
            }
        }

        /// <summary>
        /// OK - 17/07/30
        /// Evento cuando finaliza el Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                tsslProcessStatus.Text = "Cancelled";
                tsslDescription.Text = "Records: " + dtData.Rows.Count.ToString();
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
                tsslDescription.Text = "Records: " + dtData.Rows.Count.ToString();
                strDetail.Clear();
                strDetail.AppendLine("Records Processed: " + dtData.Rows.Count.ToString());
                strDetail.AppendLine("Correct records = " + dtResult.Rows.Count.ToString());
                strDetail.AppendLine("Records with errors = " + cRecordsErrors.ToString());
                MessageBox.Show(strDetail.ToString());
                GetDataView(lStatistics);
                RefreshGraphicStatistical();
            }
            showRunProcess(false);
        }

        /// <summary>
        /// OK - 17/07/28
        /// Evento durante la ejecucion del Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsslProcessStatus.Text = "Working";
            tsslDescription.Text = "Records: " + e.ProgressPercentage.ToString() + "/" + dtData.Rows.Count.ToString();
            tsslStatus.Text = (((e.ProgressPercentage * 100) / dtData.Rows.Count).ToString() + " %");
            tspbProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// REVISAR - 17/07/30
        /// Evento del Subproceso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bkProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            cRecordsErrors = 0;                     // Acumulador de filas con error.
            dtResult = new DataTable("Result");     // Tabla Resultado del proceso.
            int cRow = 0;                           // Acumulador de filas procesadas.
            int cColumnId = 1;                      // Acumulador asigna un ID a cada columna.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Cantidad de columnas Tablas (Origen => Resultado)
            foreach (DataColumn column in dtData.Columns)
            {
                // Consulto si cambie de archivo?
                if (fileLog != fileLogTemp)
                {   // Nuevo
                    classItemsPropierties oProp = new classItemsPropierties(cColumnId++, column.ColumnName);
                    lItemPropierties.Add(oProp);
                    lStatistics.Add(oProp.ConvertSatatistics());
                    dtResult.Columns.Add(new DataColumn(oProp.ColumnRename));
                }
                else
                {   // Reconfigurar
                    foreach (classItemsPropierties iProp in lItemPropierties)
                    {
                        if (column.ColumnName == iProp.ColumnName)
                        {
                            dtResult.Columns.Add(new DataColumn(iProp.ColumnRename));
                            classItemsPropierties oProp = new classItemsPropierties(iProp.IdItemsPropierties, column.ColumnName, iProp.ColumnRename);
                            lItemPropierties.Add(oProp);
                            lStatistics.Add(oProp.ConvertSatatistics());
                        }
                    }

                }
            }

            // Recorrer Fila a Fila
            foreach (DataRow row in dtData.Rows)
            {
                iError = false;                     // Restablece a fila sin error.
                worker.ReportProgress(++cRow);      // Actualiza barra de Proceso.

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    dtResult = null;
                    break;
                } 
                else 
                {
                    DataRow newRow = dtResult.NewRow();
                    // Recorre Columna x columna de la fila seleccioanda.
                    for (int I = 0; I < dtData.Columns.Count; I++)
                    {
                        // Solo TEST forzado "HASTA QUE SE PUEDA ALAMCENAR LA CONFIGURACION"
                        if (I == 0)
                            lItemPropierties[I].eDataFormat = classItemsPropierties.DataFormat.Date;
                        else
                            lItemPropierties[I].eDataFormat = classItemsPropierties.DataFormat.Number;

                        switch(lItemPropierties[I].eDataFormat)
                        {
                            case classItemsPropierties.DataFormat.Text:
                                newRow[I] = row[I].ToString();
                                break;
                            case classItemsPropierties.DataFormat.Number:
                                newRow[I] = processNumber(row[I].ToString());
                                lStatistics[I].calcStatistics(processNumber(row[I].ToString()));
                                break;
                            case classItemsPropierties.DataFormat.Date:
                                newRow[I] = processDateTime(row[I].ToString()).ToShortTimeString();
                                break;
                        }
                        if (iError) 
                            break;
                    }

                    if (!iError)
                        dtResult.Rows.Add(newRow);
                    else
                        cRecordsErrors++;
                }
            }
        }

        #endregion

        // OK - 17/07/28
        #region  Metodos

        /// <summary>
        /// OK - 17/07/28
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
        /// OK - 17/07/28
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
        /// OK - 17/07/28
        /// Devuelve: Numero con decimales. 
        /// </summary>
        /// <param name="vNumber"></param>
        /// <returns></returns>
        double processNumber(string vNumber)
        {
            return Convert.ToDouble(vNumber.Replace('.', ','));
        }

        /// <summary>
        /// OK - 17/07/28
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
