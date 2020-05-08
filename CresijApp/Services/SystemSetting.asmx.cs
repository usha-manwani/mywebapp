using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for SystemSetting
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [ScriptService]
    public class SystemSetting : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string SaveSystemInfo(Dictionary<string,object> data)
        {
            int result = 0;
            try
            {
                var d = data["Dayselected"];
               // List<object> result = ((IEnumerable)d).Cast<object>().ToList();
                List<string> strings = ((IEnumerable)d).Cast<object>().ToList().Select(s => (string)s).ToList();
                string schoolname = data["Schoolname"].ToString();
                string schooleng = data["Schooleng"].ToString();
                string logourl = data["Logourl"].ToString();
                string semname = data["Semestername"].ToString();
                string semweeks = data["Weeks"].ToString();
                string semstartdate = data["Semesterstart"].ToString();
                List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                Dictionary<string,string> allowedDays = new Dictionary<string, string>();
                foreach(string s in days)
                {
                    if (strings.Contains(s))
                    {
                        allowedDays.Add(s, "Yes");
                    }
                    else { allowedDays.Add(s, "No"); }
                }
                DataAccess.SystemInfo cc = new DataAccess.SystemInfo();
                result= cc.SaveSystemInfo(schoolname, schooleng, logourl,semname,semweeks, semstartdate, allowedDays);
                if (result > 0)
                {
                  result=  cc.SaveReserveAndTransferInfo("Reserve", data["Resnonwork"].ToString(), data["Resauto"].ToString(), data["Resstartdate"].ToString(),
                        data["Resstopdate"].ToString(), semname);

                    result=cc.SaveReserveAndTransferInfo("Transfer", data["Transfernonwork"].ToString(), data["Transferauto"].ToString(),
                        data["Transferstart"].ToString(), data["Transferstop"].ToString(), semname);

                }
            }
           catch(Exception ex)
            {

            }
            return result.ToString();
        }        
    }

}
