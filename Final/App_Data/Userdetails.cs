using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace final
{
    public class Userdetails
    {
       
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public DataTable getUserDetails()
        {
            DataTable dtuser = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.GetUserDetails()", con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        sa.Fill(dtuser);
                    }
                    catch
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UserRoleSave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@role", i);
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