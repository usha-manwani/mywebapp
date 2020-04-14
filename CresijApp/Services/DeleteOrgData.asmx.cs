using System;
using System.Collections.Generic;
using System.Linq;
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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string DeleteOrg(string sno)
        {
            string result = "";
            DeleteOrgDetails del = new DeleteOrgDetails();
            result = del.DeleteOrg(Convert.ToInt32(sno)).ToString();
            return result;
        }

        [WebMethod]
        public string DeleteTeacher(string id)
        {
            string result = "";
            DeleteOrgDetails del = new DeleteOrgDetails();
            result = del.DeleteTeacher(id).ToString();
            return result;
        }
        [WebMethod]
        public string DeleteStudent(string id)
        {
            string result = "";
            DeleteOrgDetails del = new DeleteOrgDetails();
            result = del.DeleteStudent(id).ToString();
            return result;
        }

        [WebMethod]
        public string DeleteClass(string id)
        {
            string result = "";
            DeleteOrgDetails del = new DeleteOrgDetails();
            result = del.DeleteClass(id).ToString();
            return result;
        }

        [WebMethod]
        public string DeleteUser(string id)
        {
            string result = "";
            DeleteOrgDetails del = new DeleteOrgDetails();
            result = del.DeleteUser(id).ToString();
            return result;
        }
    }
}
