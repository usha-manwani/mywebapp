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

        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> Login(Dictionary<string, object> data)
        {            
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Dictionary<string, object> idata1 = new Dictionary<string, object>();
            try
            {
                string loginid = "", password = "";
                loginid = data["loginID"].ToString().Trim();
                password = data["password"].ToString();
                UserLogsDataAccess userLogs = new UserLogsDataAccess();
                DataTable dt = userLogs.Login(loginid, password);
                if (dt.Rows.Count > 0)
                {
                    idata.Add("status", "success");
                    idata1.Add("loginID", dt.Rows[0]["loginid"]);
                    idata1.Add("userName", dt.Rows[0]["username"]);
                    idata1.Add("personType", dt.Rows[0]["persontype"]);
                    idata1.Add("validTill", dt.Rows[0]["validtill"].ToString());
                    idata1.Add("expireTime", dt.Rows[0]["expiretime"]);
                    HttpContext.Current.Session["UserLoggedIn"] = loginid;
                    FormsAuthentication.SetAuthCookie(loginid, false);
                    string ticket = FormsAuthentication.Encrypt(
                           new FormsAuthenticationTicket("userId", false, 20));
                    HttpCookie FormsCookie = new HttpCookie("AuthToken", ticket)
                    { HttpOnly = true };
                    var t = Guid.NewGuid().ToString();
                    HttpContext.Current.Session["AuthToken"] = t;
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("AuthCookie", t));
                    HttpContext.Current.Response.Cookies.Add(FormsCookie);
                }
                else
                {
                    idata.Add("status", "fail");
                }
                idata.Add("value", idata1);
            }
            catch (Exception ex)
            {
                idata.Add("errorMessage ", ex.Message);
            }
            return idata;
        }
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetUserLogDetails()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["LoggedInUser"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                List<LogsList> idata = new List<LogsList>();
                try
                {
                    UserLogsDataAccess userLogs = new UserLogsDataAccess();
                    DataTable dt = userLogs.GetUserLogDetails();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            LogsList logsList = new LogsList()
                            {
                                UserId = dr["userid"].ToString(),
                                UserName = dr["Username"].ToString(),
                                Action = dr["action"].ToString(),
                                BuildingName = dr["building"].ToString(),
                                ClassName = dr["classroom"].ToString(),
                                Time = dr["time"].ToString()
                            };
                            idata.Add(logsList);
                        }
                        result.Add("status", "success");
                        result.Add("value", idata);
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");                    
                    result.Add("errorMessage", ex.Message);
                }
            }
           
            return result;
        }

        public class LogsList
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Action { get; set; }
            public string BuildingName { get; set; }
            public string ClassName { get; set; }
            public string Time { get; set; }
        }
        
        [WebMethod(EnableSession = true)]
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

        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> Logout()
        {
            Dictionary<string, string> idata = new Dictionary<string, string>();           
            if (HttpContext.Current.Session["AuthToken"].ToString().Equals(HttpContext.Current.Response.Cookies["AuthCookie"].Value))
            {
                idata.Add("mess", "cookie and session matched");
            }
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session["UserLoggedIn"] = null;
            HttpContext.Current.Session["AuthToken"] = null;            
            return idata;
        }

        public static void CheckSession()
        {
            var cc = HttpContext.Current.Session;
            var coo = HttpContext.Current.Response.Cookies["AuthToken"];
            if (cc.Count == 0)
            {
                HttpContext.Current.Response.Redirect("customerror.aspx");
            }
        }
    }
}
