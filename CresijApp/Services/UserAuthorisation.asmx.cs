using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for UserAuthorisation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserAuthorisation : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveUserAuthentications(Dictionary<string, object> data)
        {
            string adminid = "";
            Dictionary<string, string> idata = new Dictionary<string, string>();
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
                    if (Session["UserLoggedIn"].ToString() != null)
                    {
                        adminid = Session["UserLoggedIn"].ToString();
                        string[] authmenu = data["AuthMenu"].ToString().Split(',');
                        string[] authloc = data["classNames"].ToString().Split(',');
                       
                        var userid = data["personId"].ToString();
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                        int r = userAuth.DeleteUserPermissions(userid);
                        int result = userAuth.SaveAuthMenu(authmenu, userid, adminid, authloc);
                        if (result < 0)
                            idata.Add("status", "fail");
                        else
                            idata.Add("status", "success");
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("error", ex.Message);
                }
            }
            return idata;
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetUserTopMenu()
        {
            string userid = "";
            List<string> idata = new List<string>();
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
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {

                        userid = Session["UserLoggedIn"].ToString();
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                        DataTable dt = new DataTable();
                        dt = userAuth.GetUserTopMenu(userid);
                        if (dt.Rows.Count > 0)
                        {
                            result.Add("status", "sucess");
                            foreach (DataRow dr in dt.Rows)
                            {
                                idata.Add(dr["rolenames"].ToString());
                            }
                        }
                        result.Add("TopMenu", idata);
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        result.Add("status", "fail");
                        result.Add("errorMessage", "Session Expired");
                        result.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserSubMenu(string subMenuType)
        {
            List<object> idata = new List<object>();
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
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {
                        string userid = Session["UserLoggedIn"].ToString();
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                        DataTable dt = new DataTable();
                        dt = userAuth.GetUserSubMenu(subMenuType, userid);
                        if (dt.Rows.Count > 0)
                        {
                            result.Add("status", "sucess");
                            foreach (DataRow dr in dt.Rows)
                            {
                                idata.Add(dr["rolenames"].ToString());
                            }
                        }
                        result.Add("SubMenu", idata);
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        result.Add("status", "fail");
                        result.Add("errorMessage", "Session Expired");
                        result.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;            
        }

       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserAllSubMenu()
        {
            string userid = "";
            List<object> idata = new List<object>();
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
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {
                        userid = Session["UserLoggedIn"].ToString();
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                        DataTable dt = new DataTable();
                        dt = userAuth.GetUserAllSubMenu(userid);
                        if (dt.Rows.Count > 0)
                        {
                            result.Add("status", "sucess");
                            foreach (DataRow dr in dt.Rows)
                            {
                                idata.Add(dr["roleid"].ToString());
                            }
                        }
                        result.Add("SubMenuId", idata);
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        result.Add("status", "fail");
                        result.Add("errorMessage", "Session Expired");
                        result.Add("customErrorCode", "440");
                    }

                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;           
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserAllLocationAccess()
        {
            List<object> idata = new List<object>();
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
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {

                        string userid = Session["UserLoggedIn"].ToString();
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                        DataTable dt = new DataTable();
                        dt = userAuth.GetUserAllLocationAccess(userid);
                        if (dt.Rows.Count > 0)
                        {
                            result.Add("status", "sucess");
                            foreach (DataRow dr in dt.Rows)
                            {
                                idata.Add(dr["className"].ToString());
                            }
                        }
                        result.Add("ClassNameList", idata);
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        result.Add("status", "fail");
                        result.Add("errorMessage", "Session Expired");
                        result.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;
            
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserPermissions(string userid)
        {
            List<object> idata = new List<object>();
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
                try
                {
                    DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                    DataTable dt = new DataTable();
                    dt = userAuth.GetUserAllSubMenu(userid);
                    if (dt.Rows.Count > 0)
                    {
                        result.Add("status", "sucess");
                        foreach (DataRow dr in dt.Rows)
                        {
                            idata.Add(dr["roleid"].ToString());
                        }
                    }
                    result.Add("SubMenuId", idata);
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;
        }

       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserLocationPermissions(string userid)
        {
            List<object> idata = new List<object>();
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
                try
                {
                    DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                    DataTable dt = new DataTable();
                    dt = userAuth.GetUserAllLocationAccess(userid);
                    if (dt.Rows.Count > 0)
                    {
                        result.Add("status", "sucess");
                        foreach (DataRow dr in dt.Rows)
                        {
                            idata.Add(dr["className"].ToString());
                        }
                    }
                    result.Add("ClassNameList", idata);
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("error", ex.Message);
                }
            }
            return result;

        }
    }
}
