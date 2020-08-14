using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace CresijApp.DataAccess
{
    public class SetOrgData
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SaveOrgDataBuilding(Dictionary<string,string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_InsertBuildingDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data["buildingName"].ToString());
                        cmd.Parameters.AddWithValue("buscode", data["buildingCode"].ToString());
                        
                        cmd.Parameters.AddWithValue("que", data["queue"].ToString());
                        cmd.Parameters.AddWithValue("typeaccess", data["accessType"].ToString());
                        cmd.Parameters.AddWithValue("notes", data["notes"].ToString());
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int SaveOrgDataFloor(Dictionary<string,string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_InsertFloorDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("flname", data["floorName"]);
                        cmd.Parameters.AddWithValue("buscode", data["buildingCode"]);
                        cmd.Parameters.AddWithValue("highoff", data["buildingName"]);
                        cmd.Parameters.AddWithValue("que", data["queue"]);
                        cmd.Parameters.AddWithValue("typeaccess", data["accessType"]);
                        cmd.Parameters.AddWithValue("notes", data["notes"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int UpdateOrgData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateBuildingData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data["buildingName"]);
                        cmd.Parameters.AddWithValue("buscode", data["buildingCode"]);
                        
                        cmd.Parameters.AddWithValue("que", data["queue"]);
                        cmd.Parameters.AddWithValue("typeaccess", data["accessType"]);
                        cmd.Parameters.AddWithValue("note", data["notes"]);
                        cmd.Parameters.AddWithValue("sn", data["id"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int SaveTeacherData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveTeacherData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data["teacherId"]);
                        cmd.Parameters.AddWithValue("tname", data["teacherName"]);
                        cmd.Parameters.AddWithValue("gend", data["gender"]);
                        cmd.Parameters.AddWithValue("age", data["age"]);
                        cmd.Parameters.AddWithValue("fac", data["faculty"]);
                        cmd.Parameters.AddWithValue("ph", data["phone"]);
                        cmd.Parameters.AddWithValue("idcrd", data["idCard"]);
                        cmd.Parameters.AddWithValue("onecrd", data["oneCard"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int SaveStudentData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveStudentData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data["studentId"]);
                        cmd.Parameters.AddWithValue("tname", data["studentName"]);
                        cmd.Parameters.AddWithValue("gend", data["gender"]);
                        cmd.Parameters.AddWithValue("age", data["age"]);
                        cmd.Parameters.AddWithValue("fac", data["faculty"]);
                        cmd.Parameters.AddWithValue("ph", data["phone"]);
                        cmd.Parameters.AddWithValue("idcrd", data["idCard"]);
                        cmd.Parameters.AddWithValue("onecrd", data["oneCard"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int UpdateTeacherData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateTeacherData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data["teacherID"]);
                        cmd.Parameters.AddWithValue("tname", data["teacherName"]);
                        cmd.Parameters.AddWithValue("gend", data["gender"]);
                        cmd.Parameters.AddWithValue("ag", data["age"]);
                        cmd.Parameters.AddWithValue("fac", data["faculty"]);
                        cmd.Parameters.AddWithValue("ph", data["phone"]);
                        cmd.Parameters.AddWithValue("idcrd", data["idCard"]);
                        cmd.Parameters.AddWithValue("onecrd", data["oneCard"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int UpdateStudentData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateStudentData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data["studentID"]);
                        cmd.Parameters.AddWithValue("tname", data["studentName"]);
                        cmd.Parameters.AddWithValue("gend", data["gender"]);
                        cmd.Parameters.AddWithValue("ag", data["age"]);
                        cmd.Parameters.AddWithValue("fac", data["faculty"]);
                        cmd.Parameters.AddWithValue("ph", data["phone"]);
                        cmd.Parameters.AddWithValue("idcrd", data["idCard"]);
                        cmd.Parameters.AddWithValue("onecrd", data["oneCard"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int SaveClassData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveClassData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("cname", data["className"]);
                        cmd.Parameters.AddWithValue("tbuild", data["buildingName"]);
                        cmd.Parameters.AddWithValue("tfloor", data["floor"]);
                        cmd.Parameters.AddWithValue("tseat", data["seat"]);
                        cmd.Parameters.AddWithValue("camipS", data["camIpS"]);
                        cmd.Parameters.AddWithValue("camipT", data["camIpT"]);
                        cmd.Parameters.AddWithValue("camSmac", data["camSmac"]);
                        cmd.Parameters.AddWithValue("camTmac", data["camTmac"]);
                        cmd.Parameters.AddWithValue("camport", data["camPort"]);
                        cmd.Parameters.AddWithValue("camid", data["camId"]);
                        cmd.Parameters.AddWithValue("campass", data["camPass"]);
                        cmd.Parameters.AddWithValue("ccip", data["centralControlIp"]);
                        cmd.Parameters.AddWithValue("ccmac", data["centralControlMac"]);
                        cmd.Parameters.AddWithValue("deskip", data["desktopIp"]);
                        cmd.Parameters.AddWithValue("deskmac", data["desktopMac"]);
                        cmd.Parameters.AddWithValue("recip", data["recorderIp"]);
                        cmd.Parameters.AddWithValue("recmac", data["recorderMac"]);
                        cmd.Parameters.AddWithValue("callhelpip", data["callHelpIp"]);
                        cmd.Parameters.AddWithValue("callhelpmac", data["callHelpMac"]);
                        
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }
        public int UpdateClassData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateClassData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("clsid", data["classID"]);
                        cmd.Parameters.AddWithValue("cname", data["className"]);
                        cmd.Parameters.AddWithValue("tbuild", data["buildingName"]);
                        cmd.Parameters.AddWithValue("tfloor", data["floor"]);
                        cmd.Parameters.AddWithValue("tseat", data["seat"]);
                        cmd.Parameters.AddWithValue("camsip", data["camIpS"]);
                        cmd.Parameters.AddWithValue("camtip", data["camIpT"]);
                        cmd.Parameters.AddWithValue("camsmac", data["camSmac"]);
                        cmd.Parameters.AddWithValue("camtmac", data["camTmac"]);
                        cmd.Parameters.AddWithValue("camport", data["camPort"]);
                        cmd.Parameters.AddWithValue("camid", data["camId"]);
                        cmd.Parameters.AddWithValue("campass", data["camPass"]);
                        cmd.Parameters.AddWithValue("ccip", data["centralControlIp"]);
                        cmd.Parameters.AddWithValue("ccmac", data["centralControlMac"]);
                        cmd.Parameters.AddWithValue("deskip", data["desktopIp"]);
                        cmd.Parameters.AddWithValue("deskmac", data["desktopMac"]);
                        cmd.Parameters.AddWithValue("recip", data["recorderIp"]);
                        cmd.Parameters.AddWithValue("recmac", data["recorderMac"]);
                        cmd.Parameters.AddWithValue("callhelpip", data["callHelpIp"]);
                        cmd.Parameters.AddWithValue("callhelpmac", data["callHelpMac"]);


                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        public int SaveUserData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveUserData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("logid", data["loginId"]);
                        cmd.Parameters.AddWithValue("uname", data["userName"]);
                        cmd.Parameters.AddWithValue("ptype", data["personType"]);
                        cmd.Parameters.AddWithValue("deptname", data["departmentName"]);
                        cmd.Parameters.AddWithValue("stats", data["personnelStatus"]);
                        cmd.Parameters.AddWithValue("phone", data["phone"]);
                        cmd.Parameters.AddWithValue("note", data["notes"]);
                        cmd.Parameters.AddWithValue("pass", data["password"]);
                        cmd.Parameters.AddWithValue("expiredate", data["expireDate"]);
                        cmd.Parameters.AddWithValue("timeexp", data["expireTime"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }
        public int UpdateUserData(Dictionary<string, string> data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateUserData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("logid", data["loginId"]);
                        cmd.Parameters.AddWithValue("uname", data["userName"]);
                        cmd.Parameters.AddWithValue("ptype", data["personType"]);
                        cmd.Parameters.AddWithValue("deptname", data["departmentName"]);
                        cmd.Parameters.AddWithValue("stats", data["personnelStatus"]);
                        cmd.Parameters.AddWithValue("phone", data["phone"]);
                        cmd.Parameters.AddWithValue("note", data["notes"]);
                        cmd.Parameters.AddWithValue("pass", data["password"]);
                        cmd.Parameters.AddWithValue("expiredate", data["expireDate"]);
                        cmd.Parameters.AddWithValue("time1", data["expireTime"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }
    }
}