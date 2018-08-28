using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FinalProject
{
    public class Global : HttpApplication
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SqlDependency.Start(constr);
            //trythis.connection.ReceiveData();
        }
        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(constr);
        }
    }
}