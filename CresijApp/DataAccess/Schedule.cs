using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    public class Schedule
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        readonly string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        
        //public DataTable GetSchedule()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (MySqlConnection con = new MySqlConnection(constr))
        //        {
        //            string query = "select concat_ws(', ',teacherName, Coursename, classname, weekstart, weekEnd, dayno, section)" +
        //                           " as details , dayno, classname from scheduletable";
        //            using (MySqlCommand cmd = new MySqlCommand(query, con))
        //            {
        //                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
        //                dataAdapter.Fill(dt);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }

        //    return dt;
        //}
        public DataTable GetCourse()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    string query = "select  section,className, coursename, id from schedule";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public DataTable GetSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_GetSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        // Schedule for transfer request with row ids
        public DataTable GetScheduleForTransfer(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand("GetScheduleForTransfer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@build", name);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetCourseDetails(string[] name)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    string query = "select teachername, coursename, sc.Classname," +
                        " weekstart,weekend, dayno, section, teachingbuilding from schedule sc " +
                        "join classdetails cd on sc.classname =cd.classname "+                        
                        "where sc.classname = '" + name[0] + "' and sc.coursename = '" + name[1] + "' ";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;

        }

        public DataTable GetCourseDetailsForTransfer(string[] name)
        {
            DataTable dt = new DataTable();
            string query = "";
            try
            {
                    query = "select teachername, coursename, sc.Classname," +
                        " weekstart,weekend, dayno, section, cd.teachingbuilding, sm.startdate from schedule sc join classdetails cd on sc.ClassName = cd.classname " +
                        " join semesterinfo sm on sc.sem = sm.semno where sc.id = " + name[0] ;
                
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;

        }

        public DataTable GetFreeWeek()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select classname, weekstart, weekend from schedule";
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using(MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public int SaveTransferSchedule(string[] name)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {                
                    using (MySqlCommand cmd = new MySqlCommand("sp_InsertChangeSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("oldclass", name[0]);
                        cmd.Parameters.AddWithValue("course",name[1]);
                        cmd.Parameters.AddWithValue("reason", name[2]);
                        cmd.Parameters.AddWithValue("weeknum",name[3]);
                        cmd.Parameters.AddWithValue("daynum",name[4]);
                        cmd.Parameters.AddWithValue("sec",name[5]);
                        cmd.Parameters.AddWithValue("buildingname",name[6]);
                        cmd.Parameters.AddWithValue("newcl",name[7]);
                        cmd.Parameters.AddWithValue("teacherid",name[8]);
                        cmd.Parameters.AddWithValue("scid", name[10]);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                       num= cmd.ExecuteNonQuery();
                        
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
            return num;
        }

        public DataTable GetFreeDay(int weeknum)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select  dayno as day, group_concat(section) as lecture from schedule where weekstart <="+weeknum+"  group by day";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetScheduleFree()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select classname, weekstart, weekend, dayno, section from schedule";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetBuilding()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select distinct(buildingname) as building from buildingdetails order by buildingname";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetAvailClasses(string week , string building)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select sc.classname, count(section) as section " +
                                "from schedule sc join classdetails cd on sc.classname = cd.classname " +
                                "where weekStart <= "+week+" and weekend>= "+week+" and cd.teachingbuilding = '"+building+"'"+
                                "group by sc.classname  union select classname, '0' as section from classdetails cd where " +
                                " cd.teachingbuilding ='" + building + "' and classname not in(select classname from schedule) order by classname ";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetAvailDay(string week, string classname)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select dayno, group_concat( section) as section from schedule "+
                                "where weekStart<= "+week+ " and weekend>= " + week + " and classname = '"+classname+"' group by dayno ";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetTeacherDetail(string coursename)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select distinct(teachername) from schedule where coursename='"+coursename+"'";
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetTransferSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select sc.classname as oldclass, newclass, concat(sc.weekstart, ',', sc.dayno ,',', sc.section) as oldtime, "+
                            "concat(scd.newweek, ',', scd.newday, ',', scd.newsection) as newtime, sc.teacherName as oldteacher, "+
                            "scd.NewTeacherid as newteacher, 'multimedia' as classtype , currentstatus, reason, sc.coursename , scd.id as id " +
                                "from scheduletransfer scd join schedule sc on sc.id = scd.idref ";
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public int SaveScheduleStat(string[] stat)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    string query = "update Scheduletransfer set currentstatus ='" + stat[0]+"' where id="+ stat[1];
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                       
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        num = cmd.ExecuteNonQuery();

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
            return num;

        }

        public DataTable GetScheduleForDate(string date)
        {
            DataTable dt = new DataTable();
            try
            {                
                using (MySqlConnection con = new MySqlConnection( constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetScheduleforDate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customdate", date);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable GetClassesByDateAndBuilding(string date, string building)
        {
            DataTable dt = new DataTable();
            try
            {
                
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_ScheduleByBuildingAndDate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customdate", date);
                        cmd.Parameters.AddWithValue("@building", building);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetScheduleByBuildWeekSem(string building, string sem, string week)
        {
            DataTable dt = new DataTable();
            try
            {

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Sp_getScheduleByBuildWeekSem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@build", building);
                        cmd.Parameters.AddWithValue("@weekno", week);
                        cmd.Parameters.AddWithValue("@sem", sem);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetScheduleByBuildSem(string building, string sem)
        {
            DataTable dt = new DataTable();
            try
            {

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_getScheduleByBuildSem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@build", building);
                        
                        cmd.Parameters.AddWithValue("@sem", sem);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetTransferScheduleByBuildSem(string building, string sem)
        {
            DataTable dt = new DataTable();
            try
            {

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetTransferScheduleByBuildSem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@build", building);

                        cmd.Parameters.AddWithValue("@sem", sem);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetScheduleByBuild(string building)
        {
            DataTable dt = new DataTable();
            try
            {

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetScheduleByBuild", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@build", building);
                        
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public string GetWeekByDate(string date)
        {
            string week = "";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetWeekByDate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customdate", date);
                        cmd.Parameters.Add("@weekno", MySqlDbType.String);
                        cmd.Parameters["@weekno"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        week = cmd.Parameters["@weekno"].Value.ToString();
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
            return week;
        }

        public string[] GetYearAndSemester(string date)
        {
            string[] data = new string[2];
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetYearAndSemester", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@customdate", date);
                        cmd.Parameters.Add("@semname", MySqlDbType.String);
                        cmd.Parameters["@semname"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@schoolyear", MySqlDbType.String);
                        cmd.Parameters["@schoolyear"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        data[0] = cmd.Parameters["@semname"].Value.ToString();
                        data[1] = cmd.Parameters["@schoolyear"].Value.ToString();
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
            return data;
        }

        public int SaveReserveSchedule(string[] stat)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    string query = "INSERT INTO `organisationdatabase`.`schedulereserve` "+
                    "(`SchoolYear`,`Semester`,`week`,`Date`,`Section`,`Classroom`,`BorrowingUnit`,`Workphone`,`PersonName`, " +
                    "`PersonID`,`ContactNo`,`Purpose`,`Reason`,`ReservationDevices`,`Status`) "+
                    "VALUES('"+stat[0]+"','"+stat[1] + "','" + stat[4] + "','" + stat[2] + "','" + stat[3] 
                    +"','" + stat[5] + "','" + stat[6] + "','" + stat[7] + "','" + stat[8] + "','" + stat[9] + "','" + stat[10]
                    + "','" + stat[11] + "','" + stat[12] + "','" + stat[13] + "','Pending')";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        num = cmd.ExecuteNonQuery();

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
            return num;

        }

        public DataTable GetReserveSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select PersonID, date, PersonName, Classroom, section, purpose, status, id, " +
                    "Schoolyear, semester,week, borrowingunit,workphone,contactno,reason,reservationdevices from schedulereserve";
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public int ChangeReserveStatus(string[] stat)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    string query = "UPDATE `organisationdatabase`.`schedulereserve` SET `Status` = '"+stat[0]+"' WHERE `id` =" + stat[1];
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        num = cmd.ExecuteNonQuery();

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
            return num;

        }

        public DataTable GetTotalWeek()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select max(totalweeks) from semesterinfo";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetScheduleByBuilding(string buildingname)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select max(totalweeks) from semesterinfo";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable CallScheduleFilterMethods(string[] data)
        {
            DataTable dt = new DataTable();
            string building = data[0].Split(':')[1].Trim();
            string sem = data[2].Split(':')[1].Trim();            
            string date = data[1].Split(':')[1].Trim();

            return dt;
        }

        public DataTable GetCalenderDates(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select autoholiday, starttime, endtime from reserveandtransfer rt join semesterinfo sm " +
                    " on sm.semestername = rt.SemesterName where type='" + name+"' and "+ 
                                 "rt.semestername > (select SemesterName from semesterinfo where startdate < now() order by startdate desc limit 1) limit 1";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

    }
}