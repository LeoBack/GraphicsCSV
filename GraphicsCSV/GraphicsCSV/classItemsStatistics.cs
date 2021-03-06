﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsCSV
{
    public class classItemsStatistics
    {
        #region Atributos y Propiedades

        public int IdStatistics { set; get; }
        public string ColumnName { set; get; }
        public string DataFormat { set; get; }
        public double Min { set; get; }
        public double Max { set; get; }
        public double Avg { set; get; }

        private double sAvg = 0;

        #endregion

        #region Constructores

        public classItemsStatistics()
        {
            IdStatistics = 0;
            ColumnName = string.Empty;
            DataFormat = string.Empty;
            Min = 0;
            Max = 0;
            Avg = 0;
        }

        public classItemsStatistics(int vIdStatistics, string vColumnName, string vDataFormat)
        {
            IdStatistics = vIdStatistics;
            ColumnName = vColumnName;
            DataFormat = vDataFormat;
            Min = 0;
            Max = 0;
            Avg = 0;
        }

        #endregion

        #region Metodos

        public void calcStatistics(double nValue)
        {
            sAvg = +nValue;
            Avg = Math.Round(sAvg, 2);
            Min = Math.Min(Min, nValue);
            Max = Math.Max(Max, nValue);
        }

        #endregion
    }
}
