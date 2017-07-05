using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsCSV
{
    class classItems
    {
        #region Atributos y Propiedades

        private int idItem;

        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        private string nameItem;

        public string NameItem
        {
            get { return nameItem; }
            set { nameItem = value; }
        }

        private Color colorItem;

        public Color ColorItem
        {
            get { return colorItem; }
            set { colorItem = value; }
        }

        private bool chkItem;

        public bool ChkItem
        {
            get { return chkItem; }
            set { chkItem = value; }
        }

        #endregion

        #region Constructores

        public classItems()
        {
            IdItem = 0;
            NameItem = string.Empty;
            ColorItem = Color.Blue;
            ChkItem = true;
        }

        public classItems(int Id, string Name, Color Color, bool Chk)
        {
            IdItem = Id;
            NameItem = Name;
            ColorItem = Color;
            ChkItem = Chk;
        }

        #endregion

        #region Metodos

        public DataTable PreLoad()
        {
            DataTable dtPreLoad = new DataTable("PreLoad");
            dtPreLoad.Columns.Add("IdItem");
            dtPreLoad.Columns.Add("NameItem");
            dtPreLoad.Columns.Add("ColorItem");
            dtPreLoad.Columns.Add("ChkItem");

            DataRow drRow = dtPreLoad.NewRow();
            drRow[0] = 1;
            drRow[1] = "A";
            drRow[2] = Color.Blue.Name;
            drRow[3] = true;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 2;
            drRow[1] = "B";
            drRow[2] = Color.Red.Name;
            drRow[3] = true;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 3;
            drRow[1] = "C";
            drRow[2] = Color.Green.Name;
            drRow[3] = true;
            dtPreLoad.Rows.Add(drRow);

            return dtPreLoad;

            //classItems[] lDate = new classItems[3];
            //lDate[0] = new classItems(1, "A", Color.Blue, true);
            //lDate[1] = new classItems(2, "B", Color.Red, true);
            //lDate[2] = new classItems(3, "C", Color.Green, true);
            //return lDate;
        }

        public override string ToString()
        {
            return "Id= " + idItem + ", Name= " + NameItem + ", Color= " + ColorItem.Name + ", Cheked= " + ChkItem.ToString();
        }

        #endregion
    }
}
