using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace trythis
{
    public partial class Control : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
        {
            
           

        }

        protected void Button19_Click(object sender, EventArgs e)
        {
           
            
            desktop.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            laptop.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            digitalScreen.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            digitalCurtain.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            dvd.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            bluray.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            tvset.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            vcr.BackColor = ColorTranslator.FromHtml("#30A738");
        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            recorder.BackColor = ColorTranslator.FromHtml("#30A738");
        }
    }
}