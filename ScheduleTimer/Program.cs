using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;

namespace ScheduleTimer
{
    class Program
    {
        private static IHubProxy proxy;
        private static HubConnection con;
        static void Main(string[] args)
        {
            ConnectToHub();
            var intervalTime = new Timer();
            //Do IT HERE
            intervalTime.Elapsed += new ElapsedEventHandler(intervalTime_Elapsed);
            intervalTime.Interval = 120000;
            intervalTime.Enabled = true;           
            Console.WriteLine(intervalTime.Enabled.ToString());
            Console.ReadLine();            
        }
        
        static void intervalTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer1 timer1 = new Timer1();
            DataTable dt = timer1.StartTime();
            dt.Print();
            
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    try
                    {
                        if (con.State != ConnectionState.Connected)
                        {
                            Console.WriteLine("connecting to server");
                            con.Start().Wait();
                            Console.WriteLine("connected");
                        }
                        proxy.Invoke("SendControlKeys", row[0].ToString(), "8B B9 00 04 02 04 18 22");
                        Console.WriteLine("timer called hub");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("connecting to server");
                        con.Start().Wait();
                        Console.WriteLine("connected");
                    }
                }
            }
                       
            Console.WriteLine("New event fired");
        }
        public static void ConnectToHub()
        {
            try
            {
                con = new HubConnection("http://localhost:17263/");
                proxy = con.CreateHubProxy("myHub");
                Console.WriteLine("connecting to server");               
                con.Start().Wait();
                Console.WriteLine("connected");
            }
            catch (Exception)
            {
                con.StateChanged += Con_StateChanged;
            }
        }
        private static void Con_StateChanged(StateChange obj)
        {
            if (obj.OldState == ConnectionState.Disconnected)
            {
                Console.WriteLine("State changed inside");
                var current = DateTime.Now.TimeOfDay;                
                Console.WriteLine("State changed inside done");
            }
            else
            {
                Console.WriteLine("State changed else inside");                
            }
        }

        private static void Con_Closed()
        {
            Console.WriteLine("connection closed");
            con.Start().Wait();
        }
    }

    public static class PrintDataExtensions
    {
        #region Print Columns
        public static void PrintColumns(this DataTable dataTable, params string[] columnNames)
        {
            PrintColumns(dataTable.TableName, GetColumns(dataTable, columnNames));
        }
        private static void PrintColumns(string name, DataColumn[] columns)
        {
            string columnName = "Column Name";
            string dataType = "Data Type";
            string nullable = "Nullable";
            string dataMember = "Data Member";

            int length0 = 0;
            int length1 = columnName.Length;
            int length2 = dataType.Length;
            int length3 = nullable.Length;
            int length4 = dataMember.Length;

            if (columns.Length > 0)
            {
                int maxLength = columns.Select(c => c.Ordinal).Max().ToString().Length;
                if (length0 < maxLength)
                    length0 = maxLength;

                maxLength = columns.Select(c => c.ColumnName.Length).Max();
                if (length1 < maxLength)
                    length1 = maxLength;

                maxLength = columns.Select(c => c.DataType.ToString().Length).Max();
                if (length2 < maxLength)
                    length2 = maxLength;

                maxLength = columns.Select(c => GetDataMemberType(c).Length + 1 + c.ColumnName.Length).Max();
                if (length4 < maxLength)
                    length4 = maxLength;
            }

            string horizontal0 = new String(Horizontal_Bar, length0 + 2);
            string horizontal1 = new String(Horizontal_Bar, length1 + 2);
            string horizontal2 = new String(Horizontal_Bar, length2 + 2);
            string horizontal3 = new String(Horizontal_Bar, length3 + 2);
            string horizontal4 = new String(Horizontal_Bar, length4 + 2);

            if (string.IsNullOrEmpty(name) == false)
                Console.WriteLine("{0}:", name);

            Console.WriteLine("{5}{0}{6}{1}{6}{2}{6}{3}{6}{4}{7}", horizontal0, horizontal1, horizontal2, horizontal3, horizontal4, Top_Left, Top_Center, Top_Right);

            string format1 = string.Format("{{5}} {{0,-{0}}} {{5}} {{1,-{1}}} {{5}} {{2,-{2}}} {{5}} {{3,-{3}}} {{5}} {{4,-{4}}} {{5}}", length0, length1, length2, length3, length4);
            Console.WriteLine(format1, string.Empty, columnName, dataType, nullable, dataMember, Verticl_Bar);

            Console.WriteLine("{5}{0}{6}{1}{6}{2}{6}{3}{6}{4}{7}", horizontal0, horizontal1, horizontal2, horizontal3, horizontal4, Middle_Left, Middle_Center, Middle_Right);

            foreach (DataColumn column in columns)
            {
                string dataMemberType = GetDataMemberType(column);
                string format2 = string.Format("{{5}} {{0,{0}}} {{5}} {{1,-{1}}} {{5}} {{2,-{2}}} {{5}} {{3,-{3}}} {{5}} {{4}} {{1}} {{5,{4}}}", length0, length1, length2, length3, length4 - dataMemberType.Length - column.ColumnName.Length);
                Console.WriteLine(format2, column.Ordinal, column.ColumnName, column.DataType, column.AllowDBNull, dataMemberType, Verticl_Bar);
            }

            Console.WriteLine("{5}{0}{6}{1}{6}{2}{6}{3}{6}{4}{7}", horizontal0, horizontal1, horizontal2, horizontal3, horizontal4, Bottom_Left, Bottom_Center, Bottom_Right);

            Console.WriteLine();
        }
        private static string GetDataMemberType(DataColumn column)
        {
            if (column.DataType == typeof(string))
                return "string";
            else if (column.DataType == typeof(int))
                return "int" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(short))
                return "short" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(long))
                return "long" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(double))
                return "double" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(decimal))
                return "decimal" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(float))
                return "float" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(char))
                return "char" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(bool))
                return "bool" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(uint))
                return "uint" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(ushort))
                return "ushort" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(ulong))
                return "ulong" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(byte))
                return "byte" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(sbyte))
                return "sbyte" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(DateTime))
                return "DateTime" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(TimeSpan))
                return "TimeSpan" + (column.AllowDBNull ? "?" : string.Empty);
            else if (column.DataType == typeof(Type))
                return "Type";
            else if (column.DataType == typeof(byte[]))
                return "byte[]";
            else
                return column.DataType.ToString() + (column.AllowDBNull && column.DataType.IsClass == false ? "?" : string.Empty);
        }
        #endregion

        #region Print DataTable
        public static void Print(this DataTable dataTable, params string[] columnNames)
        {
            Print(dataTable, false, 0, null, columnNames);
        }
        public static void Print(this DataTable dataTable, bool rowOrdinals, params string[] columnNames)
        {
            Print(dataTable, rowOrdinals, 0, null, columnNames);
        }
        public static void Print(this DataTable dataTable, int top, params string[] columnNames)
        {
            Print(dataTable, false, top, null, columnNames);
        }
        public static void Print(this DataTable dataTable, bool rowOrdinals, int top, params string[] columnNames)
        {
            Print(dataTable, rowOrdinals, top, null, columnNames);
        }
        public static void Print(this DataTable dataTable, ValueToStringHandler toString, params string[] columnNames)
        {
            Print(dataTable, false, 0, toString, columnNames);
        }
        public static void Print(this DataTable dataTable, bool rowOrdinals, ValueToStringHandler toString, params string[] columnNames)
        {
            Print(dataTable, rowOrdinals, 0, toString, columnNames);
        }
        public static void Print(this DataTable dataTable, int top, ValueToStringHandler toString, params string[] columnNames)
        {
            Print(dataTable, false, top, toString, columnNames);
        }
        public static void Print(this DataTable dataTable, bool rowOrdinals = false, int top = 0, ValueToStringHandler toString = null, params string[] columnNames)
        {
            PrintRows(dataTable, dataTable.AsEnumerable(), rowOrdinals, top, toString, columnNames);
        }
        #endregion

        #region Print Helper Methods
        public delegate string ValueToStringHandler(object obj, DataRow row, DataColumn column);
        private static void PrintRows(DataTable dataTable, IEnumerable<DataRow> dataRows, bool rowOrdinals, int top, ValueToStringHandler toString, string[] columnNames, string ordinalColumnName = null)
        {
            if (dataTable == null && dataRows.Count() == 0)
            {
                Console.WriteLine("No rows were selected");
                Console.WriteLine();
                return;
            }

            if (dataTable != null && string.IsNullOrEmpty(dataTable.TableName) == false)
                Console.WriteLine("{0}:", dataTable.TableName);

            DataColumn[] columns = GetColumns(dataTable, columnNames, ordinalColumnName);
            if (columns.Length == 0)
            {
                Console.WriteLine("No columns were selected");
                Console.WriteLine();
                return;
            }

            if (top > 0)
                dataRows = dataRows.Take(top);

            int[] lengths = columns.Select(c => c.ColumnName.Length).ToArray();
            foreach (DataRow row in dataRows)
                CalculateLengths(row, columns, lengths, toString);

            int rowOrdinalsLength = 0;
            if (rowOrdinals)
            {
                if (dataRows.Count() > 0)
                {
                    int maxRowOrdinal = 0;
                    if (string.IsNullOrEmpty(ordinalColumnName))
                        maxRowOrdinal = dataRows.Select(row => row.Table.Rows.IndexOf(row)).Max();
                    else
                        maxRowOrdinal = dataRows.Select(row => (int)row[ordinalColumnName]).Max();

                    if (maxRowOrdinal > -1)
                        rowOrdinalsLength = maxRowOrdinal.ToString().Length;
                }
            }

            string header = Top_Left.ToString();
            string separator = Middle_Left.ToString();
            string footer = Bottom_Left.ToString();
            string formatHeaders = Verticl_Bar.ToString();
            string format = Verticl_Bar.ToString();

            if (rowOrdinals)
            {
                string horizontal = new String(Horizontal_Bar, rowOrdinalsLength + 2);
                header += horizontal + Top_Center;
                separator += horizontal + Middle_Center;
                footer += horizontal + Bottom_Center;
                formatHeaders += string.Format(" {{0,-{0}}} {1}", rowOrdinalsLength, Verticl_Bar);
                format += string.Format(" {{0,{0}}} {1}", rowOrdinalsLength, Verticl_Bar);
            }

            int k = 0;
            for (; k < columns.Length - 1; k++)
            {
                string horizontal = new String(Horizontal_Bar, lengths[k] + 2);
                header += horizontal + Top_Center;
                separator += horizontal + Middle_Center;
                footer += horizontal + Bottom_Center;

                string cellFormat = string.Format(" {{{0},-{1}}} {2}", k + 1, lengths[k], Verticl_Bar);
                formatHeaders += cellFormat;
                format += cellFormat;
            }

            k = columns.Length - 1;
            if (k >= 0)
            {
                string horizontal = new string(Horizontal_Bar, lengths[k] + 2);
                header += horizontal + Top_Right;
                separator += horizontal + Middle_Right;
                footer += horizontal + Bottom_Right;

                string cellFormat = string.Format(" {{{0},-{1}}} {2}", k + 1, lengths[k], Verticl_Bar);
                formatHeaders += cellFormat;
                format += cellFormat;
            }

            object[] objects = new object[columns.Length + 1];

            Console.WriteLine(header);

            objects[0] = string.Empty;
            for (int i = 0; i < columns.Length; i++)
                objects[i + 1] = columns[i];
            Console.WriteLine(formatHeaders, objects);

            Console.WriteLine(separator);

            foreach (DataRow row in dataRows)
            {
                if (rowOrdinals)
                {
                    int ordinal = 0;
                    if (string.IsNullOrEmpty(ordinalColumnName))
                        ordinal = row.Table.Rows.IndexOf(row);
                    else
                        ordinal = (int)row[ordinalColumnName];
                    objects[0] = (ordinal > -1 ? ordinal : (int?)null);
                }

                for (int i = 0; i < columns.Length; i++)
                {
                    object obj = row[columns[i]];

                    string str = null;
                    if (toString != null)
                    {
                        str = toString(obj, row, columns[i]);
                        if (str == null)
                            str = "null";
                    }
                    else
                    {
                        str = string.Format("{0}", (obj == DBNull.Value || obj == null ? "null" : obj));
                    }

                    objects[i + 1] = str;
                }

                Console.WriteLine(format, objects);
            }

            Console.WriteLine(footer);

            Console.WriteLine();
        }        
        private static DataColumn[] GetColumns(DataTable dataTable, string[] columnNames, string ordinalColumnName = null)
        {
            if (columnNames != null && columnNames.Length > 0)
                return columnNames.Join(dataTable.Columns.Cast<DataColumn>(), n => n, c => c.ColumnName, (n, c) => c, StringComparer.CurrentCultureIgnoreCase).Where(c => string.IsNullOrEmpty(ordinalColumnName) || c.ColumnName != ordinalColumnName).ToArray();
            else
                return dataTable.Columns.Cast<DataColumn>().Where(c => string.IsNullOrEmpty(ordinalColumnName) || c.ColumnName != ordinalColumnName).ToArray();
        }
        private static void CalculateLengths(DataRow row, DataColumn[] columns, int[] lengths, ValueToStringHandler toString)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                object obj = row[columns[i]];

                string str = null;
                if (toString != null)
                {
                    str = toString(obj, row, columns[i]);
                    if (str == null)
                        str = "null";
                }
                else
                {
                    str = string.Format("{0}", (obj == DBNull.Value || obj == null ? "null" : obj));
                }

                if (lengths[i] < str.Length)
                    lengths[i] = str.Length;
            }
        }
        #endregion

        #region Border
        private const char ASCII_MINUS = '-';
        private const char ASCII_VERTICL_BAR = '|';
        private const char ASCII_PLUS = '+';
        private const char EXTENDED_ASCII_HORIZONTAL_BAR = '─';
        private const char EXTENDED_ASCII_VERTICL_BAR = '│';
        private const char EXTENDED_ASCII_TOP_LEFT = '┌';
        private const char EXTENDED_ASCII_TOP_CENTER = '┬';
        private const char EXTENDED_ASCII_TOP_RIGHT = '┐';
        private const char EXTENDED_ASCII_MIDDLE_LEFT = '├';
        private const char EXTENDED_ASCII_MIDDLE_CENTER = '┼';
        private const char EXTENDED_ASCII_MIDDLE_RIGHT = '┤';
        private const char EXTENDED_ASCII_BOTTOM_LEFT = '└';
        private const char EXTENDED_ASCII_BOTTOM_CENTER = '┴';
        private const char EXTENDED_ASCII_BOTTOM_RIGHT = '┘';
        private static char Horizontal_Bar;
        private static char Verticl_Bar;
        private static char Top_Left;
        private static char Top_Center;
        private static char Top_Right;
        private static char Middle_Left;
        private static char Middle_Center;
        private static char Middle_Right;
        private static char Bottom_Left;
        private static char Bottom_Center;
        private static char Bottom_Right;

        public static void ClearBorder()
        {
            Horizontal_Bar = ' ';
            Verticl_Bar = ' ';
            Top_Left = ' ';
            Top_Center = ' ';
            Top_Right = ' ';
            Middle_Left = ' ';
            Middle_Center = ' ';
            Middle_Right = ' ';
            Bottom_Left = ' ';
            Bottom_Center = ' ';
            Bottom_Right = ' ';
        }
        public static void ASCIIBorder()
        {
            Horizontal_Bar = ASCII_MINUS;
            Verticl_Bar = ASCII_VERTICL_BAR;
            Top_Left = ASCII_PLUS;
            Top_Center = ASCII_PLUS;
            Top_Right = ASCII_PLUS;
            Middle_Left = ASCII_PLUS;
            Middle_Center = ASCII_PLUS;
            Middle_Right = ASCII_PLUS;
            Bottom_Left = ASCII_PLUS;
            Bottom_Center = ASCII_PLUS;
            Bottom_Right = ASCII_PLUS;
        }
        public static void ExtendedASCIIBorder()
        {
            Horizontal_Bar = EXTENDED_ASCII_HORIZONTAL_BAR;
            Verticl_Bar = EXTENDED_ASCII_VERTICL_BAR;
            Top_Left = EXTENDED_ASCII_TOP_LEFT;
            Top_Center = EXTENDED_ASCII_TOP_CENTER;
            Top_Right = EXTENDED_ASCII_TOP_RIGHT;
            Middle_Left = EXTENDED_ASCII_MIDDLE_LEFT;
            Middle_Center = EXTENDED_ASCII_MIDDLE_CENTER;
            Middle_Right = EXTENDED_ASCII_MIDDLE_RIGHT;
            Bottom_Left = EXTENDED_ASCII_BOTTOM_LEFT;
            Bottom_Center = EXTENDED_ASCII_BOTTOM_CENTER;
            Bottom_Right = EXTENDED_ASCII_BOTTOM_RIGHT;
        }
        static PrintDataExtensions()
        {
            ExtendedASCIIBorder();
        }
        #endregion
    }
}
