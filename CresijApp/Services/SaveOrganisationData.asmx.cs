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
    /// Summary description for SaveOrganisationData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class SaveOrganisationData : WebService
    {
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveBuildingData(Dictionary<string,string> data)
        {            
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveOrgDataBuilding(data).ToString();
                   
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
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
        public Dictionary<string, string> SaveFloorData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveOrgDataFloor(data).ToString();
                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
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
        public Dictionary<string, string> UpdateBuildingData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateOrgData(data).ToString();
                    
                        keyValue.Add("status", "success");
                        keyValue.Add("UpdatedRows", result);
                   
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
        public Dictionary<string, string> SaveTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveTeacherData(data).ToString();
                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
                    
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
        public Dictionary<string, string> UpdateTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateTeacherData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);

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
        public Dictionary<string, string> SaveStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveStudentData(data).ToString();
                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
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
        public Dictionary<string, string> UpdateStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateStudentData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);

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
        public Dictionary<string, string> SaveClassData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveClassData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);

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
        public Dictionary<string, string> UpdateClassData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateClassData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);
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
        public Dictionary<string, string> AddUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.SaveUserData(data).ToString();                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
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
        public Dictionary<string, string> UpdateUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateUserData(data).ToString();
                   
                        keyValue.Add("status", "success");
                        keyValue.Add("UpdatedRows", result);
                    
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
        public Dictionary<string, string> UpdateFloorData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
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
                    result = orgData.UpdateFloorData(data).ToString();
                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);
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
