using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace WebCresij
{
    public class Userdetails
    {
       
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public DataTable getUserDetails(string s)
        {
            DataTable dtuser = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.fn_GetUserDetails(@Userid)", con))
                {
                    cmd.Parameters.AddWithValue("@Userid", s);
                    try
                    {
                        con.Open();
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.fn_GetUserDetailsPending()", con))
                {
                   
                    try
                    {
                        con.Open();
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DelUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        

                    }
                    catch { }
                    
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UserRoleSave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@role", role);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();


                    }
                    catch  { }

                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}