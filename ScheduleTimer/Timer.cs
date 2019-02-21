using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ScheduleTimer
{
    class Timer1
    {
        string constr = "Integrated Security=SSPI;Persist Security Info=False;" +
            "Data Source=WIN-OTVR1M4I567\\SQLEXPRESS;Initial Catalog=CresijCam";
        public DataTable StartTime()
        {
            DataTable dt = new DataTable();
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;            
            min = min + 1;
            if (min >= 60)
            {
                hour = hour + 1;
                if (min == 60)
                {
                    min = 00;
                }
                else
                    min = 01;
            }
            var starttime = hour.ToString("D2") + ":" + min.ToString();
            Console.WriteLine("Start Time "+starttime);
            CultureInfo us = new CultureInfo("en-US");
            string day1= us.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            Console.WriteLine(day1.Substring(0, 3));
            var day = DateTime.Now.ToString("ddd");
            string query = "select CCIP, ClassID, StartTime from Schedule where timer='true' and StartTime" +
                " <='"+starttime+"' and StartTime>='"+DateTime.Now.ToString("HH:mm")+
                "' and "+day1.Substring(0,3)+" not in('') order by StartTime";
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            try
            {
                if (con.State!= ConnectionState.Open)
                {
                    con.Open();
                }
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}
