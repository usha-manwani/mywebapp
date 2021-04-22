// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 08-31-2020
//
// Last Modified By : admin
// Last Modified On : 08-31-2020
// ***********************************************************************
// <copyright file="CustomError.aspx.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CresijApp.site
{
    /// <summary>
    /// Class CustomError.
    /// Implements the <see cref="System.Web.UI.Page" />
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class CustomError : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies["AuthToken"].Value = null;
            HttpContext.Current.Response.Redirect("site/login.html");
        }
    }
}