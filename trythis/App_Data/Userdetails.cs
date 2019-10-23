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
                    catch (Exception ex)
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
                    catch (Exception ex)
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
                    catch (Exception ex) { }
                    
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
                    catch(Exception ex){ }

                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}