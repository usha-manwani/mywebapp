using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Services;
using System.Runtime.InteropServices;
using System.Text;
using CresijApp.Models;
using Microsoft.AspNet.SignalR;
using IniFile;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for ProjectorConfig
    /// The class is used to work with projector configuration
    /// </summary>
    [WebService(Namespace = "http://ipaddress/services/ProjectorConfig.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ProjectorConfig : System.Web.Services.WebService
    {
        /// <summary>
        /// signalR Context Object
        /// </summary>
        IHubContext hubContext;
        /// <summary>
        ///Method to get projector Brand names list from "Projector Type" folder inside applications folder
        /// </summary>
        /// <returns>list of projector Brand names</returns>
        [WebMethod(EnableSession = true)]       
        public Dictionary<string, object> GetProjectorBrand()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
                {
                    HttpContext.Current.Session.Abandon();
                    result.Add("status", "fail");
                    result.Add("errorMessage", "Session Expired");
                    result.Add("customErrorCode", "440");
                }
                else
                {
                    var path = HttpContext.Current.Server.MapPath("~/Projector Type/");
                    var dirs = Directory.GetDirectories(path);
                    List<string> names = new List<string>();
                    foreach (var r in dirs)
                    {
                        names.Add(new DirectoryInfo(r).Name);
                    }
                    result.Add("status", "success");
                    result.Add("total", names.Count);
                    result.Add("names", names);
                }

            }
            catch(Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Method to get list of Projector Models by 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorModel(string brand)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
                {
                    HttpContext.Current.Session.Abandon();
                    result.Add("status", "fail");
                    result.Add("errorMessage", "Session Expired");
                    result.Add("customErrorCode", "440");
                }
                else
                {
                    var path = HttpContext.Current.Server.MapPath("~/Projector Type/" + brand);
                    var dirs = Directory.GetFiles(path, "*.ini").ToList();
                    
                    List<string> names = new List<string>();
                    //dirs.ForEach(x => names.Add( x.Split('.')[0]));
                    foreach (var r in dirs)
                    {
                        names.Add(new FileInfo(r).Name.Split('.')[0]);
                    }
                    result.Add("status", "success");
                    result.Add("total", names.Count);
                    result.Add("names", names);
                }

            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Method to get Ini info about the projector by its brand and model selection by user
        /// Need to work: on reading parity from the comments in Ini file and 
        /// then setting the parity 01,00,02 (even,odd,none) according to those comments
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Baud rate, Open, close codes, parity check</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorIniInfo(Dictionary<string,string> data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> result1 = new Dictionary<string, object>();
            try
            {
                if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
                {
                    HttpContext.Current.Session.Abandon();
                    result1.Add("status", "fail");
                    result1.Add("errorMessage", "Session Expired");
                    result1.Add("customErrorCode", "440");
                }
                else
                {
                    var brand = data["Brand"].ToString();
                    var model = data["Model"].ToString();
                    var path = HttpContext.Current.Server.MapPath("~/Projector Type/" + brand + "/" + model + ".ini");
                    IniFile inf = new IniFile(path);                    
                    
                    result.Add("BaudRate", inf.IniReadValue("Option", "BaudRate"));
                    result.Add("Parity", inf.IniReadValue("Option", "Parity"));
                    result.Add("OpenCode", inf.IniReadValue("Option", "Open"));
                    result.Add("CloseCode", inf.IniReadValue("Option", "Close"));
                    
                    result1.Add("status", "success");
                    result1.Add("value", result);
                }
            }
            catch (Exception ex)
            {
                result1.Add("status", "fail");
                result1.Add("Error", ex.Message);
            }
            return result1;
        }

        /// <summary>
        /// Method to save projector Info into database and send the ini info to Machine of the selected classroom
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> SaveProjectorInfo(Dictionary<string, object> data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            int r = 0;

            try
            {
                if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
                {
                    HttpContext.Current.Session.Abandon();
                    result.Add("status", "fail");
                    result.Add("errorMessage", "Session Expired");
                    result.Add("customErrorCode", "440");
                }
                else
                {
                    var classids = ((object[])data["classids"]).Cast<int>().ToList();
                    var brand = data["Brand"].ToString();
                    var model = data["Model"].ToString();
                    var baudrate = Convert.ToInt32(data["BaudRate"]);
                    var parity = Convert.ToInt16(data["Parity"]);
                    var opencode = data["OpenCode"].ToString();
                    var closecode = data["CloseCode"].ToString();

                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        if (classids != null)
                        {
                            foreach (var id in classids)
                            {
                                var configrow = context.projectorconfiginfoes.Where(x => x.Classid == id).Select(x => x).FirstOrDefault();
                                if (configrow != null)
                                {
                                    configrow.BrandName = brand;
                                    configrow.Model = model;
                                    configrow.Baudrate = baudrate;
                                    configrow.parity = parity;
                                    configrow.OpenCode = opencode;
                                    configrow.CloseCode = closecode;
                                    configrow.status = "Pending";
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
                                        status = "Pending"

                                    };
                                    context.projectorconfiginfoes.Add(confignew);

                                }

                            }

                            r += context.SaveChanges();
                        }
                        result.Add("UpdatedRows", r);
                    }
                    List<string> machinemacs = new List<string>();

                    
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        machinemacs = context.classdetails.Where(x => classids.Contains(x.classID)).Select(x => x.ccmac).ToList();
                    }
                    var dat = new Dictionary<string, string> { {"BaudRate", baudrate.ToString()}
                        ,{"Parity", parity.ToString() },{"ProjectorOnCode", opencode},
                        { "ProjectorOffCode", closecode } };
                    hubContext = GlobalHost.ConnectionManager.GetHubContext<HubsFile.MyHub>();
                    hubContext.Clients.All.SetProjectorConfiguration1(machinemacs, dat);
                    result.Add("status", "success");
                }
            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }
            return result;
        }

        /// <summary>
        /// method to get the Projector config info based on class id
        /// </summary>
        /// <param name="classid"></param>
        /// <returns>projector config info with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetProjectorInfo(int classid)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
                {
                    HttpContext.Current.Session.Abandon();
                    result.Add("status", "fail");
                    result.Add("errorMessage", "Session Expired");
                    result.Add("customErrorCode", "440");
                }
                else
                {

                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var row = context.projectorconfiginfoes.Where(x => x.Classid == classid)
                            .Select(x => new
                            {
                                BaudRate = x.Baudrate,
                                Parity = x.parity,
                                Brand = x.BrandName,
                                x.Model,
                                x.OpenCode,
                                x.CloseCode,
                                ConfigStatus=x.status

                            }).FirstOrDefault();
                        if (row != null)

                            result.Add("value", row);
                    }
                    result.Add("status", "success");
                }
            }
            catch (Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }
            return result;
        }
    }
    /// <summary>
    /// Class to read/write from/into Ini File
    /// </summary>
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
