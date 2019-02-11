using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsCSV
{
    public partial class frmItemProperties : Form
    {
        // OK - 17/07/30
        #region Atributos y propiedades

        public classItemsPropierties oItems;

        #endregion

        // OK - 17/07/30
        #region Form

        /// <summary>
        /// OK - 17/07/30
        /// Constructor con parametros. 
        /// </summary>
        /// <param name="iItems"></param>
        public frmItemProperties(classItemsPropierties iItems)
        {
            InitializeComponent();
            oItems = iItems;
        }

        /// <summary>
        /// OK - 17/07/30
        /// Carga el Formulario desde el objeto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmItemProperties_Load(object sender, EventArgs e)
        {
            cmbDataFormat.DataSource = Enum.GetValues(typeof(classItemsPropierties.DataFormat));
            //
            txtName.Text = oItems.ColumnRename;
            txtColor.BackColor = oItems.Color;
            chkEnable.Checked = oItems.Visible;
            cmbDataFormat.SelectedItem = oItems.eDataFormat;
        }

        #endregion

        // OK - 17/07/30
        #region Eventos

        /// <summary>
        /// OK - 17/07/30
        /// Selecciona el color que representara el Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = txtColor.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                txtColor.BackColor = MyDialog.Color;
        }

        /// <summary>
        /// OK - 17/07/30
        /// Lee y cierra el Formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                oItems.ColumnRename = txtName.Text;
                oItems.Color = txtColor.BackColor;
                oItems.Visible = chkEnable.Checked;
                oItems.eDataFormat = (classItemsPropierties.DataFormat)cmbDataFormat.SelectedItem;
            }
            else
                MessageBox.Show("The name field is empty, the changes will not be applied. It must have a name.", "Attention");
        }

        #endregion
    }
}
