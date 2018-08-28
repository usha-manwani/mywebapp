using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;


namespace trythis.Hubsfile
{
    public class UpdateDevice
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        SqlConnection connection;
        DataTable dt;
         public DataTable update()
        {
            try
            {
                connection = new SqlConnection(constr);
                dt = new DataTable();
                string query = "select * from dbo.[CentralControl]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                connection.OpenAsync();
                dataAdapter.Fill(dt);
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
            //if (dt != null)
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