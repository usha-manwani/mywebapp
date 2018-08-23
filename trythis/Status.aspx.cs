   using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;

using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace trythis
{
    public partial class Status : System.Web.UI.Page
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           // DataTable dt1 = s.CC();
        
            if (!IsPostBack)
            {
               
                
            }
        

        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
            DataTable ScoresTable = Application["ScoreTable"] as DataTable;
           
        }
        protected void Timer1_Tick()
        {
            DataTable dt1 = null;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }

        public DataTable updateData(DataTable dt)
        {
            DataTable dt1 = new DataTable();
            
            foreach (DataRow dr in dt.Rows)
            {
                DataRow row = dt1.NewRow();
                row[0] = dr[0];
                if (Convert.ToInt32( dr[20]) != -1)
                { 

                    if (Convert.ToByte( dr[6])== Convert.ToByte(0xc4))
                    {
                        row[3] = "Online";
                    }
                if (Convert.ToByte( dr[8] )== Convert.ToByte(0x00))
                {
                    row[4] = "Closed";
                }
                else
                    dr[4] = "Open";

                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[6] = "OFF";
                }
                else
                    dr[6] = "ON";

                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[15] = "Locked";
                }
                else
                    dr[15] = "Opened";


                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[14] = "Locked";
                }
                else
                    dr[14] = "Opened";


                switch (Convert.ToInt32(dr[6]))
                {
                    case 1:
                        dr[12] = "Desktop PC";
                        break;
                    case 2:
                        dr[12] = "Laptop";
                        break;
                    case 3:
                        dr[12] = "Digital Booth";
                        break;
                    case 4:
                        dr[12] = "Digital Equipment";
                        break;
                    case 5:
                        dr[12] = "DVD";
                        break;
                    case 6:
                        dr[12] = "Blu-Ray DVD";
                        break;
                    case 7:
                        dr[12] = "TV set";
                        break;
                    case 8:
                        dr[12] = "VCR";
                        break;
                    case 9:
                        dr[12] = "Recording System";
                        break;
                    default:
                        dr[12] = "No system Detected";
                        break;
                }

                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[13] = "Locked";
                }
                else
                    dr[13] = "Open";

                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[7] = "Closed";
                }
                else
                    dr[7] = "Open";

                switch (Convert.ToInt32(dr[6]))
                {
                    case 1:
                        dr[10] = "Open";
                        break;
                    case 2:
                        dr[10] = "Down";
                        break;
                    case 0:
                        dr[10] = "Stop";
                        break;
                }
                switch (Convert.ToInt32(dr[6]))
                {
                    case 1:
                        dr[9] = "Open";
                        break;
                    case 2:
                        dr[9] = "Down";
                        break;
                    case 0:
                        dr[9] = "Stop";
                        break;
                }
                if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
                {
                    dr[11] = "OFF";
                }
                else
                    dr[11] = "On";

            }


                    else
                    {

                    if (Convert.ToByte(dr[6]) == Convert.ToByte(0xc9))
                    {
                        dr[3] = "Offline";
                    }
                }
            }


                

            
            return dt;

        }
    }
  

}