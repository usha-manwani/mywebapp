using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Services;
using System.Runtime.InteropServices;
using System.Text;

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
            try
            {
                var brand = data["brand"].ToString();
                var model = data["model"].ToString();
                var path = HttpContext.Current.Server.MapPath("~/Projector Type/" + brand+"/"+model+".ini");
                IniFile inf = new IniFile(path);
                result.Add("baudRate",inf.IniReadValue("Option", "BaudRate"));
                result.Add("parity", inf.IniReadValue("Option", "Parity"));
                result.Add("ProjectorOpen", inf.IniReadValue("Option", "Open"));
                result.Add("ProjectorClose", inf.IniReadValue("Option", "Close"));
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
