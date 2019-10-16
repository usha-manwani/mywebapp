using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand("sp_InsertFaultInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@faultknow", faultknow);
                        cmd.Parameters.AddWithValue("@priority", priority);
                        cmd.Parameters.AddWithValue("@distName", distName);
                        cmd.Parameters.AddWithValue("@memName", memName);
                        cmd.Parameters.AddWithValue("@desce", desc);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@stat", stat);
                        cmd.Parameters.Add("@result", MySqlDbType.Int32);
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
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_updateStatus", con))
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