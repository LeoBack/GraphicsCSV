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

        public enum Tdata { Number, Text, Date }

        public int IdItem { set; get; }         // ID
        public string NameItem { set; get; }    // Nombre
        public Color ColorItem { set; get; }    // Color
        public bool ChkItem { set; get; }       // Mostrar o Ocultar
        public Tdata tData { set; get; }  // Tipo de Dato

        #endregion

        #region Constructores

        public classItems()
        {
            IdItem = 0;
            NameItem = string.Empty;
            ColorItem = Color.Blue;
            ChkItem = true;
            tData = Tdata.Text;
        }

        public classItems(int Id, string Name, Color Color, bool Chk, Tdata Type)
        {
            IdItem = Id;
            NameItem = Name;
            ColorItem = Color;
            ChkItem = Chk;
            tData = Type;
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
            dtPreLoad.Columns.Add("Type");

            DataRow drRow = dtPreLoad.NewRow();
            drRow[0] = 1;
            drRow[1] = "Date";
            drRow[2] = Color.Gray.Name;
            drRow[3] = true;
            drRow[4] = Tdata.Date;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 2;
            drRow[1] = "Temperatura";
            drRow[2] = Color.Orange.Name;
            drRow[3] = true;
            drRow[4] = Tdata.Number;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 3;
            drRow[1] = "Humedad";
            drRow[2] = Color.Blue.Name;
            drRow[3] = true;
            drRow[4] = Tdata.Number;
            dtPreLoad.Rows.Add(drRow);

            return dtPreLoad;

            //classItems[] lDate = new classItems[3];
            //lDate[0] = new classItems(1, "A", Color.Blue, true, DataType.Text);
            //lDate[1] = new classItems(2, "B", Color.Red, true, DataType.Text);
            //lDate[2] = new classItems(3, "C", Color.Green, true, DataType.Text);
            //return lDate;
        }

        public override string ToString()
        {
            return "Id= " + IdItem + ", Name= " + NameItem + ", Color= " + ColorItem.Name + ", Cheked= " + ChkItem.ToString();
        }

        #endregion
    }
}
