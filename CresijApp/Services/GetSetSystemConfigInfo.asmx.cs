using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
using System.Data;
using System.Security.Permissions;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for GetSetSystemConfigInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetSetSystemConfigInfo : WebService
    {
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetFloorClassByBuilding(string buildingName)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<object> idata = new List<object>();
            var cc = HttpContext.Current.Session;
            if (HttpContext.Current.Session["UserId"]== null || HttpContext.Current.Session.Count==0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("buildingName", buildingName);
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result.Add("buildingName", buildingName);
                    SystemInfo systemInfo = new SystemInfo();
                    DataTable dt = systemInfo.GetFloorClassByBuilding(buildingName);
                    result.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            List<ClassNamesList> cl = JsonConvert.DeserializeObject<List<ClassNamesList>>(dr["className"].ToString());
                            ClassFloorStructure fc = new ClassFloorStructure()
                            {
                                Floor = dr["floor"].ToString(),
                                ClassNames = cl
                            };                            
                            idata.Add(fc);
                        }
                        result.Add("value", idata);
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("buildingName", buildingName);
                    result.Add("errorMessage", ex.Message);
                }
            }            
            return result;
        }

        public class ClassFloorStructure
        {
            public string Floor { get; set; }
            public List<ClassNamesList> ClassNames { get; set; } 
        }
        public class ClassNamesList
        {
            public string Name;
            public string Id;
        }
        
        [WebMethod(EnableSession =true)]
        public Dictionary<string, object> GetFloorClassByBuildingForUserAccess(string buildingName)
        {
            string userid = "";
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["LoggedInUser"] == null || HttpContext.Current.Session.Count == 0)
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
                    if (Session["LoggedInUser"].ToString() != null)
                    {

                        userid = Session["LoggedInUser"].ToString();
                        result.Add("buildingName", buildingName);
                        SystemInfo systemInfo = new SystemInfo();
                        DataTable dt = systemInfo.GetFloorClassByBuildingUserAccess(buildingName, userid);
                        result.Add("status", "success");
                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                Dictionary<string, string> values = new Dictionary<string, string>();
                                values.Add("floor", dr["floor"].ToString());
                                values.Add("classNames", dr["className"].ToString());
                                idata.Add(values);
                            }
                            result.Add("value", idata);
                        }
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
                    result.Add("buildingName", buildingName);
                    result.Add("errorMessage", ex.Message);
                }
            }           
            return result;
        }
       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetIpByClass(string classlist)
        {
            List<string> idata = new List<string>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["LoggedInUser"] == null || HttpContext.Current.Session.Count == 0)
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
                    SystemInfo systemInfo = new SystemInfo();
                    DataTable dt = systemInfo.GetIpByClass(classlist);
                    result.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            idata.Add(dr["CCEquipIP"].ToString());
                        }
                        result.Add("value", idata);
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("errorMessage", ex.Message);
                }
            }            
            return result;
        }
    }
}
