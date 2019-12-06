using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class addDetails : BasePage
    {
        PopulateTree pt = new PopulateTree();
        protected string Values;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        

        protected void save_Click(object sender, EventArgs e)
        {
            int r = pt.InsertInstitute(txtIns.Text);
            int v = 0;
            string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            this.Values = serializer.Serialize(textboxValues);
            if (textboxValues != null)
            {
                foreach (string textboxValue in textboxValues)
                {
                    v = pt.InsertGrade(r.ToString(), textboxValue);

                }
            }
            
            if(r!=1 || v!=1)
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError1");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "successIns", "alert('"+message+"')", true);
            }
        }

        
    }
}