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
                this.Text = "ArduiniLog - " + Path.GetFileName(fileLog);
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
            colName.ReadOnly = true;
            dgvList.Columns.Add(colName);

            DataGridViewTextBoxColumn colColor = new DataGridViewTextBoxColumn();
            colColor.Name = "Color";
            colColor.DataPropertyName = "ColorItem";

            colColor.ReadOnly = true;
            dgvList.Columns.Add(colColor);

            DataGridViewCheckBoxColumn colChk = new DataGridViewCheckBoxColumn();
            colChk.Name = "Mostrar";
            colChk.DataPropertyName = "ChkItem";
            colChk.ReadOnly = true;
            dgvList.Columns.Add(colChk);

            dgvList.RowHeadersVisible = false;
            dgvList.AutoGenerateColumns = false;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.BorderStyle = BorderStyle.Fixed3D;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.MultiSelect = false;
            dgvList.ReadOnly = true;
            dgvList.DataError += dgvList_DataError;
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
    }
}
