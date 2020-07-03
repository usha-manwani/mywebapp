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
        public int SaveOrgDataBuilding(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_InsertBuildingDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data[0]);
                        cmd.Parameters.AddWithValue("buscode", data[1]);
                        
                        cmd.Parameters.AddWithValue("que", data[2]);
                        cmd.Parameters.AddWithValue("typeaccess", data[3]);
                        cmd.Parameters.AddWithValue("notes", data[4]);
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

        public int SaveOrgDataFloor(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_InsertFloorDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("flname", data[0]);
                        cmd.Parameters.AddWithValue("buscode", data[1]);
                        cmd.Parameters.AddWithValue("highoff", data[2]);
                        cmd.Parameters.AddWithValue("que", data[3]);
                        cmd.Parameters.AddWithValue("typeaccess", data[4]);
                        cmd.Parameters.AddWithValue("notes", data[5]);
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

        public int UpdateOrgData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateBuildingData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data[0]);
                        cmd.Parameters.AddWithValue("buscode", data[1]);
                        
                        cmd.Parameters.AddWithValue("que", data[3]);
                        cmd.Parameters.AddWithValue("typeaccess", data[4]);
                        cmd.Parameters.AddWithValue("note", data[5]);
                        cmd.Parameters.AddWithValue("sn", data[6]);
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

        public int SaveTeacherData(string[]data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveTeacherData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("tname", data[1]);
                        cmd.Parameters.AddWithValue("gend", data[2]);
                        cmd.Parameters.AddWithValue("age", data[3]);
                        cmd.Parameters.AddWithValue("fac", data[4]);
                        cmd.Parameters.AddWithValue("ph", data[5]);
                        cmd.Parameters.AddWithValue("idcrd", data[6]);
                        cmd.Parameters.AddWithValue("onecrd", data[7]);
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

        public int SaveStudentData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveStudentData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("tname", data[1]);
                        cmd.Parameters.AddWithValue("gend", data[2]);
                        cmd.Parameters.AddWithValue("age", data[3]);
                        cmd.Parameters.AddWithValue("fac", data[4]);
                        cmd.Parameters.AddWithValue("ph", data[5]);
                        cmd.Parameters.AddWithValue("idcrd", data[6]);
                        cmd.Parameters.AddWithValue("onecrd", data[7]);
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

        public int UpdateTeacherData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateTeacherData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("tname", data[1]);
                        cmd.Parameters.AddWithValue("gend", data[2]);
                        cmd.Parameters.AddWithValue("ag", data[3]);
                        cmd.Parameters.AddWithValue("fac", data[4]);
                        cmd.Parameters.AddWithValue("ph", data[5]);
                        cmd.Parameters.AddWithValue("idcrd", data[6]);
                        cmd.Parameters.AddWithValue("onecrd", data[7]);
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

        public int UpdateStudentData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateStudentData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("tname", data[1]);
                        cmd.Parameters.AddWithValue("gend", data[2]);
                        cmd.Parameters.AddWithValue("ag", data[3]);
                        cmd.Parameters.AddWithValue("fac", data[4]);
                        cmd.Parameters.AddWithValue("ph", data[5]);
                        cmd.Parameters.AddWithValue("idcrd", data[6]);
                        cmd.Parameters.AddWithValue("onecrd", data[7]);
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

        public int SaveClassData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveClassData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("cname", data[0]);
                        cmd.Parameters.AddWithValue("tbuild", data[1]);
                        cmd.Parameters.AddWithValue("tfloor", data[2]);
                        cmd.Parameters.AddWithValue("tseat", data[3]);
                        cmd.Parameters.AddWithValue("camipS", data[4]);
                        cmd.Parameters.AddWithValue("camipT", data[5]);
                        cmd.Parameters.AddWithValue("camSmac", data[6]);
                        cmd.Parameters.AddWithValue("camTmac", data[7]);
                        cmd.Parameters.AddWithValue("camport", data[8]);
                        cmd.Parameters.AddWithValue("camid", data[9]);
                        cmd.Parameters.AddWithValue("campass", data[10]);
                        cmd.Parameters.AddWithValue("ccip", data[11]);
                        cmd.Parameters.AddWithValue("ccmac", data[12]);
                        cmd.Parameters.AddWithValue("deskip", data[13]);
                        cmd.Parameters.AddWithValue("deskmac", data[14]);
                        cmd.Parameters.AddWithValue("recip", data[15]);
                        cmd.Parameters.AddWithValue("recmac", data[16]);
                        cmd.Parameters.AddWithValue("callhelpip", data[17]);
                        cmd.Parameters.AddWithValue("callhelpmac", data[18]);
                        
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
        public int UpdateClassData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateClassData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("clsid", data[19]);
                        cmd.Parameters.AddWithValue("cname", data[0]);
                        cmd.Parameters.AddWithValue("tbuild", data[1]);
                        cmd.Parameters.AddWithValue("tfloor", data[2]);
                        cmd.Parameters.AddWithValue("tseat", data[3]);
                        cmd.Parameters.AddWithValue("camsip", data[4]);
                        cmd.Parameters.AddWithValue("camtip", data[5]);
                        cmd.Parameters.AddWithValue("camsmac", data[6]);
                        cmd.Parameters.AddWithValue("camtmac", data[7]);
                        cmd.Parameters.AddWithValue("camport", data[8]);
                        cmd.Parameters.AddWithValue("camid", data[9]);
                        cmd.Parameters.AddWithValue("campass", data[10]);
                        cmd.Parameters.AddWithValue("ccip", data[11]);
                        cmd.Parameters.AddWithValue("cmac", data[12]);
                        cmd.Parameters.AddWithValue("deskip", data[13]);
                        cmd.Parameters.AddWithValue("deskmac", data[14]);
                        cmd.Parameters.AddWithValue("recip", data[15]);
                        cmd.Parameters.AddWithValue("recmac", data[16]);
                        cmd.Parameters.AddWithValue("callhelpip", data[17]);
                        cmd.Parameters.AddWithValue("callhelpmac", data[18]);
                        
                        
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

        public int SaveUserData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_SaveUserData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("uname", data[1]);
                        cmd.Parameters.AddWithValue("ptype", data[2]);
                        cmd.Parameters.AddWithValue("deptname", data[3]);
                        cmd.Parameters.AddWithValue("stats", data[4]);
                        cmd.Parameters.AddWithValue("phone", data[5]);
                        cmd.Parameters.AddWithValue("note", data[6]);
                        cmd.Parameters.AddWithValue("pass", data[7]);
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
        public int UpdateUserData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateUserData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", data[0]);
                        cmd.Parameters.AddWithValue("uname", data[1]);
                        cmd.Parameters.AddWithValue("ptype", data[2]);
                        cmd.Parameters.AddWithValue("deptname", data[3]);
                        
                        cmd.Parameters.AddWithValue("phone", data[4]);
                        cmd.Parameters.AddWithValue("note", data[5]);
                        cmd.Parameters.AddWithValue("pass", data[6]);
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