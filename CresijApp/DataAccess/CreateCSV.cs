using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CresijApp.DataAccess
{
    public class CreateCSV
    {
    }
    public  class CSVUtlity
    {
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