using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for AlarmMonitor
    /// Class use to call Different user event logs in class
    /// Eg.: Camera Monitor logs , Desktop Event or usage Logs
    /// More web methods need to be added
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AlarmMonitor : System.Web.Services.WebService
    {
        /// <summary>
        ///Method use to get alarm logs from database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Action,time and desktop mac with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetAlarmEventLogs(Dictionary<string, string> data)
        {
            var idata = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    //
                    var AlarmLogs = gd.GetAlarmMonitorLogs(Convert.ToInt32(data["pageSize"]), Convert.ToInt32(data["pageIndex"]));
                    idata.Add("status", "Success");
                    idata.Add("value", AlarmLogs["data"]);
                    idata.Add("totalRows", AlarmLogs["Total"]);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
    }
}
