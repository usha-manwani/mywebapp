// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 08-24-2020
//
// Last Modified By : admin
// Last Modified On : 04-19-2021
// ***********************************************************************
// <copyright file="CreateCSV.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CresijApp.DataAccess
{

    /// <summary>
    /// THis classes is to create csv file but is not called yet anywhere
    /// Keeping it for future use and update
    /// </summary>
    public class CreateCSV
    {
    }
    /// <summary>
    /// Class CSVUtlity.
    /// </summary>
    public class CSVUtlity
    {
        /// <summary>
        /// Creates the CSV file.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="strFilePath">The string file path.</param>
        public void CreateCSVFile(DataTable table, string strFilePath)
        {
            const int capacity = 50000;
            const int maxCapacity = 200000;

            //First we will write the headers.
            StringBuilder csvBuilder = new StringBuilder(capacity);
            csvBuilder.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

            // Create the CSV file and write all from StringBuilder
            using (var sw = new StreamWriter(strFilePath, false))
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (csvBuilder.Capacity >= maxCapacity)
                    {
                        sw.Write(csvBuilder.ToString());
                        csvBuilder = new StringBuilder(capacity);
                    }
                    csvBuilder.Append(string.Join(",", dr.ItemArray));
                }
                sw.Write(csvBuilder.ToString());
            }
        }
    }
}