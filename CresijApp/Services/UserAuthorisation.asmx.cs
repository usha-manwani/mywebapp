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

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public List<object> GetUserAuthentications()
        {
            List<object> idata = new List<object>();
            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveUserAuthentications(Dictionary<string, object> data)
        {
            Dictionary<string, string> idata = new Dictionary<string, string>();
            try
            {
                string[] authmenu = data["AuthMenu"].ToString().Split(',');
                string[] authloc = data["classnames"].ToString().Split(',');
                var adminid = data["adminId"].ToString();
                var userid = data["personid"].ToString();
                DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                userAuth.DeleteUserPermissions(userid);
                int result = userAuth.SaveAuthMenu(authmenu, userid, adminid, authloc);
                idata.Add("status", "success");
            }
            catch(Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("error", ex.Message);
            }

            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string,object> GetUserTopMenu(string userid)
        {
            List<string> idata = new List<string>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
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
            catch(Exception ex)
            {
                result.Add("status", "fail");
                result.Add("error", ex.Message);
            }
            return result;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetUserSubMenu(Dictionary<string, object> data)
        {
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
                DataTable dt = new DataTable();
                dt = userAuth.GetUserSubMenu(data);
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
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("error", ex.Message);
            }
            return result;            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetUserAllSubMenu(string userid)
        {
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
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
            return result;
           
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetUserAllLocationAccess(string userid)
        {
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
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
            return result;
            
        }

    }
}
