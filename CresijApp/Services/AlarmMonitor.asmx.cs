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
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AlarmMonitor : System.Web.Services.WebService
    {

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
                    GetOrgData gd = new GetOrgData();
                    var data1 = gd.GetDesktopEventLogs(Convert.ToInt32(data["pageSize"]), Convert.ToInt32(data["pageIndex"]));
                    idata.Add("status", "Success");
                    idata.Add("value", data1["data"]);
                    idata.Add("totalRows", data1["Total"]);
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
