using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

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
        public string Saveimage(string data)
        {
            byte[] imgarr = Convert.FromBase64String(data);
            return "done";
            /* Add further code here*/
        }
    }
}
