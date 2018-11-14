using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace trythis
{
    public class CameraOnline
    {

        DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        protected DataTable CameraStatus( DataTable dt1)
        {
            if (dt.Columns.Count!=2)
            {
                dt.Columns.Add("Status", typeof(string));
            }
            foreach (DataRow r in dt1.Rows)
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(r[0].ToString());
                if (pingReply.Status== IPStatus.Success)
                {
                    r["Status"] = "online";
                }
                else
                    r["Status"] = "offline";
            }            
            return dt1;
        }

        public DataTable Camcheck()
        {
            
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select CameraIP from Camera_Details", con))
                {
                    try
                    {
                        con.Open();
                        da.Fill(dt);
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
            if (dt.Rows.Count > 0)
            {
                CameraStatus(dt);
            }
            return dt;
        }
        public string Camstatuscheck(string IP)
        {
            string status = "";
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(IP);
            if (pingReply.Status == IPStatus.Success)
            {
                status = "online";
            }
            else
                status = "offline";

            return status;
        }
    }
}