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
        DataTable oData = new DataTable("Logs");
        classItems Items = new classItems();

        string pathLog = Path.Combine(Application.StartupPath, "Logs");
        string fileLog = string.Empty;
        string[] filter = { "15 minutos", "30 minutos", "60 minutos" };

        #endregion

        #region Frm

        public frmMain()
        {
            InitializeComponent();

            if (!Directory.Exists(pathLog))
                Directory.CreateDirectory(pathLog);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // cmbFileSelected
            string[] files = Directory.GetFiles(pathLog, "*.csv", SearchOption.TopDirectoryOnly);
            if (files.Length != 0)
                cmbFileSelected.Items.AddRange(OnlyNamefile(files));
            cmbFileSelected.Items.Add("Abrir Directorio");

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
                oData = oCsv.ReadFileCSV(classManager.Headers.Disable, fileLog);
                tsslStatus.Text = "Cantidad de registros en el Log: " + Convert.ToString(oData.Rows.Count);
                this.Text = "GraphicsCSV - " + Path.GetFileName(fileLog);
                //
                Process(oData);
            }
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

        private void Process(DataTable dt)
        {
            /*
             * 1 - Definir el rango de fechas a promediar (x Hora, x cada 30min, etc)
             * 2 - Construir la nueva tabla para confeccionar el grafico.
             */
            int cError = 0;
            int cNoError = 0;

            DataTable dtResult = new DataTable("Result");

            foreach (DataColumn column in dt.Columns)
                dtResult.Columns.Add(new DataColumn(column.ColumnName));

            foreach (DataRow row in dt.Rows)
            {
                // Columna Fecha
                DateTime newDate = new DateTime();
                if (Convert.ToString(row[0]) != "")
                {
                    string colDateTime = Convert.ToString(row[0]).Replace('-', ','); // Dia,Mes,Año-Hora,Min,Seg
                    string[] nDateTime = colDateTime.Split(',');             // @"2017,7,6-19,07,30";
                    
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

                DataRow newRow = dtResult.NewRow();
                newRow[0] = newDate;
                newRow[1] = colT;
                newRow[2] = colH;
                dtResult.Rows.Add(newRow);
            }

            MessageBox.Show("Registros Procesados con Exito: " + dtResult.Rows.Count.ToString()  
                + "\nCampo fecha:\n\tCorrectos= " + cNoError.ToString() +"\n\tErrores = " + cError.ToString());
        }
    }
}
