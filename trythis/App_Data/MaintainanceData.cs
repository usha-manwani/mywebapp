using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebCresij
{
    public class MaintainanceData
    {
        public static string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        public int InsertFaultInfo( string ip, string faultknow, string priority, string distName,
            string memName, string desc, string phone, string stat)
        {
            int result=0;
            using(SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    using(SqlCommand cmd = new SqlCommand("sp_InsertFaultInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@faultknow", faultknow);
                        cmd.Parameters.AddWithValue("@priority", priority);
                        cmd.Parameters.AddWithValue("@distName", distName);
                        cmd.Parameters.AddWithValue("@memName", memName);
                        cmd.Parameters.AddWithValue("@desc", desc);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@stat", stat);
                        cmd.Parameters.Add("@result", SqlDbType.Int);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result= Convert.ToInt32(cmd.Parameters["@result"].Value);
                    }
                }
                catch(Exception ex)
                {
                    result = -1;
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public void UpdateStatus(string ip, string[] data)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_updateStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@status", data[0]);
                        cmd.Parameters.AddWithValue("@workStatus", data[1]);
                        cmd.Parameters.AddWithValue("@pcstatus", data[2]);

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}