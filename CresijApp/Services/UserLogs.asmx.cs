using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using CresijApp.DataAccess;
using CresijApp.Models;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for UserLogs
    /// This class contains web methods for User login,user logout,
    /// Get User Logs list,Get ClassLogs list(machine logs)
    /// </summary>
    [WebService(Namespace = "http://ipaddress/services/UserLogs.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserLogs : System.Web.Services.WebService
    {
        #region Web Methods
        /// <summary>
        /// Method to login the user with id, password and database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>user details of logged in user with success/fail result</returns>
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
                var campus = "Organisationdatabase";
                if (data.ContainsKey("connectTo"))
                {
                    campus = data["connectTo"].ToString();
                }
                UserLogsDataAccess userLogs = new UserLogsDataAccess(campus);
                DataTable dt = userLogs.Login(loginid, password);
                if (dt.Rows.Count > 0)
                {
                    idata.Add("status", "success");
                    idata1.Add("loginID", dt.Rows[0]["loginid"]);
                    idata1.Add("userName", dt.Rows[0]["username"]);
                    idata1.Add("personType", dt.Rows[0]["persontype"]);
                    idata1.Add("startDate", dt.Rows[0]["startdate"].ToString());
                    idata1.Add("expireDate", dt.Rows[0]["expiredate"].ToString());
                    HttpContext.Current.Session["UserLoggedIn"] = loginid;
                    HttpContext.Current.Session["DBConnection"] = campus;
                    FormsAuthentication.SetAuthCookie(loginid, false);
                    string ticket = FormsAuthentication.Encrypt(
                           new FormsAuthenticationTicket("userId", false, 90));
                    HttpCookie FormsCookie = new HttpCookie("AuthToken", ticket)
                    { HttpOnly = true };
                    var t = Guid.NewGuid().ToString();
                    HttpContext.Current.Session["AuthToken"] = t;
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("AuthCookie", t));
                    HttpContext.Current.Response.Cookies.Add(FormsCookie);
                    using(var context = new OrganisationdatabaseEntities(campus+"Entities"))
                    {
                        usersessioninfo ss = new usersessioninfo() {
                            LoginID = dt.Rows[0]["loginid"].ToString(),
                            SessionId = t,
                            SessionStartTime = DateTime.Now
                        };
                        context.usersessioninfoes.Add(ss);
                        context.SaveChangesAsync();
                    }
                }
                else
                {
                    idata.Add("status", "fail");
                }
                idata.Add("value", idata1);
            }
            catch (Exception ex)
            {
                idata.Add("errorMessage ", ex.Message +" inner exception: "+ex.InnerException+ "stack trace: "+ ex.StackTrace);
            }
            return idata;
        }
        
        /// <summary>
        /// Method to get logs for user operations
        /// </summary>
        /// <param name="data"></param>
        /// <returns>List of user logs with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetUserLogDetails(Dictionary<string,string>data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {                
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {               
                HttpContext.Current.Session.Timeout = 20;
                var db= HttpContext.Current.Session["DBConnection"].ToString();
                var pageIndex = Convert.ToInt32(data["pageIndex"]);
                var pageSize = Convert.ToInt32(data["pageSize"]);
                List<LogsList> idata = new List<LogsList>();
                try
                {
                    UserLogsDataAccess userLogs = new UserLogsDataAccess(db);
                    var res = userLogs.GetUserLogDetails(pageIndex.ToString(), pageSize.ToString());
                    var dt = res[0] as DataTable;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            LogsList logsList = new LogsList()
                            {
                                UserId = dr["loginid"].ToString(),
                                UserName = dr["Username"].ToString(),
                                Action = dr["action"].ToString(),
                                BuildingName = dr["building"].ToString(),
                                ClassName = dr["classroom"].ToString(),
                                ActionTime = Convert.ToDateTime(dr["Actiontime"]).ToString("yyyy-MM-dd HH:mm:ss")
                            };
                            idata.Add(logsList);
                        }
                        result.Add("status", "success");
                        result.Add("TotalRows", Convert.ToInt32(res[1]));
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

       /// <summary>
       /// method to Get count of logs group by type of actions
       /// </summary>
       /// <returns>list of type of action with its count</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetLogGraphData()
        {
            Dictionary<string,string> idata = new Dictionary<string, string>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                var db = HttpContext.Current.Session["DBConnection"].ToString();
                UserLogsDataAccess userLogs = new UserLogsDataAccess(db);
                DataTable dt = userLogs.GetLogDetails();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                        idata.Add(
                            dr["action"].ToString(), dr["Count"].ToString());
                }
            }
            result.Add("status", "success");
            result.Add("value", idata);
            return result;
        }

        /// <summary>
        /// Method to logout the user from website
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns>success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> Logout(string cookie)
        {
            int r = 0;
            Dictionary<string, string> idata = new Dictionary<string, string>();
            try
            {
                var loginid = "";
                var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                using (var context = new OrganisationdatabaseEntities(db))
                {
                    //var cookiesid = HttpContext.Current.Request.Cookies["AuthCookie"].Value ;
                    if (context.usersessioninfoes.Any(x => x.SessionId == cookie))
                    {
                        var us = context.usersessioninfoes.Where(x => x.SessionId == cookie).FirstOrDefault();
                        us.SessionEndTime = DateTime.Now;
                        loginid = us.LoginID;

                    }
                    var serialnum = context.userdetails.Where(x => x.LoginID == loginid).Select(x => x.SerialNo).FirstOrDefault();
                    userlog uslog = new userlog() {
                        Userid = serialnum,
                        action = "Logout",
                        ActionTime = DateTime.Now
                    };
                    context.userlogs.Add(uslog);
                    r = context.SaveChanges();
                    idata.Add("AffectedRows", r.ToString());
                    HttpContext.Current.Session.Abandon();
                }
            }
            finally
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Request.Cookies.Remove("AuthCookie");
                HttpContext.Current.Request.Cookies.Remove("AuthToken");
                HttpContext.Current.Session.Remove("UserLoggedIn");
                HttpContext.Current.Session.Remove("DBConnection");
                HttpContext.Current.Session.Remove("AuthToken");
                HttpContext.Current.Session.Remove("AuthCookie");
                HttpContext.Current.Session.RemoveAll();
                idata.Add("status", "success");
                idata.Add("message", "Successfully Logout");
            }
            //}
            return idata;
        }
       
        /// <summary>
        /// Method to get class logs (machine logs) for the last 7 days of a specific class
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of class logs</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetClassLogs(string id)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                var db = HttpContext.Current.Session["DBConnection"].ToString() +"Entities";
                HttpContext.Current.Session.Timeout = 10;
                int classid = Convert.ToInt32(id);
                List<LogsList> idata = new List<LogsList>();
                try
                {
                    using(var context = new OrganisationdatabaseEntities(db))
                    {
                        var data = (from p in context.userlogs
                                    join e in context.userdetails on p.Userid equals e.SerialNo
                                    join c in context.classdetails on p.ClassID equals c.classID
                                     orderby p.ActionTime descending where p.ClassID == classid
                                    select new {
                                        p.ActionTime,p.action,e.UserName,p.ClassID,c.ClassName
                                    }).Take(100).AsEnumerable().Select(x=>new ClassLogs {
                                        Action=x.action,ActionTime=x.ActionTime.ToString("yyyy-MM-dd HH:mm:ss"),UserName=x.UserName,
                                        ClassId=x.ClassID,ClassName=x.ClassName
                                    })
                                    .Union((from a in context.machineoperationlogs
                                             join b in context.classdetails on a.Location equals b.classID                                               
                                             orderby a.ExecutionTime descending where b.classID==classid 
                                             && !a.Operation.Contains("NoData") && !a.Type.Contains("MacAddress")
                                             && !a.Type.Contains("ControlExecution") && !a.Type.Contains("PowerControl") &&
                                             !a.Type.Contains("ReadConfig")  && !a.Type.Contains("SetConfig") 
                                            select new {a.ExecutionTime,a.Operation,
                                                 a.Type,a.Location,b.ClassName }).Take(100).AsEnumerable()
                                                 .Select(y=>new ClassLogs { Action=y.Operation.ToString(),
                                                     ActionTime =y.ExecutionTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                                 UserName=y.Type, ClassId=y.Location,ClassName=y.ClassName})).
                                                 OrderByDescending(x=>x.ActionTime).Take(100).ToList();
                        foreach(var x in data)
                        {
                            if (x.UserName.Contains("ReaderLog"))
                            {
                                var tname = context.teacherdatas.Where(y => y.onecard == x.Action).Select(z => z.TeacherName).FirstOrDefault();
                                if (!string.IsNullOrEmpty(tname))
                                {                             
                                    x.Action= x.UserName;
                                    x.UserName = tname;
                                }
                            }
                        }
                        result.Add("data", data);
                        result.Add("TotalRows", data.Count());
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
        #endregion
        #region Internal Methods
        /// <summary>
        /// method to check if the current request session is still active
        /// </summary>
        static void CheckSession()
        {
            var cc = HttpContext.Current.Session;
            var coo = HttpContext.Current.Response.Cookies["AuthToken"];
            if (cc.Count == 0)
            {
                HttpContext.Current.Response.Redirect("customerror.aspx");
            }
        }
        #endregion
    }
    #region Data Structure for Response
    /// <summary>
    /// Structure for User Logs
    /// </summary>
    public class LogsList
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string BuildingName { get; set; }
        public string ClassName { get; set; }
        public string ActionTime { get; set; }
    }

    /// <summary>
    /// structure for Class logs(Machine operation logs)
    /// </summary>
    public class ClassLogs
    {
        public string UserName { get; set; }
        public string Action { get; set; }
        public string ActionTime { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
    #endregion
}
