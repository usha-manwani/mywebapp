using CresijApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for GetSideMenu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetSideMenu : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]       
        public List<object> GetInstitute(string name)
        {
            GetMenuDataHelper tv = new GetMenuDataHelper();
            List<object> idata = new List<object>();
            DataTable dt = tv.GetInstitutes();
            List<string> insid = new List<string>();
            List<string> insname = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    insid.Add(dataRow[0].ToString());
                    insname.Add(dataRow[1].ToString());
                }

            }
            idata.Add(insid);
            idata.Add(insname);
            return idata;
        }

        [WebMethod]
        public List<object> GetGrades(string name)
        {
            GetMenuDataHelper tv = new GetMenuDataHelper();
            List<object> idata = new List<object>();
            DataTable dt = tv.GetGrades(name);
            List<string> gradeid = new List<string>();
            List<string> gradename = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    gradeid.Add(dataRow[0].ToString());
                    gradename.Add(dataRow[1].ToString());
                }
            }
            idata.Add(gradeid);
            idata.Add(gradename);
            return idata;
        }

        [WebMethod]
        public List<object> GetClasses(string name)
        {
            GetMenuDataHelper tv = new GetMenuDataHelper();
            List<object> idata = new List<object>();
            DataTable dt = tv.GetClasses(name);
            List<string> classid = new List<string>();
            List<string> classname = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    classid.Add(dataRow[0].ToString());
                    classname.Add(dataRow[1].ToString());
                }
            }
            idata.Add(classid);
            idata.Add(classname);
            return idata;
        }

        [WebMethod]
        public List<object> GetCamDetails(string name)
        {
            DataTable dt = new DataTable();
            CentralControl cc = new CentralControl();
            dt = cc.CamDetails(name);
            List<object> idata = new List<object>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List<object> list = new List<object>();
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        list.Add(dt.Rows[i][k].ToString());
                    }
                    idata.Add(list);

                }
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetApAdd(string name)
        {
            List<object> idata = new List<object>();
            CentralControl cc = new CentralControl();
            string ip = cc.GetIp(name);
            idata.Add(ip);
            return idata;
        }
    }
}
