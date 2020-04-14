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
        public int SaveOrgData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_SaveOrganisationDeptData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data[0]);
                        cmd.Parameters.AddWithValue("buscode", data[1]);
                        cmd.Parameters.AddWithValue("highoff", data[2]);
                        cmd.Parameters.AddWithValue("que", data[3]);
                        cmd.Parameters.AddWithValue("typeaccess", data[4]);
                        cmd.Parameters.AddWithValue("notes", data[5]);
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

        public int UpdateOrgData(string[] data)
        {
            int result = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UPdateOrganisationDeptData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("deptname", data[0]);
                        cmd.Parameters.AddWithValue("buscode", data[1]);
                        cmd.Parameters.AddWithValue("highoff", data[2]);
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
                        cmd.Parameters.AddWithValue("ccip", data[4]);
                        cmd.Parameters.AddWithValue("cam1ip", data[5]);
                        cmd.Parameters.AddWithValue("cam2ip", data[6]);
                        cmd.Parameters.AddWithValue("deskip", data[7]);
                        cmd.Parameters.AddWithValue("recip", data[8]);
                        cmd.Parameters.AddWithValue("cmac", data[9]);
                        cmd.Parameters.AddWithValue("cport", data[10]);
                        cmd.Parameters.AddWithValue("cid", data[11]);
                        cmd.Parameters.AddWithValue("cpass", data[12]);
                        cmd.Parameters.AddWithValue("cam1mac", data[13]);
                        cmd.Parameters.AddWithValue("cam1port", data[14]);
                        cmd.Parameters.AddWithValue("cam1id", data[15]);
                        cmd.Parameters.AddWithValue("cam1pass", data[16]);
                        cmd.Parameters.AddWithValue("cam2mac", data[17]);
                        cmd.Parameters.AddWithValue("cam2port", data[18]);
                        cmd.Parameters.AddWithValue("cam2id", data[19]);
                        cmd.Parameters.AddWithValue("cam2pass", data[20]);
                        cmd.Parameters.AddWithValue("deskmac", data[21]);
                        cmd.Parameters.AddWithValue("deskport", data[22]);
                        cmd.Parameters.AddWithValue("deskid", data[23]);
                        cmd.Parameters.AddWithValue("deskpass", data[24]);
                        cmd.Parameters.AddWithValue("recmac", data[25]);
                        cmd.Parameters.AddWithValue("recport", data[26]);
                        cmd.Parameters.AddWithValue("recid", data[27]);
                        cmd.Parameters.AddWithValue("recpass", data[28]);
                        cmd.Parameters.AddWithValue("callhelp", data[29]);
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
                        cmd.Parameters.AddWithValue("clsid", data[30]);
                        cmd.Parameters.AddWithValue("cname", data[0]);
                        cmd.Parameters.AddWithValue("tbuild", data[1]);
                        cmd.Parameters.AddWithValue("tfloor", data[2]);
                        cmd.Parameters.AddWithValue("tseat", data[3]);
                        cmd.Parameters.AddWithValue("ccip", data[4]);
                        cmd.Parameters.AddWithValue("cam1ip", data[5]);
                        cmd.Parameters.AddWithValue("cam2ip", data[6]);
                        cmd.Parameters.AddWithValue("deskip", data[7]);
                        cmd.Parameters.AddWithValue("recip", data[8]);
                        cmd.Parameters.AddWithValue("cmac", data[9]);
                        cmd.Parameters.AddWithValue("cport", data[10]);
                        cmd.Parameters.AddWithValue("cid", data[11]);
                        cmd.Parameters.AddWithValue("cpass", data[12]);
                        cmd.Parameters.AddWithValue("cam1mac", data[13]);
                        cmd.Parameters.AddWithValue("cam1port", data[14]);
                        cmd.Parameters.AddWithValue("cam1id", data[15]);
                        cmd.Parameters.AddWithValue("cam1pass", data[16]);
                        cmd.Parameters.AddWithValue("cam2mac", data[17]);
                        cmd.Parameters.AddWithValue("cam2port", data[18]);
                        cmd.Parameters.AddWithValue("cam2id", data[19]);
                        cmd.Parameters.AddWithValue("cam2pass", data[20]);
                        cmd.Parameters.AddWithValue("deskmac", data[21]);
                        cmd.Parameters.AddWithValue("deskport", data[22]);
                        cmd.Parameters.AddWithValue("deskid", data[23]);
                        cmd.Parameters.AddWithValue("deskpass", data[24]);
                        cmd.Parameters.AddWithValue("recmac", data[25]);
                        cmd.Parameters.AddWithValue("recport", data[26]);
                        cmd.Parameters.AddWithValue("recid", data[27]);
                        cmd.Parameters.AddWithValue("recpass", data[28]);
                        cmd.Parameters.AddWithValue("callhelp", data[29]);
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