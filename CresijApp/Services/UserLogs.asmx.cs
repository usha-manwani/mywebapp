using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for UserLogs
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserLogs : System.Web.Services.WebService
    {

        [WebMethod]
        public List<object> Login(string[] data)
        {
            List<object> idata = new List<object>();
            UserLogsDataAccess userLogs = new UserLogsDataAccess();
            DataTable dt = userLogs.Login(data[0], data[1]);
            if (dt.Rows.Count > 0)
            {
                idata.Add(dt.Rows[0].ItemArray);
            }
            return idata;
        }
        [WebMethod]
        public List<object> GetUserLogDetails()
        {
            List<object> idata = new List<object>();
            UserLogsDataAccess userLogs = new UserLogsDataAccess();
            DataTable dt = userLogs.GetUserLogDetails();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                idata.Add(dr.ItemArray);
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetLogGraphData()
        {
            List<object> idata = new List<object>();
            UserLogsDataAccess userLogs = new UserLogsDataAccess();
            DataTable dt = userLogs.GetLogDetails();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                    idata.Add(dr.ItemArray);
            }
            return idata;
        }
    }
}
