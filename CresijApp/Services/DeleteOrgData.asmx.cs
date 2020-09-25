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
            int result = 0;
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
                    result = del.DeleteOrg(Convert.ToInt32(sno));
                    if (result>= 0)
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
            int result = 0; ;
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
                    result = del.DeleteTeacher(id);
                    if (Convert.ToInt32(result) > 0)
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
            int result = 0;
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
                    result = del.DeleteStudent(id);
                    if (result > 0)
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
            int result=-1;
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
                    result = del.DeleteClass(Convert.ToInt32(id));
                    if (result > 0)
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
            int result = 0;
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
                    result = del.DeleteUser(id);
                    if (result > 0)
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
            int result = 0;
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
                    result = del.DeleteFloor(Convert.ToInt32(id));
                    if (result > 0)
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

        [WebMethod(EnableSession =true)]
        public Dictionary<string,string> DeleteMultipleBuilding(List<string> data)
        {
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
                    DeleteOrgDetails dg = new DeleteOrgDetails();
                    int result = dg.DeleteMultipleBuilding(data);
                    if (result >= 0)
                    {
                        keyValue.Add("status", "success");
                       // keyValue.Add("Deleted Rows", result.ToString());
                    }
                    else
                    {
                        keyValue.Add("status", "fail");
                        keyValue.Add("errorMessage", result.ToString());

                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("errorMessage", ex.Message);
                }
            }
            return keyValue;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleClass(List<string> data)
        {
            Dictionary<string, string> idata = new Dictionary<string, string>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return idata;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleUser(List<string> data)
        {
            Dictionary<string, string> idata = new Dictionary<string, string>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return idata;
        }
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleFloor(List<string> data)
        {
            Dictionary<string, string> idata = new Dictionary<string, string>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return idata;
        }
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleTeacherData(List<string> data)
        {
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
                    DeleteOrgDetails dg = new DeleteOrgDetails();
                    int result = dg.DeleteMultipleTeacher(data);
                    if (result > 0)
                    {
                        keyValue.Add("status", "success");
                        keyValue.Add("Deleted Rows", result.ToString());
                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("errorMessage", ex.Message);
                }
            }
            return keyValue;
        }
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleStudentData(List<string> data)
        {
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
                    DeleteOrgDetails dg = new DeleteOrgDetails();
                    int result = dg.DeleteMultipleStudent(data);
                    if (result > 0)
                    {
                        keyValue.Add("status", "success");
                        keyValue.Add("Deleted Rows", result.ToString());
                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("errorMessage", ex.Message);
                }
            }
            return keyValue;
        }
    }
}
