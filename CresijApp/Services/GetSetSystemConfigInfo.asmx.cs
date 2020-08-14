using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
using System.Data;
using System.Security.Permissions;

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
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string,object> GetFloorClassByBuilding(string buildingName)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<object> idata = new List<object>();
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
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        values.Add("floor",dr["floor"].ToString());
                        values.Add("classNames", dr["className"].ToString());
                        idata.Add(values);
                    }
                    result.Add("value", idata);
                }
            }
          catch(Exception ex)
            {
                result.Add("status", "fail");
                result.Add("buildingName", buildingName);
                result.Add("error", ex.Message);
            }
            return result;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetFloorClassByBuildingForUserAccess(Dictionary<string, string> data)
        {
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                result.Add("buildingName",data["buildingName"]);
                SystemInfo systemInfo = new SystemInfo();
                DataTable dt = systemInfo.GetFloorClassByBuildingUserAccess(data["buildingName"], data["userId"]);
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
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("buildingName", data["buildingName"]);
                result.Add("error", ex.Message);
            }
            return result;
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetIpByClass(string classlist)
        {
            List<string> idata = new List<string>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                //idata.Add(building);
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
               
                result.Add("error", ex.Message);
            }
            return result;
        }
    }
}
