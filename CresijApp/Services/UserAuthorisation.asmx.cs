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
    /// This class contains methods and structure to deal with
    /// user permissions for menu options and location accesses.
    /// CRUD Operations is done on the Permissions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserAuthorisation : System.Web.Services.WebService
    {
        #region Web Methods
        /// <summary>
        /// Method to save or update user's permissions for menu usage and location access
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success/fail result</returns>
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
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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
        
        /// <summary>
        /// Method to get Top Menu accessed by user
        /// </summary>
        /// <returns>list of top menu</returns>
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
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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
        
        /// <summary>
        /// Method to get submenu by a topmenu and specific to user in session.         
        /// </summary>
        /// <param name="subMenuType"></param>
        /// <returns></returns>
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
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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

        /// <summary>
        /// Method to get submenu specific to user in session. 
        /// Submenu are the options inside a top menu.
        /// Eg: Schedule managment is a top menu. Then Transfer and appointment schedule tabs are sub menu
        /// </summary>
        /// <returns>list of submenu</returns>
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
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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
        
        /// <summary>
        /// Method to get all the location names specific to current user in session
        /// </summary>
        /// <returns>list of locations</returns>
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
                        DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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
        /// <summary>
        /// Method to get the list of all submenus specific to user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>user specific list of submenus </returns>
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
                    DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
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

        /// <summary>
        /// Method to get all the location names specific to the user id in the parameter input
        /// </summary>
        /// <param name="userid"></param>
        /// <returns> user specific list of locations</returns>
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
                    DataAccess.UserAuth userAuth = new DataAccess.UserAuth(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = new DataTable();
                    dt = userAuth.GetUserAllLocationAccess(userid);
                    result.Add("status", "sucess");
                    if (dt.Rows.Count > 0)
                    {
                        
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
        #endregion
    }
}
