using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for UserAuthorisation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserAuthorisation : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<object> GetUserAuthentications()
        {
            List<object> idata = new List<object>();
            return idata;
        }

        [WebMethod]
        public int SaveUserAuthentications(string[] data)
        {
            return 0;
        }
    }
}
