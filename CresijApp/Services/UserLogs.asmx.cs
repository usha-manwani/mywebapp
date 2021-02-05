﻿using System;
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
                    idata1.Add("startDate", dt.Rows[0]["startdate"].ToString());
                    idata1.Add("expireDate", dt.Rows[0]["expiredate"].ToString());
                    HttpContext.Current.Session["UserLoggedIn"] = loginid;
                    FormsAuthentication.SetAuthCookie(loginid, false);
                    string ticket = FormsAuthentication.Encrypt(
                           new FormsAuthenticationTicket("userId", false, 30));
                    HttpCookie FormsCookie = new HttpCookie("AuthToken", ticket)
                    { HttpOnly = true };
                    var t = Guid.NewGuid().ToString();
                    HttpContext.Current.Session["AuthToken"] = t;
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("AuthCookie", t));
                    HttpContext.Current.Response.Cookies.Add(FormsCookie);
                    using(var context = new OrganisationdatabaseEntities())
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
                idata.Add("errorMessage ", ex.Message);
            }
            return idata;
        }
        
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
                HttpContext.Current.Session.Timeout = 10;
                var pageIndex = Convert.ToInt32(data["pageIndex"]);
                var pageSize = Convert.ToInt32(data["pageSize"]);
                List<LogsList> idata = new List<LogsList>();
                try
                {

                    UserLogsDataAccess userLogs = new UserLogsDataAccess();
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

        public class LogsList
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Action { get; set; }
            public string BuildingName { get; set; }
            public string ClassName { get; set; }
            public string ActionTime { get; set; }
        }
        
        public class ClassLogs
        {
            public string UserName { get; set; }
            public string Action { get; set; }
            public string ActionTime { get; set; }
            public int ClassId { get; set; }
            public string ClassName { get; set; }
        }
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
                UserLogsDataAccess userLogs = new UserLogsDataAccess();
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

        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> Logout(string cookie)
        {
            int r = 0;
            Dictionary<string, string> idata = new Dictionary<string, string>();

            //if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            //{
            //    HttpContext.Current.Session.Abandon();
            //    idata.Add("status", "fail");
            //    idata.Add("errorMessage", "Session Expired");
            //    idata.Add("customErrorCode", "440");
            //}
            //else
            //{
            try
            {
                var loginid = "";
                using (var context = new OrganisationdatabaseEntities())
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
                HttpContext.Current.Session.Remove("AuthToken");
                HttpContext.Current.Session.Remove("AuthCookie");
                HttpContext.Current.Session.RemoveAll();
                idata.Add("status", "success");
                idata.Add("message", "Successfully Logout");
            }
            //}
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
                HttpContext.Current.Session.Timeout = 10;
                int classid = Convert.ToInt32(id);
                List<LogsList> idata = new List<LogsList>();
                try
                {
                    using(var context = new OrganisationdatabaseEntities())
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
                                    }).Union((from a in context.machineoperationlogs
                                             join b in context.classdetails on a.Location equals b.classID
                                             orderby a.ExecutionTime descending where b.classID==classid 
                                             && !a.Operation.Contains("NoData") && !a.Type.Contains("MacAddress")
                                             && !a.Type.Contains("ControlExecution") && !a.Type.Contains("PowerControl")
                        select new {a.ExecutionTime,a.Operation,
                                                 a.Type,a.Location,b.ClassName }).Take(100).AsEnumerable()
                                                 .Select(y=>new ClassLogs { Action=y.Operation.ToString(),
                                                     ActionTime =y.ExecutionTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                                 UserName=y.Type, ClassId=y.Location,ClassName=y.ClassName})).OrderByDescending(x=>x.ActionTime).Take(100).ToList();
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
    }
}
