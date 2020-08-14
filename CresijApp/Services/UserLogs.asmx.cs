using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Security;
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
        public Dictionary<string,object> Login(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Dictionary<string, object> idata1 = new Dictionary<string, object>();
            string loginid = "", password = "";

            loginid = data["loginID"].ToString();
            password = data["password"].ToString();

            UserLogsDataAccess userLogs = new UserLogsDataAccess();
            DataTable dt = userLogs.Login(loginid,password);
            if (dt.Rows.Count > 0)
            {
                
                idata.Add("status", "success");
                idata1.Add("loginID", dt.Rows[0]["loginid"]);
                idata1.Add("userName", dt.Rows[0]["username"]);
                idata1.Add("personType", dt.Rows[0]["persontype"]);
                idata1.Add("validTill", dt.Rows[0]["validtill"].ToString());
                idata1.Add("expireTime", dt.Rows[0]["expiretime"]);
                FormsAuthentication.SetAuthCookie(loginid, false);
                string ticket = FormsAuthentication.Encrypt(
                       new FormsAuthenticationTicket("userId", false, 15));
                HttpCookie FormsCookie = new HttpCookie(
                           FormsAuthentication.FormsCookieName, ticket)
                { HttpOnly = true };
                HttpContext.Current.Response.Cookies.Add(FormsCookie);
            }
            else
            {
                idata.Add("status", "fail");
            }
            idata.Add("value", idata1);
            return idata;
        }
        [PrincipalPermission(SecurityAction.Demand)]
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

        [PrincipalPermission(SecurityAction.Demand)]
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

        //[PrincipalPermission(SecurityAction.Demand)]
        //[WebMethod]
        //public Dictionary<string, string> Logout()
        //{
        //    Dictionary<string, string> idata = new Dictionary<string, string>();
        //    if (Context.User.Identity.IsAuthenticated == true)            
        //        idata.Add("logout", "true");
            
        //    else
        //        idata.Add("Authenticated", "false");
        //    return idata;
        //}
    }
}
