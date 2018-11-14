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
    public partial class Status : Page
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {                  
            if (!IsPostBack)
            {
                loadGrid();                
            }
        }

        private void loadGrid()
        {
            CentralControl cc = new CentralControl();
            DataSet ds = cc.ControlDetails();
            GridView1.DataSource = ds;
            GridView1.DataBind();            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {           
         //   DataTable ScoresTable = Application["ScoreTable"] as DataTable;          
        }
        //protected void Timer1_Tick()
        //{
        //    DataTable ScoresTable = Application["ScoreTable"] as DataTable;
        //    if(ScoresTable == null){
        //        Hubsfile.UpdateDevice up = new Hubsfile.UpdateDevice();
        //        ScoresTable = up.update();
        //    }
        //    rptData.DataSource = ScoresTable;
        //    rptData.DataBind();
        //    //DataTable dt1 = null;
        //    //GridView1.DataSource = dt1;
        //    //GridView1.DataBind();
        //}

        //public DataTable updateData(DataTable dt)
        //{
        //    DataTable dt1 = new DataTable();
            
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        DataRow row = dt1.NewRow();
        //        row[0] = dr[0];
        //        if (Convert.ToInt32( dr[20]) != -1)
        //        { 

        //            if (Convert.ToByte( dr[6])== Convert.ToByte(0xc4))
        //            {
        //                row[3] = "Online";
        //            }
        //        if (Convert.ToByte( dr[8] )== Convert.ToByte(0x00))
        //        {
        //            row[4] = "Closed";
        //        }
        //        else
        //            row[4] = "Open";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[6] = "OFF";
        //        }
        //        else
        //            row[6] = "ON";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[15] = "Locked";
        //        }
        //        else
        //            row[15] = "Opened";


        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[14] = "Locked";
        //        }
        //        else
        //            row[14] = "Opened";


        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //               row[12] = "Desktop PC";
        //                break;
        //            case 2:
        //                row[12] = "Laptop";
        //                break;
        //            case 3:
        //                row[12] = "Digital Booth";
        //                break;
        //            case 4:
        //                row[12] = "Digital Equipment";
        //                break;
        //            case 5:
        //                row[12] = "DVD";
        //                break;
        //            case 6:
        //                row[12] = "Blu-Ray DVD";
        //                break;
        //            case 7:
        //                row[12] = "TV set";
        //                break;
        //            case 8:
        //                row[12] = "VCR";
        //                break;
        //            case 9:
        //                row[12] = "Recording System";
        //                break;
        //            default:
        //                row[12] = "No system Detected";
        //                break;
        //        }

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[13] = "Locked";
        //        }
        //        else
        //            row[13] = "Open";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[7] = "Closed";
        //        }
        //        else
        //            row[7] = "Open";

        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //                row[10] = "Open";
        //                break;
        //            case 2:
        //                row[10] = "Down";
        //                break;
        //            case 0:
        //                row[10] = "Stop";
        //                break;
        //        }
        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //                row[9] = "Open";
        //                break;
        //            case 2:
        //                row[9] = "Down";
        //                break;
        //            case 0:
        //                row[9] = "Stop";
        //                break;
        //        }
        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[11] = "OFF";
        //        }
        //        else
        //            row[11] = "On";

        //    }


        //            else
        //            {

        //            if (Convert.ToByte(dr[6]) == Convert.ToByte(0xc9))
        //            {
        //                row[3] = "Offline";
        //            }
        //        }
        //    }


                

            
        //    return dt;

        //}
    }
  

}