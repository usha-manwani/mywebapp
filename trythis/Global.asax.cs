﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace WebCresij
{
    public class Global : HttpApplication
    {
       
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["UsersLoggedIn"] = new List<string>();

        }
        protected void Application_End()
        {

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            
        }
        protected void Session_OnEnd(object sender, EventArgs e)
        {
            

        }
        //public void Application_AuthenticateRequest(Object src, EventArgs e)
        //{
        //    if (!(HttpContext.Current.User == null))
        //    {
        //        if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
        //        {
        //            System.Web.Security.FormsIdentity id;
        //            id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
        //            String[] myRoles = new String[2];
        //            myRoles[0] = "Manager";
        //            myRoles[1] = "Admin";
        //            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
        //        }
        //    }
        //}


    }
}