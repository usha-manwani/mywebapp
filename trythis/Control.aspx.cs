using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebCresij
{
    public partial class Control : BasePage
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GradeName.Text = HttpContext.Current.Session["GradeName"].ToString();
                insName.Text = HttpContext.Current.Session["InstituteID"].ToString()+" >> ";
            }            
        }                
    }
}