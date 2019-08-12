using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebCresij
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string language = "zh-CN";
            //Detect User's Language.
            if (Request.UserLanguages != null)
            {
                //Set the Language.
                language = Request.UserLanguages[0];
               
            }
            //Check if PostBack is caused by Language DropDownList.
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].Contains("ddlLanguages"))
            {
                //Set the Language.
                language = Request.Form[Request.Form["__EVENTTARGET"]];
                Session["Language"] = language;
            }

            //Set the Culture.
            if (Session["Language"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Language"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Language"].ToString());
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
        }
        
    }
}