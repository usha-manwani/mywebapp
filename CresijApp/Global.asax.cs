// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 12-09-2019
//
// Last Modified By : admin
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Global.asax.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Configuration;
using NLog;
namespace CresijApp
{
    /// <summary>
    /// Class Global.
    /// Implements the <see cref="System.Web.HttpApplication" />
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class Global : HttpApplication
    {
        /// <summary>
        /// The logger file
        /// </summary>
        private static Logger loggerFile = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_Start(object sender, EventArgs e)
        {
            Application["onlineNum"] = 0;
            Application["onVisitorNum"] = Double.Parse(ConfigurationManager.AppSettings["onVisitorNum"]);
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var er = HttpContext.Current.Server.GetLastError();
            if (er.GetType().Equals("System.Security.SecurityException"))
            {
                HttpContext.Current.Response.Redirect(".../site/CustomError.aspx");
            }
        }
        /// <summary>
        /// Handles the PostRequestHandlerExecute event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            // 更新cookie
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserLoggedIn"] != null)
            {
                FormsAuthentication.SetAuthCookie(HttpContext.Current.Session["UserLoggedIn"].ToString(), false);
                HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
                string ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket("userId", false, 30));
                HttpCookie FormsCookie = new HttpCookie("AuthToken", ticket) { HttpOnly = true };
                var t = Guid.NewGuid().ToString();
                HttpContext.Current.Session["AuthToken"] = t;
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("AuthCookie", t));
                HttpContext.Current.Response.Cookies.Add(FormsCookie);
            }
        }
        /// <summary>
        /// Sessions the start.
        /// </summary>
        void Session_Start()
        {
            Application["onVisitorNum"] = double.Parse(Application["onVisitorNum"].ToString()) + 1;
            Application["onlineNum"] = double.Parse(Application["onlineNum"].ToString()) + 1;
            /*
            Configuration cfa = WebConfigurationManager.OpenWebConfiguration("~");
            cfa.AppSettings.Settings["onVisitorNum"].Value = Application["onVisitorNum"].ToString();
            cfa.Save();*/
        }
        /// <summary>
        /// Handles the End event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Session_End(object sender, EventArgs e)
        {
            var num = double.Parse(Application["onlineNum"].ToString()) - 1;
            Application["onlineNum"] = num >= 0 ? num : 0;
            // Code that runs when a session ends.   
            // Note: The Session_End event is raised only when the sessionstate mode  
            // is set to InProc in the Web.config file. If session mode is set to StateServer   
            // or SQLServer, the event is not raised.
        }
        /// <summary>
        /// Applications the post authorize request.
        /// </summary>
        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

    }
}