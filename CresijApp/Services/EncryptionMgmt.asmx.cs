using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CresijApp.Services
{
    #region Not used Anywhere.
    /// <summary>
    /// Summary description for EncryptionMgmt
    /// 
    /// The service is currently in no use
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    
    public class EncryptionMgmt : System.Web.Services.WebService
    {
        public string strSecTckt;
        private void GetTicket(string sessionid)
        {
            string Key = "SecurityTicket:" + sessionid;
            strSecTckt = Guid.NewGuid().ToString();
            Session[Key] = strSecTckt;
        }

        
        [WebMethod]
        public void GenerateTicket()
        {
            GetTicket(CheckSession());
        }
        [WebMethod(EnableSession = true)]
        public string CheckSession()
        {
            return HttpContext.Current.Session.SessionID;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string LocalWS(string Msg)
        {
            ValidateTicket();
            return Msg ;
        }
        private static void ValidateTicket()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                string headerTicket = context.Request.Headers["STicket"];
                if (string.IsNullOrEmpty(headerTicket))
                    throw new System.Security.SecurityException("Security ticket must be present.");

                string Key = "SecurityTicket:" + context.Session.SessionID;
                string ServerTicket = Convert.ToString(context.Session[Key]);

                if (string.Compare(headerTicket, ServerTicket, false) != 0)
                    throw new System.Security.SecurityException("Security ticket mismatched.");
            }
            else
                throw new System.Security.SecurityException("Not authorized.");
        }
    }
    #endregion
}
