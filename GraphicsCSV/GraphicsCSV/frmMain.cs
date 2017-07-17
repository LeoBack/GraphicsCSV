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
            // cmbFileSelected
            string[] files = Directory.GetFiles(pathLog, "*.csv", SearchOption.TopDirectoryOnly);
            if (files.Length != 0)
                cmbFileSelected.Items.AddRange(OnlyNamefile(files));
            cmbFileSelected.Items.Add("Open Directory");

            // cmbBaseTime
            cmbBaseTime.Items.AddRange(filter);

            // Grilla
            initDataView();
            GetDataView(Items.PreLoad());
        }

        #endregion

        #region Eventos

        private void cmbFileSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFileSelected.SelectedIndex == cmbFileSelected.Items.Count - 1)
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
                while (Convert.ToString(cmbFileSelected.SelectedItem) != Path.GetFileName(fileLog))
                    fileLog = files[cfile++];
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (fileLog != "")
            {
                Text = "GraphicsCSV - " + Path.GetFileName(fileLog);
                oData = oCsv.ReadFileCSV(classManager.Headers.Disable, fileLog);
                StarProcess();
            }
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            if (bkProcess.WorkerSupportsCancellation == true)
                bkProcess.CancelAsync();
        }

        private void tsmiDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strDetail.ToString());
        }

        #endregion

        #region  Metodos

        private string[] OnlyNamefile(string[] files)
        {
            string[] sP = new string[files.Length];

            for (int C = 0; C < files.Length; C++)
                sP[C] = Path.GetFileName(files[C]);

            return sP;
        }

        #endregion

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

        private void GetDataView(DataTable data)
        {
            //SourceBinding.CurrentItemChanged -= SourceBinding_CurrentItemChanged;
            //dgvList.DataSource = null;
            //SourceBinding.DataSource = data;
            //dgvList.DataSource = SourceBinding;
            //SourceBinding.CurrentItemChanged += SourceBinding_CurrentItemChanged;
            dgvList.DataSource = data;

            CellColor(data);
        }

        private void CellColor(DataTable dT)
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

        #region bkProgess

        void StarProcess()
        {
            tsslDescription.Text = "";
            if (bkProcess.IsBusy != true)
            {
                tsslProcessStatus.Text = "Loaded";
                tspbProgress.Maximum = oData.Rows.Count;
                bkProcess.RunWorkerAsync();
            }
        }

        StringBuilder strDetail = new StringBuilder();

        void bkProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                tsslProcessStatus.Text = "Cancelled";
                tspbProgress.Value = 0;
                tsslStatus.Text = "0 %";
                tsslDescription.Text = "Records: " + oData.Rows.Count.ToString();
                strDetail.Clear();
                strDetail.AppendLine("Canceled by user request.");
            }
            else if (e.Error != null)
            {
                tsslProcessStatus.Text = "Error";
                tspbProgress.Value = 0;
                tsslStatus.Text = "0 %";
                strDetail.Clear();
                strDetail.AppendLine("Error message with process.");
                strDetail.AppendLine(e.Error.Message);
            }
            else
            {
                tsslProcessStatus.Text = "Finalized";
                tsslDescription.Text = "Records: " + oData.Rows.Count.ToString();
                tspbProgress.Value = 0;
                tsslStatus.Text = "0 %";          
                strDetail.Clear();
                strDetail.AppendLine("Records Successfully Processed: " + dtResult.Rows.Count.ToString());
                strDetail.AppendLine("Date field: Correct = " + cNoError.ToString());
                strDetail.AppendLine("Date field: Mistakes = " + cError.ToString());    
            }
        }

        void bkProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsslProcessStatus.Text = "Working";
            tsslDescription.Text = "Records: " + e.ProgressPercentage.ToString() + "/" + oData.Rows.Count.ToString();
            tsslStatus.Text = (((e.ProgressPercentage * 100) / oData.Rows.Count).ToString() + " %");
            tspbProgress.Value = e.ProgressPercentage;
        }

        int cError = 0;
        int cNoError = 0;
        void bkProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            cError = 0;
            cNoError = 0;
            int cRow = 0;
            BackgroundWorker worker = sender as BackgroundWorker;

            dtResult = new DataTable("Result");

            foreach (DataColumn column in oData.Columns)
                dtResult.Columns.Add(new DataColumn(column.ColumnName));

            foreach (DataRow row in oData.Rows)
            {
                worker.ReportProgress(++cRow);

                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    dtResult = null;
                    break;
                }
                else
                {
                    // Columna Fecha
                    DateTime newDate = new DateTime();
                    if (Convert.ToString(row[0]) != "")
                    {
                        // Dia,Mes,Año-Hora,Min,Seg ( @"2017,7,6-19,07,30"; )
                        string colDateTime = Convert.ToString(row[0]).Replace('-', ','); 
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
                            cNoError++;
                        }
                        catch (IndexOutOfRangeException) { cError++; }
                        catch (FormatException) { cError++; }
                    }

                    // Columna Temperatura
                    Double colT = Convert.ToDouble(row[1]);

                    // Columna Humedad
                    Double colH = Convert.ToDouble(row[2]);

                    // Nueva Tabla
                    DataRow newRow = dtResult.NewRow();
                    newRow[0] = newDate;
                    newRow[1] = colT;
                    newRow[2] = colH;
                    dtResult.Rows.Add(newRow);
                }
            }
        }

        #endregion


    }
}
