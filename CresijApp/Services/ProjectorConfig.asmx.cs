using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Services;
using System.Runtime.InteropServices;
using System.Text;
using CresijApp.Models;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for ProjectorConfig
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ProjectorConfig : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
       
        public Dictionary<string, object> GetProjectorBrand()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                var path = HttpContext.Current.Server.MapPath("~/Projector Type/") ;
                var dirs = Directory.GetDirectories(path);
                List<string> names = new List<string>();
                foreach(var r in dirs)
                {
                    names.Add(new DirectoryInfo(r).Name);
                }
                result.Add("status", "success");
                result.Add("total", names.Count);
                result.Add("names", names);

            }
            catch(Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorModel(string brand)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                var path = HttpContext.Current.Server.MapPath("~/Projector Type/" + brand);
                var dirs = Directory.GetFiles(path,"*.ini");
                
                List<string> names = new List<string>();
                foreach (var r in dirs)
                {
                    names.Add(new FileInfo(r).Name.Split('.')[0]);
                }
                result.Add("status", "success");
                result.Add("total", names.Count);
                result.Add("names", names);

            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorIniInfo(Dictionary<string,string> data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> result1 = new Dictionary<string, object>();
            try
            {
                var brand = data["Brand"].ToString();
                var model = data["Model"].ToString();
                var path = HttpContext.Current.Server.MapPath("~/Projector Type/" + brand+"/"+model+".ini");
                IniFile inf = new IniFile(path);
                result.Add("BaudRate",inf.IniReadValue("Option", "BaudRate"));
                result.Add("Parity", inf.IniReadValue("Option", "Parity"));
                result.Add("OpenCode", inf.IniReadValue("Option", "Open"));
                result.Add("CloseCode", inf.IniReadValue("Option", "Close"));
                result1.Add("status", "success");
                result1.Add("value", result);
            }
            catch (Exception ex)
            {
                result1.Add("status", "fail");
                result1.Add("Error", ex.Message);
            }
            return result1;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> SaveProjectorInfo(Dictionary<string, object> data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            int r = 0;
            try
            {
                var classids = ((object[])data["classids"]).Cast<int>().ToList();
                var brand = data["Brand"].ToString();
                var model = data["Model"].ToString();
                var baudrate = Convert.ToInt32(data["BaudRate"]);
                var parity = Convert.ToInt16(data["Parity"]);
                var opencode = data["OpenCode"].ToString();
                var closecode = data["CloseCode"].ToString();
                using(var context = new OrganisationdatabaseEntities())
                {
                    if (classids != null)
                    {
                        foreach (var id in classids)
                        {
                            var configrow = context.projectorconfiginfoes.Where(x => x.Classid == id).Select(x=>x).FirstOrDefault();
                            if (configrow != null)
                            {
                                configrow.BrandName = brand;
                                configrow.Model = model;
                                configrow.Baudrate = baudrate;
                                configrow.parity = parity;
                                configrow.OpenCode = opencode;
                                configrow.CloseCode = closecode;
                                
                            }
                            else
                            {
                                
                                var confignew = new projectorconfiginfo()
                                {
                                    BrandName = brand,
                                    Model = model,
                                    Baudrate = baudrate,
                                    parity = parity,
                                    OpenCode = opencode,
                                    CloseCode = closecode,
                                    Classid = id,
                                    status="Pending"
                                    
                                };
                                context.projectorconfiginfoes.Add(confignew);
                                
                            }
                            
                        }

                        r += context.SaveChanges();
                    }

                    
                    result.Add("UpdatedRows",r);
                }
                result.Add("status", "success");
            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorInfo(int classid)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                using (var context = new OrganisationdatabaseEntities())
                {
                    var row = context.projectorconfiginfoes.Where(x => x.Classid == classid)
                        .Select(x =>new  {BaudRate= x.Baudrate,Parity=x.parity,Brand=x.BrandName,
                            x.Model,x.OpenCode,x.CloseCode }).FirstOrDefault();
                    if (row != null)
                       
                        result.Add("value", row);
                }
                result.Add("status", "success");
            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }
            return result;
        }
    }
    
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
    }
}
