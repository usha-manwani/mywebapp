using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for DeleteOrgData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class DeleteOrgData : WebService
    {        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteBuilding(string sno)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteOrg(Convert.ToInt32(sno)).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");
                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }            
            return keyValue;            
        }
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteTeacher(string id)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteTeacher(id).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
           
        }
       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteStudent(string id)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteStudent(id).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteClass(string id)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteClass(id).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteUser(string id)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteUser(id).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }
       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteFloor(string id)
        {
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DeleteOrgDetails del = new DeleteOrgDetails();
                    result = del.DeleteFloor(id).ToString();
                    if (Convert.ToInt32(result) >= 0)
                    {
                        keyValue.Add("status", "success");

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;

        }
    }
}
