using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    public class SystemInfo
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SaveSystemInfo(string schoolname, string schooleng, string logourl, string semname, string weeks, string semstartdate, Dictionary<string, string> days, string semno, string autoholiday)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertSystemInfo", con)) // sp_SaveTempData
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@schname", schoolname);
                    cmd.Parameters.AddWithValue("@scheng", schooleng);
                    cmd.Parameters.AddWithValue("@logoloc", logourl);
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@semweeks", weeks);
                    cmd.Parameters.AddWithValue("@semstart", semstartdate);
                    cmd.Parameters.AddWithValue("@sun", days["Sunday"]);
                    cmd.Parameters.AddWithValue("@mon", days["Monday"]);
                    cmd.Parameters.AddWithValue("@tue", days["Tuesday"]);
                    cmd.Parameters.AddWithValue("@wed", days["Wednesday"]);
                    cmd.Parameters.AddWithValue("@thu", days["Thursday"]);
                    cmd.Parameters.AddWithValue("@fri", days["Friday"]);
                    cmd.Parameters.AddWithValue("@sat", days["Saturday"]);
                    cmd.Parameters.AddWithValue("@semno", Convert.ToInt32(semno));
                    cmd.Parameters.AddWithValue("@autoholiday", autoholiday);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }

            }
            return result;
        }

        public int SaveSectionsInfo(string semname, string section, string starttime, string stoptime)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_insertUpdateSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@sec", section);
                    cmd.Parameters.AddWithValue("@starttime", starttime);
                    cmd.Parameters.AddWithValue("@stoptime", stoptime);


                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }

            }
            return result;
        }
        public int SaveReserveAndTransferInfo(string typ, string nonwork, string auto, string start, string end, string semname)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_InsertUpdateReserverTransfer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@typ", typ);
                    cmd.Parameters.AddWithValue("@nonwork", nonwork);
                    cmd.Parameters.AddWithValue("@autoreview", auto);
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@startdate", start);
                    cmd.Parameters.AddWithValue("@enddate", end);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int DeleteSectionsInfo(string semname)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semname", semname);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public DataTable GetFloorClassByBuilding(string building)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select fd.floor ,json_arrayagg(json_object('Name',classname , 'Id',classid)) as className from " +
                        " classdetails  cd join floordetails fd on cd.floor = fd.id " +
                        " where teachingbuilding=" + building + " and cd.floor in(select id from floordetails where buildingName=" + building + ") " +
                        " group by cd.floor  union select floor,'' from floordetails where buildingname=" + building + " and " +
                        " id not in(select floor from classdetails where teachingbuilding =" + building + ") group by floor order by floor";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable GetIpByClass(string classlist)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetipByClass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classlist", classlist);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetFloorClassByBuildingUserAccess(string building, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select  fd.floor ,json_arrayagg(json_object('Name',classname , 'Id',classid)) as className" +
                    " from classdetails cd join floordetails fd on cd.floor =fd.id " +
                    " where teachingbuilding='" + building + "' and cd.floor in(select id from floordetails where " +
                    " buildingName='" + building + "') and classid in " +
                    "(select classid from userlocationaccess where userserialnum =(select serialno from userdetails" +
                    " where loginid ='" + userid + "')) group by cd.floor ";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}