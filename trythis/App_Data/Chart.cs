using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebCresij
{
    public class Chart
    {
        private readonly string connString= System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        
        public DataTable GetDashboardData()
        {
            string query = "select distinct(task) as Task, count(task) as count from user_logs group by Task";
            DataSet ds = new DataSet();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                { 
                    if(con.State!= ConnectionState.Open)
                    {
                        con.Open();
                    }
                MySqlDataAdapter dap = new MySqlDataAdapter(query, con);               
                dap.Fill(ds);                
                }               
                finally
                {
                    con.Close();
                }
            }
            return ds.Tables[0];
        }
        public int SaveTempData(string ip, List<string> vs)
        {           
            using(MySqlConnection con= new MySqlConnection(connString))
            {
                try {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveTempData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@humid",vs[2]);
                        cmd.Parameters.AddWithValue("@temp", vs[1]);
                        cmd.Parameters.AddWithValue("@pm25", vs[3]);
                        cmd.Parameters.AddWithValue("@pm10", vs[4]);
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    con.Close();
                }                
            }
            return 0;
        }
        public DataTable GetTempData()
        {
            DataSet dt = new DataSet();
            using(MySqlConnection con = new MySqlConnection(connString))
            {
                StringBuilder query = new StringBuilder();
                query.Append("select Location, Temperature , Humidity, pm25, pm10, " +
                    "cast(Date as time(0)) as Time from Temprature_Details ");
                query.Append("WHERE date >= DATE_SUB(now(), INTERVAL 4 hour) ");                
                string q = query.ToString();
                using(MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    try
                    {
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt.Tables[0];
        }
        public DataTable GetTempDataAll(string val)
        {
            DataSet dt = new DataSet();
            using (MySqlConnection con = new MySqlConnection(connString))
            {

                string q = Query1(val);
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt.Tables[0];
        }

        public string query (string value)
        {
            string query = "";
            switch (value){
                case "month":
                    query = "select convert(char(3), Date, 0) as Result, cast(AVG(Temp) as numeric(10, 2)) as temp," +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, cast(AVG(pm25) as numeric(10, 2))" +
                    " as pm25,cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData where " +
                    " DATENAME(year, date) = DATENAME(year, getdate()) group by convert(char(3), Date, 0)";
                    break;
                case "week":
                    query = "select * from fn_getdatabyweek()"; // weekname
                    break;
                case "days":
                    query = "select FORMAT(Date, 'ddd') AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10," +
                    "FORMAT(Date, 'd') from TempData " +
                    "where datepart(wk, Date) = datepart(wk, GETDATE()) group by FORMAT(Date, 'ddd') " +
                    " ,FORMAT(Date, 'd')";
                    break;
                case "date":
                    query = "select CONVERT(varchar(10), date, 101) AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData " +
                    "where datepart(MONTH, Date) = datepart(MONTH, GETDATE()) group "+
                    " by CONVERT(varchar(10), date, 101), convert(date , date)   order by convert(date , date)  desc";
                    break;
                default:
                    query = "select cast(date as time(0)) Result, temp, Humidity as humid, pm25, pm10 from TempData " +
                           "WHERE date >= DATEADD(HOUR, -6, GETDATE()) and location = '" + value + "' order by Result desc";
                    break;
            }
            return query;
        }
        public string QueryForIns (string value, string loc)
        {
            string query = "";
            switch (value)
            {
                case "month":
                    query = "select substring( monthname(date),1,3) as Result, Temperature as temp, "+
                     "Humidity as humid, pm25 as pm25, pm10 as pm10 from Temprature_details td " +
                     "join Class_Details cd on td.Location = cd.ID join Grade_Details gd on "+
                      "gd.ID = cd.GradeID join Institute_Details id on "+
                      "id.ID = gd.InsID where id.ID in (select id from institute_details " +
                            "where ins_id = '" + loc + "') and " +
                     "year(now()) = year(date) group by monthname(date)";
                    break;
                case "week":
                    query = "Select CASE "+   
                            "WHEN date_format(Date,'%d') < 8 THEN 'week 1' "+
                            "WHEN date_format(Date,'%d') < 15 THEN 'week 2' "+
                            "WHEN date_format(Date,'%d') < 22 THEN 'week 3' "+
                            "when date_format(Date,'%d') < 29 Then 'week 4' "+
                            "ELSE 'week 5' END AS weekOfMonth, "+
                            "Round(Avg(temperature), 2) as temp, Round(AVG(Humidity), 2) as humid, "+
                            "Round(avg(pm25), 2) as pm25, Round(avg(pm10), 2) as pm10 "+
                            "from temprature_details td join Class_Details cd "+
                            "on td.Location = cd.ID join Grade_Details gd on "+
                            "gd.ID = cd.GradeID join Institute_Details id on "+
                            "id.ID = gd.InsID where id.ID in (select id from institute_details " +
                            "where ins_id = '" + loc +"') and month(date) = month(now()) " +
                            "group by month(date)";
                    //query = "select * from [dbo].[WeekTempDatabyIns] ( '"+loc+"' )"; // weekname
                    break;
                case "days":
                    query = "select substring( dayname(date),1,3) AS Result,  temperature as temp, "+
                      "humidity as humid,  pm25, pm10, "+ 
                    "date(date) as Date from temprature_details td join Class_Details cd "+
                     "on td.Location = cd.ID join Grade_Details gd on "+
                     "gd.ID = cd.GradeID join Institute_Details id on "+
                      "id.ID = gd.InsID where id.ID in (select id from institute_details " +
                            "where ins_id = '" + loc + "') and " +
                     "dayofweek(date) = dayofweek(now()) group by dayofweek(date),date(date)";
                    break;
                case "date":
                    query = "select date(date) AS Result,  temperature as temp, "+
                     "Humidity as humid,  pm25, pm10 from temprature_details "+
                     "td join Class_Details cd on td.Location = cd.ID "+
                     "join Grade_Details gd on gd.ID = cd.GradeID "+
                     "join Institute_Details id on id.ID = gd.InsID "+
                     "where id.ID in (select id from institute_details " +
                      "where ins_id = '" + loc + "') and Date>= date_sub(now(), interval 10 day) " +
                     "group by date(date) order by date(date)  desc ";
                    break;
                default:
                    query = "select time(date) as Result, temperature as temp, Humidity as humid, "+
                            "pm25, pm10 from Temprature_details "+
                            "WHERE date >= date_sub(now(), interval 6 hour) and location "+
                            "in (select id from class_details where classid = '"+value+"' ) order by Result desc";
                    break;
            }
            return query;
        }

        public string QueryForgrade(string value, string loc)
        {
            string query = "";
            switch (value)
            {
                case "month":
                    query = "select substring(monthname(date), 1, 3) as Result, Temperature as temp, "+
                     "Humidity as humid, pm25 as pm25, pm10 as pm10 from Temprature_details td " +
                     "join Class_Details cd on td.Location = cd.ID join Grade_Details gd on " +
                     " gd.ID = cd.GradeID " +
                     " where cd.GradeID in (select id from grade_details " +
                            "where grade_id = '" + loc + "') and " +
                     "year(now()) = year(date) group by monthname(date)";
                    break;
                case "week":
                    query = "Select CASE " +
                            "WHEN date_format(Date,'%d') < 8 THEN 'week 1' " +
                            "WHEN date_format(Date,'%d') < 15 THEN 'week 2' " +
                            "WHEN date_format(Date,'%d') < 22 THEN 'week 3' " +
                            "when date_format(Date,'%d') < 29 Then 'week 4' " +
                            "ELSE 'week 5' END AS weekOfMonth, " +
                            "Round(Avg(temperature), 2) as temp, Round(AVG(Humidity), 2) as humid, " +
                            "Round(avg(pm25), 2) as pm25, Round(avg(pm10), 2) as pm10 " +
                            "from temprature_details td join Class_Details cd " +
                            "on td.Location = cd.ID join Grade_Details gd on " +
                             " gd.ID = cd.GradeID " +
                            " where cd.GradeID in (select id from grade_details " +
                            "where grade_id = '" + loc + "') and month(date) = month(now()) " +
                            "group by month(date)";
                    //query = "select * from [dbo].[WeekTempDatabyGrade] ( '" + loc + "' )"; // weekname
                    break;
                case "days":
                    query = "select substring( dayname(date),1,3) AS Result,  temperature as temp, " +
                      "humidity as humid,  pm25, pm10, " +
                    "date(date) as Date from temprature_details td join Class_Details cd " +
                     "on td.Location = cd.ID join Grade_Details gd on " +
                    " gd.ID = cd.GradeID " +
                            " where cd.GradeID in (select id from grade_details " +
                            "where grade_id = '" + loc + "') and "+
                    "dayofweek(date) = dayofweek(now()) group by dayofweek(date),date(date)";
                    break;
                case "date":
                    query = "select date(date) AS Result,  temperature as temp, " +
                     "Humidity as humid,  pm25, pm10 from temprature_details " +
                     "td join Class_Details cd on td.Location = cd.ID " +
                    "join Grade_Details gd on gd.ID = cd.GradeID " +
                    " where cd.GradeID in (select id from grade_details " +
                    "where grade_id = '" + loc + "') and " + "Date>= date_sub(now(), interval 10 day) " +
                    "group by date(date) order by date(date) desc ";
                    break;
                default:
                    query = "select time(date) as Result, temperature as temp, Humidity as humid, " +
                            "pm25, pm10 from Temprature_details " +
                            "WHERE date >= date_sub(now(), interval 6 hour) and location " +
                            "in (select id from class_details where classid = '" + value + "' ) order by Result desc";
                    break;
            }
            return query;
        }

        public string QueryForClass(string value, string loc)
        {
            string query = "";
            switch (value)
            {
                case "month":
                    query = "select substring( monthname(date),1,3) as Result, round( avg(temperature),2) as temp, " +
                            "round(avg(humidity), 2) as humid, round(avg(pm25), 2) as pm25, " +
                            "round(avg(pm10), 2) as pm10 from Temprature_details td join Class_Details cd " +
                            " on td.Location = cd.ID where td.location in(select id from Class_details " +
                            "where classId ='" + loc + "') and year(now()) = year(date) group by monthname(date)";
                    break;
                case "week":
                    query = "Select CASE " +
                            "WHEN date_format(Date,'%d') < 8 THEN 'week 1' " +
                            "WHEN date_format(Date,'%d') < 15 THEN 'week 2' " +
                            "WHEN date_format(Date,'%d') < 22 THEN 'week 3' " +
                            "when date_format(Date,'%d') < 29 Then 'week 4' " +
                            "ELSE 'week 5' END AS weekOfMonth, " +
                            "Round(Avg(temperature), 2) as temp, Round(AVG(Humidity), 2) as humid, " +
                            "Round(avg(pm25), 2) as pm25, Round(avg(pm10), 2) as pm10 " +
                            "from temprature_details td join Class_Details cd " +
                            "on td.Location = cd.ID where " +
                            "td.location in (select id from class_details " +
                            "where classid = '" + loc + "') and month(date) = month(now()) " +
                            "group by month(date)";
                    //query = "select * from [dbo].[WeekTempDatabyClass] ( '" + loc + "' )"; // weekname
                    break;
                case "days":
                    query = "select substring( dayname(date),1,3) AS Result,  temperature as temp, " +
                      "humidity as humid,  pm25, pm10, " +
                    "date(date) as Date from temprature_details td join Class_Details cd " +
                     "on td.Location = cd.ID" +
                     " where td.location in (select id from class_details " +
                            "where classid = '" + loc + "') and " +
                     "dayofweek(date) = dayofweek(now()) group by dayofweek(date),date(date)";
                    break;
                case "date":
                    query = "select date(date) AS Result,  temperature as temp, " +
                     "Humidity as humid,  pm25, pm10 from temprature_details " +
                     "td join Class_Details cd on td.Location = cd.ID " +                                          
                     "where id.location in (select id from class_details " +
                      "where classid = '" + loc + "') and Date>= date_sub(now(), interval 10 day) " +
                     "group by date(date) order by date(date)  desc ";
                    break;
                default:
                    query = "select time(date) as Result, temperature as temp, Humidity as humid, " +
                            "pm25, pm10 from Temprature_details "  +
                           "date >= date_sub(now(), interval 6 hour) and location in " +
                           "(select id from class_details where classid = '" + value + "' ) order by Result desc '";
                    break;
            }
            return query;
        }
        public DataTable getDatacustom(string query)
        {
            DataTable dt = new DataTable();
           
            using(MySqlConnection con = new MySqlConnection(connString)){
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using(MySqlDataAdapter sqlData = new MySqlDataAdapter(cmd))
                    {
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();

                            }
                            sqlData.Fill(dt);
                        }
                        catch(Exception ex)
                        {

                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            return dt;
        }

        public DataTable getDataforClass(string value)
        {
            DataTable dt = new DataTable();
            string q = "select cast(date as time(0)) time , temperature, Humidity as humid, pm25, pm10" +
                " from temprature_details WHERE date >= date_sub(now(), Interval 6 hour) " +
                "and location = '"+value+"' order by date desc";
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    using (MySqlDataAdapter sqlData = new MySqlDataAdapter(cmd))
                    {
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            sqlData.Fill(dt);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            return dt;
        }

        public string Query1(string value)
        {
            string type = value.Substring(0, 3);
            StringBuilder query = new StringBuilder();
            switch (type)
            {
                //case "class":
                //    query.Append("select distinct(location), cast(AVG( CAST( Temp as numeric) )"+
                //        " as decimal(10,2)) as temp, cast(AVG( CAST( Humidity as numeric) )"+
                //        " as decimal(10,2)) as humid, " +
                //        "cast(AVG(CAST(pm25 as numeric)) as decimal(10, 2)) as pm25,"+
                //        " cast(AVG(CAST(pm10 as numeric)) as decimal(10, 2)) as pm10  from TempData " +
                //    "WHERE cast(date as Date) = cast( GETDATE() as date) and "+
                //    "convert(date, GetDate()) = CONVERT(date, GETDATE()) group by Location ");                    
                //    break;
                case "All":
                    query.Append("select i.Ins_ID, temperature as temp, "+
                        "humidity as humid, pm25 as pm25, pm10 as pm10 "+
                        "from temprature_details t join Class_Details c on t.Location = c.ID "+
                        "join Grade_Details g on g.ID = c.GradeID join Institute_Details i "+
                         "on i.ID = g.InsID  group by i.id");
                    break;
                case "Ins":
                    query.Append("select distinct(g.Grade_Name), "+
                        "temperature as temp, humidity as humid, pm25 as pm25, pm10 as pm10 "+
                        "from temprature_details t join Class_Details c on t.Location = c.ID "+
                        "join Grade_Details g on g.ID = c.GradeID join Institute_Details i "+
                         "on i.ID = g.InsID WHERE "+
                         "i.ID in (select id from institute_details where ins_id = '"+value+"') group by g.Grade_Name");
                    break;
                case "Gra":
                    query.Append("select distinct(c.ClassName), "+
                       " temperature as temp, Humidity as humid, pm25 as pm25, pm10 as pm10 "+
                       " from temprature_details t join Class_Details c on t.Location = c.id "+
                       " join Grade_Details g on g.ID = c.GradeID "+
                        " WHERE g.id in (select id from Grade_details where grade_id = '"+value+"') group by c.ClassName");
                    break;
            }
            return query.ToString();
        }

        public DataTable MachineCount()
        {
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                string query = "select Count(CCIP) from CentralControl";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        public DataTable MachineCountByIns(string id)
        {
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                string query = "select Count(CCIP) from CentralControl";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        #region Configuration
        public DataTable MachineIPLoc(string gradeid)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    string query = "select ClassName, CCIP from Class_Details " +
                        " cd join CentralControl cc on cc.location=cd.ID " +
                        " where gradeID in (select id from grade_details where grade_id ='"
                        +gradeid+"') order by ClassName";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
                catch(Exception)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }
        public DataTable InsIDs()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    string query = "select InstituteID, InstituteName from Institute_Details order by InstituteName";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }
        public DataTable GradeIDs(string insid)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    string query = " select GradeID, GradeName from Grade_Details " +
                        "where InsID ='" + insid+"' order by GradeName";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public DataTable getGradeName(string gradeid)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    string query = " select  Ins_Name , Grade_Name from Grade_Details gd " +
                        "join Institute_details id on gd.InsID = id.ID " +
                        "where grade_ID = '" + gradeid + "' order by Ins_Name asc";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        #endregion
    }
}