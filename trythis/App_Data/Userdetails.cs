using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace WebCresij
{
    public class Userdetails
    {
       
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings
            ["CresijCamConnectionString"].ConnectionString;
        public DataTable getUserDetails(string s)
        {
            DataTable dtuser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_getUserDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", s);
                    try
                    {
                        con.Open();
                        MySqlDataAdapter sa = new MySqlDataAdapter(cmd);
                        sa.Fill(dtuser);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

                return dtuser;
        }

        public DataTable getUserDetailsPending()
        {
            DataTable dtuser = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_getuserDetailsPending", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        MySqlDataAdapter sa = new MySqlDataAdapter(cmd);
                        sa.Fill(dtuser);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dtuser;
        }

        public void DeleteUser(string userid)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteuser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }


        public void SaveUser(string userid, string i)
        {
            int role = Convert.ToInt32(i);
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_UserRoleSave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tuserid", userid);
                    cmd.Parameters.AddWithValue("@trole", role);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();


                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch(Exception ex){ }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int RegisterTempUser(string[] data)
        {
            int result = 0;
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_RegisterOneTimeUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("tempUserName", data[0]);
                        cmd.Parameters.AddWithValue("tempuserid", data[1]);
                        cmd.Parameters.AddWithValue("pass", data[2]);
                        
                        cmd.Parameters.AddWithValue("ip", data[3]);
                        cmd.Parameters.AddWithValue("tempdate", data[4]);
                        cmd.Parameters.AddWithValue("time1", data[5]);
                        cmd.Parameters.AddWithValue("time2", data[6]);
                        cmd.Parameters.AddWithValue("Stat", data[7]);
                        cmd.Parameters.AddWithValue("phone", data[8]);
                        cmd.Parameters.AddWithValue("desce", data[9]);
                        cmd.Parameters.Add("duplicate", MySqlDbType.Int32);
                        cmd.Parameters["duplicate"].Direction = ParameterDirection.Output;
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            result = Convert.ToInt32(cmd.Parameters["duplicate"].Value);
                        }
                    }
                }
                catch(Exception ex)
                {
                    result = -3;
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public void UpdateOneTimeUser(string Userid, string Stat)
        {
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_updateOneTimeuser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("tempuser", Userid);
                        cmd.Parameters.AddWithValue("stat", Stat);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                        }
                    }
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

        public int RejectOneTimeUser(string Userid)
        {
            int r = 0;
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                using(MySqlCommand cmd = new MySqlCommand("sp_rejectOneTimeUser", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("tempuser", Userid);
                        cmd.Parameters.Add("r", MySqlDbType.Int32);
                        cmd.Parameters["r"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();                            
                            cmd.ExecuteNonQuery();
                            r = Convert.ToInt32(cmd.Parameters["r"].Value);
                        }
                    }
                    catch(Exception ex)
                    {
                        r= -2;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return r;
        }

        public DataTable GetPendingTempUser()
        {
            DataTable dt = new DataTable();
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_GetPendingTempuser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                            dataAdapter.Fill(dt);
                        }
                    }
                }
                catch (Exception) { }
                finally { con.Close(); }
            }
            return dt;
        }
        public List<object> LoginTempuser(string userid, string password, string time1, string ip)
        {
            List<object> result = new List<object>();
            string name = "";
            int r = 0;
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                try{
                    using(MySqlCommand cmd = new MySqlCommand("sp_LoginForTempUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("usertemp", userid);
                        cmd.Parameters.AddWithValue("pass", password);
                        cmd.Parameters.AddWithValue("time1", time1);
                        cmd.Parameters.AddWithValue("ip", ip);
                        cmd.Parameters.Add("result", MySqlDbType.Int32);
                        cmd.Parameters["result"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("uname", MySqlDbType.VarChar, 50);
                        cmd.Parameters["uname"].Direction = ParameterDirection.Output;
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        r = Convert.ToInt32(cmd.Parameters["result"].Value);
                        name = cmd.Parameters["uname"].Value.ToString();
                    }
                }
                catch(Exception ex)
                {
                    r = -5;
                }
                finally
                {
                    con.Close();
                }
            }
            result.Add(r);
            result.Add(name);
            return result;
        }
        
        public static int totalPendingUser()
        {
            int count = 0;
            using(MySqlConnection con = new MySqlConnection(constr))
            {                
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_CountPendingUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@total", MySqlDbType.Int32);
                        cmd.Parameters["@total"].Direction = ParameterDirection.Output;
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        count = Convert.ToInt32(cmd.Parameters["@total"].Value);
                    }
                }
                catch(Exception ex)
                {
                    
                }
                finally
                {
                    con.Close();
                }
            }
            return count;
        }

        public int ChangePass(string userid, string oldpass, string newpass)
        {
            int r = 0;
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "update user_details set password = '"+newpass+
                    "' where user_id ='" + userid + "' and password ='" + oldpass + "'";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        r = cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    r = -1;
                }
                finally
                {
                    con.Close();
                }
            }
            return r;
        }
    }
}