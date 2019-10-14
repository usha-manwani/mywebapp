using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;
namespace WebCresij.Hubsfile
{
    public class UpdateDevice
    {
        public static string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        MySqlConnection connection;
        DataTable dt;
        public DataTable update()
        {
            try
            {
                connection = new MySqlConnection(constr);
                dt = new DataTable();
                string query = "select * from dbo.[CentralControl]";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                connection.OpenAsync();
                dataAdapter.Fill(dt);
                if (dt != null)
                {
                    string ip = dt.Rows[0]["ip"].ToString();
                    MySqlCommand command = new MySqlCommand("DeleteDatafromRemote", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ip", ip);
                }
                //if(dt!=null)
                //{
                //    string ip = dt.Rows[0]["ip"].ToString();
                //    SqlCommand cmd = new SqlCommand("DeleteDatefromRemote", connection);
                //    cmd.Parameters.AddWithValue("@ip", ip);
                //}               
            }
            catch(Exception ex)
            {               
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            } 
            //if (dt != null)z
            //{
            //    updateStatus(dt);
            //}
            return dt;
        }

        public void updateStatus(DataTable dt)
        {
            byte[] receivedBytes= new byte[27];            
            DataColumnCollection dataColumn = dt.Columns;
            foreach(DataRow row in dt.Rows)
            {
                for (int i = 0; i < 27; i++)
                {
                    if (row[i] != null)
                        receivedBytes[i] = Convert.ToByte(row[i]);
                    else
                        break;
                }                                
            }  
        }        
        
    }
}