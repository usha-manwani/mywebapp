using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace CresijApp.DataAccess
{
    public class GetOrgData
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SetOrgInfo(string deptcode, string deptname, string bCtrlCode, string highoff
            , string queno, string permission, string notes)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "Insert into departmentdetail (departmentName , departmentCode)" +
                    " values ('" + deptcode+"','"+deptname +"')";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int num =  cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            query = "insert into organisationdetails (deptCode,BusinessCtrlCode," +
                                "HigherOffice,QueueNumber,Public,Notes) values ('"+deptcode+"','"+bCtrlCode+"','"
                                +highoff+"',"+queno+",'"+permission+"','"+notes+"')";
                            MySqlCommand cmd1 = new MySqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                            result = 1;
                        }
                    }
                }
                catch(Exception ex)
                {
                    result = -1;
                }
            }
            return result;
        }

        public List<object> GetOrgBuildingInfo(string pageIndex, string pageSize)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> result = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                using (MySqlCommand cmd = new MySqlCommand("sp_GetBuildingDetailsInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@_PageSize", pageSize);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);
                }
                result.Add(total);
                result.Add(dt);
            }
            return result;
        }

        public List<object> GetuserInfo(string pageIndex, string pageSize)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> result = new List<object>();

            using (MySqlConnection con = new MySqlConnection(constr))
                {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetAllUserDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@_PageSize", pageSize);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);
                }
                result.Add(total);
                result.Add(dt);
            }
            return result;
        }

        public List<object> GetTeacherInfo(string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetTeacherData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }
            return data;
        }

        public List<object> GetStudentInfo(string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetStudentData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                        cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                        data.Add(total);
                        data.Add(dt);
                    }
                }
            }
            catch(Exception ex) { }
            return data;
        }

        public List<object> GetCapitalInfo( string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                using (MySqlCommand cmd = new MySqlCommand("sp_GetOperationMgmtData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }
            return data;
        }

        public List<object> GetClassroomInfo(string pageindex, string pagesize)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetAllClassDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                        cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                        data.Add(total);
                        data.Add(dt);
                    }
                }
            
            return data;
        }
        public DataTable GetClassData(string classid)
        {
            DataTable dt = new DataTable();
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from Classdetails where classid=" +classid;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            
            return dt;
        }
        public DataTable GetDevicesInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from devicesdetails";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetOrgDataonDemand(int sn)
        {
            DataTable dt = new DataTable();
            try
            {
                using(MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT id,  buildingName, buildingCode, schoolname, " +
                             "Queue, Public, remarks FROM buildingdetails bd join systemsettings where bd.id ="+sn;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
            }
            catch(Exception ex) { }
            return dt;
        }

        public DataTable GetUserDataonDemand(string sn)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from userdetails where loginid ='" + sn+"'";
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
            }
            catch (Exception ex) { }
            return dt;
        }

        public List<object> GetIPClassByBuilding(string pageindex, string pagesize,string data,string userid)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> list = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_GetClassIPByBuilding", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@building", data);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    list.Add(total);
                    list.Add(dt);
                }
            }
            return list;
        }

        public List<object> GetIPClassByBuildingFloor(string building,string floor,string userid,string pageindex,int pagesize)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> list = new List<object>();
           
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_GetIPClassByBuildingFloor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@building", building);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                        cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                        cmd.Parameters.AddWithValue("@floornum", floor);
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                        total =Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                        list.Add(total);
                        list.Add(dt);
                    }
                }
          
            return list;
        }

        public DataTable GetFloorlist(string building)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT floor from floordetails where buildingname='" + building + "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetSchoolName(string building)
        {
            DataTable dt = new DataTable();
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT SchoolName from SystemSettings limit 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            
           
            return dt;
        }

        public DataTable GetClassByIP(string ip)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT classname from classdetails where ccequipip ='" + ip + "' limit 1";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable GetFloorDetails(string building)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * from Floordetails where BuildingName ='" + building+ "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}