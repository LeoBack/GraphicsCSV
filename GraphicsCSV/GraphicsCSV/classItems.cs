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

        public int IdItem { set; get; }
        public string NameItem { set; get; }
        public Color ColorItem { set; get; }
        public bool ChkItem { set; get; }

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
            return "Id= " + IdItem + ", Name= " + NameItem + ", Color= " + ColorItem.Name + ", Cheked= " + ChkItem.ToString();
        }

        #endregion
    }
}
