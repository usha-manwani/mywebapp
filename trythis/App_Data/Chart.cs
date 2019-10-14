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
            string query = "select distinct(task) as Task, count(task) as count from userlogs group by Task";
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
                query.Append("select Location, Temp , Humidity, pm25, pm10, " +
                    "cast(Date as time(0)) as Time from TempData ");
                query.Append("WHERE date >= DATEADD(HOUR, -4, GETDATE()) ");                
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
                    query = "select convert(char(3), Date, 0) as Result, cast(AVG(Temp) as numeric(10, 2)) as temp," +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, cast(AVG(pm25) as numeric(10, 2)) " +
                    " as pm25,cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData td join Class_Details cd "+
                     " on td.Location = cd.ClassID join Grade_Details gd on "+
                     " gd.GradeID = cd.GradeID join Institute_Details id on "+
                     " id.InstituteID = gd.InsID where id.InstituteID = '"+loc+"' and " +
                    " DATENAME(year, date) = DATENAME(year, getdate()) group by convert(char(3), Date, 0)";
                    break;
                case "week":
                    query = "select * from [dbo].[WeekTempDatabyIns] ( '"+loc+"' )"; // weekname
                    break;
                case "days":
                    query = "select FORMAT(Date, 'ddd') AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10, " +
                    "FORMAT(Date, 'd') as Date from TempData td join Class_Details cd"+
                    " on td.Location = cd.ClassID join Grade_Details gd on "+
                    " gd.GradeID = cd.GradeID join Institute_Details id on "+
                     " id.InstituteID = gd.InsID where id.InstituteID = '"+loc+"'and" +
                    " datepart(wk, Date) = datepart(wk, GETDATE()) group by FORMAT(Date, 'ddd') " +
                    " ,FORMAT(Date, 'd')";
                    break;
                case "date":
                    query = "select CONVERT(varchar(10), date, 101) AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData "+ 
                    " td join Class_Details cd on td.Location = cd.ClassID "+
                    " join Grade_Details gd on gd.GradeID = cd.GradeID "+
                    " join Institute_Details id on id.InstituteID = gd.InsID "+
                    " where id.InstituteID = '"+loc+"' and Date>= DATEADD(day, -10, GETDATE()) group " +
                    " by CONVERT(varchar(10), date, 101), convert(date , date) "+
                    " order by convert(date , date)  desc";
                    break;
                default:
                    query = "select cast(date as time(0)) Result, temp, Humidity as humid, pm25, pm10 from TempData " +
                           "WHERE date >= DATEADD(HOUR, -6, GETDATE()) and location = '" + value + "' order by Result desc";
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
                    query = "select convert(char(3), Date, 0) as Result, cast(AVG(Temp) as numeric(10, 2)) as temp," +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, cast(AVG(pm25) as numeric(10, 2)) " +
                    " as pm25,cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData td join Class_Details cd " +
                     " on td.Location = cd.ClassID join Grade_Details gd on " +
                     " gd.GradeID = cd.GradeID " +
                     " where gd.GradeID = '" + loc + "' and " +
                    " DATENAME(year, date) = DATENAME(year, getdate()) group by convert(char(3), Date, 0)";
                    break;
                case "week":
                    query = "select * from [dbo].[WeekTempDatabyGrade] ( '" + loc + "' )"; // weekname
                    break;
                case "days":
                    query = "select FORMAT(Date, 'ddd') AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10, " +
                    "FORMAT(Date, 'd') as Date from TempData td join Class_Details cd" +
                    " on td.Location = cd.ClassID join Grade_Details gd on " +
                     " gd.GradeID = cd.GradeID " +
                     " where gd.GradeID = '" + loc + "' and " +
                    " datepart(wk, Date) = datepart(wk, GETDATE()) group by FORMAT(Date, 'ddd') " +
                    " ,FORMAT(Date, 'd')";
                    break;
                case "date":
                    query = "select CONVERT(varchar(10), date, 101) AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData " +
                    " td join Class_Details cd on td.Location = cd.ClassID " +
                    " join Grade_Details gd on gd.GradeID = cd.GradeID " +
                     " where gd.GradeID = '" + loc + "' and Date>= DATEADD(day, -10, GETDATE()) group " +
                    " by CONVERT(varchar(10), date, 101), convert(date , date) " +
                    " order by convert(date , date)  desc";
                    break;
                default:
                    query = "select cast(date as time(0)) Result, temp, Humidity as humid, pm25, pm10 from TempData " +
                           "WHERE date >= DATEADD(HOUR, -6, GETDATE()) and location = '" + value + "' order by Result desc";
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
                    query = "select convert(char(3), Date, 0) as Result, cast(AVG(Temp) as numeric(10, 2)) as temp," +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, cast(AVG(pm25) as numeric(10, 2)) " +
                    " as pm25,cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData td join Class_Details cd " +
                     " on td.Location = cd.ClassID  "+
                     " where cd.ClassID = '" + loc + "' and " +
                    " DATENAME(year, date) = DATENAME(year, getdate()) group by convert(char(3), Date, 0)";
                    break;
                case "week":
                    query = "select * from [dbo].[WeekTempDatabyClass] ( '" + loc + "' )"; // weekname
                    break;
                case "days":
                    query = "select FORMAT(Date, 'ddd') AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10, " +
                    "FORMAT(Date, 'd') as Date from TempData td join Class_Details cd" +
                    " on td.Location = cd.ClassID " +
                     " where cd.ClassID = '" + loc + "' and " +
                    " datepart(wk, Date) = datepart(wk, GETDATE()) group by FORMAT(Date, 'ddd') " +
                    " ,FORMAT(Date, 'd')";
                    break;
                case "date":
                    query = "select CONVERT(varchar(10), date, 101) AS Result, cast(AVG(Temp) as numeric(10, 2)) as temp, " +
                    " cast(AVG(Humidity) as numeric(10, 2)) as humid, " +
                    "cast(AVG(pm25) as numeric(10, 2)) as pm25, " +
                    "cast(AVG(pm10) as numeric(10, 2)) as pm10 from TempData " +
                    " td join Class_Details cd on td.Location = cd.ClassID " +
                     " where cd.ClassID = '" + loc + "' and Date>= DATEADD(day, -10, GETDATE()) group " +
                    " by CONVERT(varchar(10), date, 101), convert(date , date) " +
                    " order by convert(date , date)  desc";
                    break;
                default:
                    query = "select cast(date as time(0)) Result, temp, Humidity as humid, pm25, pm10 from TempData " +
                           "WHERE date >= DATEADD(HOUR, -6, GETDATE()) and location = '" + value + "' order by Result desc";
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
            string q = "select cast(date as time(0)) time , temp, Humidity as humid, pm25, pm10 from TempData " +
                            "WHERE date >= DATEADD(HOUR, -6, GETDATE()) and location = '"+value+"' order by date desc";
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
                    query.Append("select InsID, cast(AVG(CAST(Temp as numeric)) as decimal(10, 2)) as temp, "+
                        "cast(AVG(CAST(Humidity as numeric)) as decimal(10, 2)) as humid, "+
                        "cast(AVG(CAST(pm25 as numeric)) as decimal(10, 2)) as pm25, " +
                         "cast(AVG(CAST(pm10 as numeric)) as decimal(10, 2)) as pm10 " +
                        "from TempData t join Class_Details c on t.Location = c.ClassID " +
                        "join Grade_Details g on g.GradeID = c.GradeID join Institute_Details i " +
                         "on i.InstituteID = g.InsID  group by InsID");
                    break;
                case "Ins":
                    query.Append("select distinct(g.GradeName), " +
                        "cast(AVG(CAST(Temp as numeric)) as decimal(10, 2)) as temp,"+
                        " cast(AVG(CAST(Humidity as numeric)) as decimal(10, 2)) as humid, "+
                        "cast(AVG(CAST(pm25 as numeric)) as decimal(10, 2)) as pm25,"+
                        " cast(AVG(CAST(pm10 as numeric)) as decimal(10, 2)) as pm10 "+
                        "from TempData t join Class_Details c on t.Location = c.ClassID "+
                        "join Grade_Details g on g.GradeID = c.GradeID join Institute_Details i"+
                        " on i.InstituteID = g.InsID WHERE "+     
                        " i.InstituteID='"+value+"' group by g.GradeName");
                    break;
                case "Gra":
                    query.Append("select distinct(c.ClassName), " +
                        "cast(AVG(CAST(Temp as numeric)) as decimal(10, 2)) as temp," +
                        " cast(AVG(CAST(Humidity as numeric)) as decimal(10, 2)) as humid, " +
                        "cast(AVG(CAST(pm25 as numeric)) as decimal(10, 2)) as pm25," +
                        " cast(AVG(CAST(pm10 as numeric)) as decimal(10, 2)) as pm10 " +
                        "from TempData t join Class_Details c on t.Location = c.ClassID " +
                        "join Grade_Details g on g.GradeID = c.GradeID " +
                        " WHERE "+
                        " g.GradeID='" + value + "' group by c.ClassName");
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
                    string query = "select ClassName, CCIP from Class_Details" +
                        " cd join CentralControl cc on cc.location=cd.ClassID" +
                        " where gradeID='" +gradeid+"' order by ClassName";

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
                    string query = " select  InstituteName , GradeName from Grade_Details gd " +
                        "join Institute_details id on gd.InsID = id.InstituteID " +
                        "where gradeID = '" + gradeid + "' order by InstituteName asc";
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