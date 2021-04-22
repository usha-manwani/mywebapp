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
    /// This class deals with the deletion of Buildingdetails, floor details, userdetails, 
    /// classdetails,studentdetails ,teacherdetails
    /// </summary>
    [WebService(Namespace = "http://ipaddress/services/DeleteOrgData.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class DeleteOrgData : WebService
    {
        #region Web Methods
        /// <summary>
        /// Method to delete single or multiple row of Building details using its id
        /// </summary>
        /// <param name="data">The data.: list of building ids</param>
        /// <returns>Success/fail result</returns>
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
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
        /// <summary>
        /// Method to delete the single or multiple row of class details using ClassID
        /// </summary>
        /// <param name="data">The data.: list of class ids</param>
        /// <returns>success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleClass(List<string> data)
        {Dictionary<string, string> keyValue = new Dictionary<string, string>();
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
                    int result = dg.DeleteMultipleClass(data);
                    if (result >= 0)
                    {
                        keyValue.Add("status", "success");
                   //     keyValue.Add("Deleted Rows", result.ToString());
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
        /// <summary>
        /// Method to delete single or multiple row of user data by its Id
        /// </summary>
        /// <param name="data">The data.: list of user ids</param>
        /// <returns>Success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleUser(List<string> data)
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
                    int result = dg.DeleteMultipleUser(data);
                    if (result >= 0)
                    {
                        keyValue.Add("status", "success");
                        //keyValue.Add("Deleted Rows", result.ToString());
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

        /// <summary>
        /// Method to delete single or multiple row of floor data using floor Id
        /// </summary>
        /// <param name="data">The data.: list of floor ids</param>
        /// <returns>Success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> DeleteMultipleFloor(List<string> data)
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
                    int result = dg.DeleteMultipleFloor(data);
                    if (result >= 0)
                    {
                        keyValue.Add("status", "success");
                     //   keyValue.Add("Deleted Rows", result.ToString());
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
        /// <summary>
        /// Method to delete single or multiple row of teacher details by using teacher id
        /// </summary>
        /// <param name="data">The data.: list of teacher ids</param>
        /// <returns>Success/fail result with count of affected rows.</returns>
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
                    int result = dg.DeleteMultipleTeacher(data);
                    if (result >= 0)
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
        /// <summary>
        /// Method to delete single or multiple row of student details by passing the student id
        /// </summary>
        /// <param name="data">The data.: list of student ids</param>
        /// <returns>Success/fail result with count of affected rows.</returns>
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
                    DeleteOrgDetails dg = new DeleteOrgDetails(HttpContext.Current.Session["DBConnection"].ToString());
                    int result = dg.DeleteMultipleStudent(data);
                    if (result >= 0)
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
        #endregion
    }
}
