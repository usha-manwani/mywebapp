using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace CresijApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var er = HttpContext.Current.Server.GetLastError();
            if (er.GetType().Equals("System.Security.SecurityException"))
            {
                HttpContext.Current.Response.Redirect(".../site/CustomError.aspx");
            }
        }

        void Session_End(object sender, EventArgs e)
        {
           
                HttpContext.Current.Response.Redirect("CustomError.aspx",true);
            
            // Code that runs when a session ends.   
            // Note: The Session_End event is raised only when the sessionstate mode  
            // is set to InProc in the Web.config file. If session mode is set to StateServer   
            // or SQLServer, the event is not raised.  

        }
    }
}