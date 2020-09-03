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
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveBuildingData(Dictionary<string,string> data)
        {            
            string result = "";
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            SetOrgData orgData = new SetOrgData();
            try
            {
                result = orgData.SaveOrgDataBuilding(data).ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch(Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveFloorData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.SaveOrgDataFloor(data).ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
           
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateBuildingData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateOrgData(data).ToString();
                if (Convert.ToInt32(result) >= 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.SaveTeacherData(data).ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateTeacherData(data).ToString();
                if (Convert.ToInt32(result) >= 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;           
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.SaveStudentData(data).ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateStudentData(data).ToString();
                if (Convert.ToInt32(result) >= 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
            
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> SaveClassData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.SaveClassData(data).ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateClassData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateClassData(data).ToString();
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
            return keyValue;
            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> AddUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.SaveUserData(data).ToString();
                if (Convert.ToInt32(result) >= 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
           
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateUserData(data).ToString();
                if (Convert.ToInt32(result) >= 0)
                {
                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
            }
            catch (Exception ex)
            {
                keyValue.Add("status", "fail");
                keyValue.Add("exception", ex.Message);
            }
            return keyValue;
            
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, string> UpdateFloorData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            try
            {
                result = orgData.UpdateFloorData(data).ToString();
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
            return keyValue;

        }
    }
}
