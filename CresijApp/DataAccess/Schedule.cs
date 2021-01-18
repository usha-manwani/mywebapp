using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CresijApp.Models;
namespace CresijApp.DataAccess
{
    public class Schedule
    {

        readonly string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;

        public DataTable GetCourse()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                string query = "select section,className, coursename, id from schedule";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }
        public DataTable GetSchedule()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_GetSchedule", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }
        // Schedule for transfer request with row ids
        public List<object> GetScheduleForTransfer(string name, string date, string userid, string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_GetTransferScheduleByDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@building", name);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@customdate", date);
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);

                }
            }

            data.Add(total);
            data.Add(dt);


            return data;
        }
        public DataTable GetCourseDetails(string[] name)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                string query = "select teachername, coursename, sc.Classname," +
                    " weekstart,weekend, dayno, section, teachingbuilding from schedule sc " +
                    "join classdetails cd on sc.classname =cd.classname " +
                    "where sc.classname = '" + name[0] + "' and sc.coursename = '" + name[1] + "' ";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;

        }

        public DataTable GetCourseDetailsForTransfer(string id)
        {
            DataTable dt = new DataTable();
            string query = "";
            query = "select teachername, coursename, cd.Classname as classname, cd.classid as classid," +
                " weekstart,weekend, dayno, section, bd.buildingname as building, sm.startdate as Startdate, " +
                "sem as semNum,totalweeks from schedule sc join classdetails cd on sc.ClassName = cd.classname " +
                " join semesterinfo sm on sc.sem = sm.semno join buildingdetails bd on" +
                " bd.buildingname =sc.teachingbuilding where sc.id = " + id;

            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;

        }

        public DataTable GetFreeWeek()
        {
            DataTable dt = new DataTable();
            string query = "select classname, weekstart, weekend from schedule";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public int SaveTransferSchedule(Dictionary<string,string> name)
        {
            int num = -1;
            var tempdate = new DateTime();
            using (var context = new OrganisationdatabaseEntities())
            {
                if (name.ContainsKey("oldDay"))
                {
                    var sem = Convert.ToInt32(name["sem"]);
                    var semstart = context.semesterinfoes.Where(x => x.SemNo == sem).Select(x => x.StartDate).FirstOrDefault();
                    var weekn = Convert.ToInt32(name["oldWeek"]) - 1;
                    tempdate = semstart.AddDays(weekn * 7);
                    var tempday = Convert.ToInt32(name["oldDay"])-2;
                    tempdate = tempdate.AddDays(tempday);
                }
                else
                {
                   tempdate = Convert.ToDateTime(name["oldDate"]);
                }

                scheduletransfer sc = new scheduletransfer() {
                    classname = name["oldClass"],
                    courseid=name["courseName"],
                    newclass=Convert.ToInt32(name["newClassId"]),
                    newsection= Convert.ToInt32(name["newSection"]),
                    newteacherid=name["newTeacherID"],
                    newbuilding = Convert.ToInt32(name["newBuilding"]),
                    newday=Convert.ToInt32(name["newday"]),
                    newweek = name["newWeek"],
                    reason=name["reason"],
                    idref = Convert.ToInt32(name["currentRefrenceID"]),
                    oldScheduleDate = tempdate,
                    currentstatus="pending"
                };
                context.scheduletransfers.Add(sc);
               num= context.SaveChanges();
            }
          
            return num;
        }

        public DataTable GetFreeDay(int weeknum)
        {
            DataTable dt = new DataTable();
            string query = "select  dayno as day, group_concat(section) as lecture from schedule where weekstart <=" + weeknum + "  group by day";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        

        public DataTable GetBuilding(string userid)
        {
            DataTable dt = new DataTable();
            string query = "select distinct(buildingname) as building, id from " +
                "buildingdetails bd join classdetails cd on bd.id = cd.teachingbuilding " +
                "where classid in (select locationid from userlocationaccess where level ='Class' and " +
                    " userserialnum = (select serialno from userdetails " +
                    "where loginid = '" + userid + "'))" +
                    " union select distinct(buildingname) as building,id from buildingdetails bd " +
                    "where id in(select locationid from userlocationaccess where level ='Building' and "+
                    " userserialnum = (select serialno from userdetails " +
                    "where loginid = '" + userid + "')) and id not in(select teachingbuilding from classdetails) order by building";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetBuildingNameandID()
        {
            DataTable dt = new DataTable();
            string query = "select distinct(buildingname) as building, id from " +
                "buildingdetails order by buildingname";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetAvailClasses(string week, string building, string userid, string sem)
        {
            DataTable dt = new DataTable();
            string query = "select distinct(sc.classname), count(section) as section ,cd.classid " +
                            "from schedule sc join classdetails cd on sc.classname = cd.classname " +
                            "where weekStart <= " + week + " and weekend>= " + week + " and cd.teachingbuilding = '"
                            + building + "' and cd.floor in(select id from floordetails where buildingname " +
                            "='" + building + "') and sem = " + sem +
                            " and sc.classname in (select classname from classdetails where classid in " +
                            "(select locationid from userlocationaccess where " +
                            " userserialnum = (select serialno from userdetails where loginid = '" + userid + "') and level ='Class' )) " +
                            " group by sc.classname union " +
                            "select distinct(classname), '0' as section,cd.classid from classdetails cd where " +
                             "cd.teachingbuilding = '" + building + "' and floor in" +
                             "(select id from floordetails where buildingname ='" + building + "')" +
                             " and classname not in (select distinct(sc.classname) " +
                            "from schedule sc join classdetails cd on sc.classname = cd.classname " +
                            "where weekStart <= " + week + " and weekend>= " + week + " and cd.teachingbuilding = '"
                            + building + "' and sem = " + sem + " and sc.classname in (select classname from classdetails where classid in " +
                            "(select locationid from userlocationaccess where level ='Class' " +
                            "and userserialnum = (select serialno from userdetails where loginid = '" + userid + "')))) ";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetAvailDay(string week, string classid, string semno)
        {
            DataTable dt = new DataTable();
            string query = "select dayno, group_concat(section) as section from schedule " +
                            "where weekStart<= " + week + " and weekend>= " + week + " and classname in" +
                            "(select classname from classdetails where classid=" + classid + ") and sem=" + semno + " group by dayno ";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }
        public DataTable GetTeacherDetail(string coursename)
        {
            DataTable dt = new DataTable();

            string query = "select distinct(teachername) as teachername,teacherid from schedule where coursename='" + coursename + "'" +
                " and teacherid in(select teacherid from teacherdata)";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public List<object> GetTransferSchedule(Dictionary<string,string>data)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;
            List<object> result = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetTransferScheduleList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_PageIndex", Convert.ToInt32(data["pageIndex"]));
                        cmd.Parameters.AddWithValue("_PageSize", Convert.ToInt32(data["pageSize"]));
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int24);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    totalRows = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                }
            }
            result.Add(totalRows);
            result.Add(dt);
            return result;
        }

        public int SaveTransferScheduleStat(string stat, string id)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                string query = "update Scheduletransfer set currentstatus ='" + stat + "' where id=" + id;
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    num = cmd.ExecuteNonQuery();

                }
            }
            return num;

        }

        public DataTable GetScheduleForDate(string date, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetScheduleforDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customdate", date);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        public List<object> GetScheduleByDate(string building, string date, string userid, string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                using (MySqlCommand cmd = new MySqlCommand("sp_GetScheduleByDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customdate", date.Trim());
                    cmd.Parameters.AddWithValue("@building", building.Trim());
                    cmd.Parameters.AddWithValue("@userid", userid.Trim());
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);
                }
            }
            data.Add(total);
            data.Add(dt);


            return data;
        }
        public DataTable GetScheduleByBuildWeekSem(string building, string sem, string week, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Sp_getScheduleByBuildWeekSem", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@build", building);
                    cmd.Parameters.AddWithValue("@weekno", week);
                    cmd.Parameters.AddWithValue("@sem", sem);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetScheduleByBuildSem(string building, string sem, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_getScheduleByBuildSem", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@build", building);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@sem", sem);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        internal DataTable GetSectionsInfo()
        {
            DataTable dt = new DataTable();

            string query = " select section, starttime,semesterno from sectionsinfo order by semesterno";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        public List<object> GetTransferScheduleByDay(string building, int sem, int week, int day, string userid,
            int pageIndex, int pageSize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetTransferScheduleByDay", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("build", building.Trim());
                    cmd.Parameters.AddWithValue("weekno", week);
                    cmd.Parameters.AddWithValue("sem", sem);
                    cmd.Parameters.AddWithValue("daynum", day);
                    cmd.Parameters.AddWithValue("userid", userid.Trim());
                    cmd.Parameters.AddWithValue("_PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("_PageSize", pageSize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();

                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    }
                }
            }

            data.Add(total);
            data.Add(dt);


            return data;
        }

        public DataTable GetScheduleByBuild(string building, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetScheduleByBuild", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@build", building);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public List<object> GetScheduleByDay(string building, int sem, int week, int day,
            string userid, int pageindex, int pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("Sp_GetScheduleByDay", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("build", building.Trim());
                    cmd.Parameters.AddWithValue("weekno", week);
                    cmd.Parameters.AddWithValue("sem", sem);
                    cmd.Parameters.AddWithValue("daynum", day);
                    cmd.Parameters.AddWithValue("userid", userid.Trim());
                    cmd.Parameters.AddWithValue("_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("_PageSize", pagesize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    }
                }
            }

            data.Add(total);
            data.Add(dt);


            return data;
        }


        public string GetWeekByDate(string date)
        {
            string week = "";
            using (MySqlConnection con = new MySqlConnection(constring))
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
            return week;
        }

        public string[] GetYearAndSemester(string date)
        {
            string[] data = new string[2];
            using (MySqlConnection con = new MySqlConnection(constring))
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
            return data;
        }

        public int SaveReserveSchedule(string[] stat)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                string query = "INSERT INTO `organisationdatabase`.`schedulereserve` " +
                "(`SchoolYear`,`Semester`,`week`,`ReserveDate`,`Section`,`Classroom`,`BorrowingUnit`,`Workphone`,`PersonName`, " +
                "`PersonID`,`ContactNo`,`Purpose`,`Reason`,`ReservationDevices`,`Status`) " +
                "VALUES('" + stat[0] + "','" + stat[1] + "','" + stat[2] + "','" + stat[3] + "','" + stat[4]
                + "','" + stat[5] + "','" + stat[6] + "','" + stat[7] + "','" + stat[8] + "','" + stat[9] + "','" + stat[10]
                + "','" + stat[11] + "','" + stat[12] + "','" + stat[13] + "','Pending')";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    num = cmd.ExecuteNonQuery();

                }
            }
            return num;

        }

        public List<object> GetReserveSchedule(Dictionary<string,string>data)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;
            List<object> result = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetReserveScheduleList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_PageIndex", Convert.ToInt32(data["pageIndex"]));
                    cmd.Parameters.AddWithValue("_PageSize", Convert.ToInt32(data["pageSize"]));
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int24);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    totalRows = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                }
            }
            result.Add(totalRows);
            result.Add(dt);
            return result;
        }

        public int ChangeReserveStatus(string stat, string id)
        {
            int num = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                string query = "UPDATE `organisationdatabase`.`schedulereserve` SET `Status` = '" + stat + "' WHERE `id` =" + id;
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    num = cmd.ExecuteNonQuery();

                }


            }
            return num;
        }

        public DataTable GetTotalWeek(string semnum)
        {
            DataTable dt = new DataTable();

            string query = "select totalweeks as totalweeks from semesterinfo where SemNo=" + semnum;
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetScheduleByBuilding(string buildingname)
        {
            DataTable dt = new DataTable();

            string query = "select max(totalweeks) from semesterinfo";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
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

            string query = "select Autoreview, NonWorkingDays, starttime, endtime,rt.semesterno from reserveandtransfer rt join " +
                " semesterinfo sm  on sm.semno = rt.Semesterno where type='" + name + "' and rt.semesterno >= " +
                "(select Semno from semesterinfo where startdate < now() order by startdate desc limit 1) limit 1;";
            using (MySqlConnection con = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return dt;
        }

        public List<object> GetScheduleByBuildWeekSemDayTest(string building, string sem, string week, string day,
           string userid, string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;

            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetScheduleTest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("build", building);
                    cmd.Parameters.AddWithValue("weekno", Convert.ToInt32(week));
                    cmd.Parameters.AddWithValue("sem", Convert.ToInt32(sem));
                    cmd.Parameters.AddWithValue("daynum", Convert.ToInt32(day));
                    cmd.Parameters.AddWithValue("userid", userid);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                }
            }

            return data;
        }

    }
}