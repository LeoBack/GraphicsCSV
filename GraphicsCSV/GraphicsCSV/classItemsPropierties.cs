﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsCSV
{
    public class classItemsPropierties
    {
        #region Atributos y Propiedades

        public enum DataFormat { Number, Text, Date }
        public int IdItemsPropierties { set; get; }
        public string ColumnName { set; get; }
        public string ColumnRename { set; get; }
        public bool ColumnBase { set; get; }
        public Color Color { set; get; }
        public bool Visible { set; get; }
        public DataFormat eDataFormat { set; get; }

        #endregion

        #region Constructores

        public classItemsPropierties()
        {
            IdItemsPropierties = 0;
            ColumnName = "Value Name";
            ColumnRename = ColumnName;
            ColumnBase = false;
            Color = RandomColor();
            Visible = true;
            eDataFormat = DataFormat.Text;
        }

        public classItemsPropierties(int vIdItemsPropierties, string vColumnName)
        {
            IdItemsPropierties = vIdItemsPropierties;
            ColumnName = vColumnName;
            ColumnRename = ColumnName;
            ColumnBase = false;
            Color = RandomColor();
            Visible = true;
            eDataFormat = DataFormat.Text;
        }

        public classItemsPropierties(int vIdItemsPropierties, string vColumnName, string vColumnRename)
        {
            IdItemsPropierties = vIdItemsPropierties;
            ColumnName = vColumnName;
            ColumnRename = vColumnRename;
            ColumnBase = false;
            Color = RandomColor();
            Visible = true;
            eDataFormat = DataFormat.Text;
        }

        public classItemsPropierties(int vIdItemsPropierties, string vColumnName, bool vColumnBase)
        {
            IdItemsPropierties = vIdItemsPropierties;
            ColumnName = vColumnName;
            ColumnRename = ColumnName;
            ColumnBase = vColumnBase;
            Color = RandomColor();
            Visible = true;
            eDataFormat = DataFormat.Text;
        }

        public classItemsPropierties(int vIdItemsPropierties, string vColumnName, DataFormat vDataFormat)
        {
            IdItemsPropierties = vIdItemsPropierties;
            ColumnName = vColumnName;
            ColumnRename = ColumnName;
            ColumnBase = false;
            Color = RandomColor();
            Visible = true;
            eDataFormat = vDataFormat;
        }

        public classItemsPropierties(int vIdItemsPropierties, string vColumnName, string vColumnRename, 
            bool vColumnBase, Color vColor, bool vChk, DataFormat vDataFormat)
        {
            IdItemsPropierties = vIdItemsPropierties;
            ColumnName = vColumnName;
            ColumnRename = vColumnRename;
            ColumnBase = vColumnBase;
            Color = vColor;
            Visible = vChk;
            eDataFormat = vDataFormat;
        }

        #endregion

        #region Metodos

        public classItemsStatistics ConvertSatatistics()
        {
            classItemsStatistics oE = new classItemsStatistics(
                IdItemsPropierties, ColumnRename, eDataFormat.ToString());
            return oE;
        }

        public Color RandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public DataTable PreLoad()
        {
            DataTable dtPreLoad = new DataTable("PreLoad");
            dtPreLoad.Columns.Add("IdItem");
            dtPreLoad.Columns.Add("ColumnName");
            dtPreLoad.Columns.Add("ColorItem");
            dtPreLoad.Columns.Add("ChkItem");
            dtPreLoad.Columns.Add("Type");

            DataRow drRow = dtPreLoad.NewRow();
            drRow[0] = 1;
            drRow[1] = "Date";
            drRow[2] = Color.Gray.Name;
            drRow[3] = true;
            drRow[4] = DataFormat.Date;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 2;
            drRow[1] = "Temperatura";
            drRow[2] = Color.Orange.Name;
            drRow[3] = true;
            drRow[4] = DataFormat.Number;
            dtPreLoad.Rows.Add(drRow);
            drRow = dtPreLoad.NewRow();
            drRow[0] = 3;
            drRow[1] = "Humedad";
            drRow[2] = Color.Blue.Name;
            drRow[3] = true;
            drRow[4] = DataFormat.Number;
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
            return "Id= " + IdItemsPropierties + ", ColumnName= " + ColumnName + ", Color= " + Color.Name + ", Cheked= " + Visible.ToString();
        }

        #endregion
    }
}
