using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SaveOrgDataBuilding(string[] org)
        {            
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveOrgDataBuilding(org).ToString();
            return result;
        }
        [WebMethod]
        public string SaveOrgDataFloor(string[] org)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveOrgDataFloor(org).ToString();
            return result;
        }

        [WebMethod]
        public string UpdateOrgData(string[] org)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.UpdateOrgData(org).ToString();
            return result;
        }

        [WebMethod]
        public string SaveTeacherData(string[] teacher)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveTeacherData(teacher).ToString();
            return result;
        }

        [WebMethod]
        public string UpdateTeacherData(string[] teacher)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.UpdateTeacherData(teacher).ToString();
            return result;
        }

        [WebMethod]
        public string SaveStudentData(string[] student)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveStudentData(student).ToString();
            return result;
        }

        [WebMethod]
        public string UpdateStudentData(string[] student)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.UpdateStudentData(student).ToString();
            return result;
        }
        [WebMethod]
        public string SaveClassData(string[] classdata)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveClassData(classdata).ToString();
            return result;
        }

        [WebMethod]
        public string UpdateClassData(string[] classdata)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.UpdateClassData(classdata).ToString();
            return result;
        }

        [WebMethod]
        public string AddUserData(string[] userdata)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.SaveUserData(userdata).ToString();
            return result;
        }

        [WebMethod]
        public string UpdateUserData(string[] userdata)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData();
            result = orgData.UpdateUserData(userdata).ToString();
            return result;
        }
    }
}
