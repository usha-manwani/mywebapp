using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using CresijApp.DataAccess;

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
                var sec = data["Sectionselected"];
                IEnumerable<Dictionary<string, object>> section = ((IEnumerable)sec).Cast<object>().ToList().Select(item => (Dictionary<string, object>)item);
                List<SectionList> sectionlist = new List<SectionList>();
                foreach (Dictionary<string,object> dr in section)
                {
                    var test = GetObject<SectionList>(dr);
                    sectionlist.Add(test);
                }
                
                var d = data["Dayselected"];
                List<string> strings = ((IEnumerable)d).Cast<object>().ToList().Select(s => (string)s).ToList();
                string schoolname = data["Schoolname"].ToString();
                string schooleng = data["Schooleng"].ToString();
                string logourl = data["Logourl"].ToString();
                string semname = data["Semestername"].ToString();
                string semno = data["Semesterno"].ToString();
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
                result= cc.SaveSystemInfo(schoolname, schooleng, logourl,semname,semweeks, semstartdate, allowedDays,semno);
                if (result > 0)
                {
                  result=  cc.SaveReserveAndTransferInfo("Reserve", data["Resnonwork"].ToString(), data["Resauto"].ToString(), data["Resstartdate"].ToString(),
                        data["Resstopdate"].ToString(), semname);

                    result=cc.SaveReserveAndTransferInfo("Transfer", data["Transfernonwork"].ToString(), data["Transferauto"].ToString(),
                        data["Transferstart"].ToString(), data["Transferstop"].ToString(), semname);

                    foreach(SectionList s in sectionlist)
                    {
                        cc.SaveSectionsInfo(semname, s.Section, s.Starttime, s.Stoptime);
                    }                    
                }
            }
           catch(Exception ex)
            {

            }
            return result.ToString();
        }

        T GetObject<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }

        
    }

    public class SectionList
    {
        public string Section { get; set; }
        public string Starttime { get; set; }
        public string Stoptime { get; set; }
    }

    
}
