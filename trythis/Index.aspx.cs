using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;


namespace WebCresij
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn(object sender, EventArgs e)
        {

            int k = 0;
            string n = "";
            string u = "";
            string id = UserName.Text;
            var charsToRemove = new string[] { "+", "-", " " };
            foreach (var c in charsToRemove)
            {
                id = id.Replace(c, string.Empty);

            }
            long phone = 0;

            if (long.TryParse(id, out phone))
            {
                phone = Convert.ToInt64(id);

                id = "phone";
            }
            try
            {
                string connString = null;
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_Login", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("User_ID", id);
                cmd.Parameters.AddWithValue("Phone_No", phone);
                cmd.Parameters.AddWithValue("User_Password", Password.Text);
                cmd.Parameters.Add("@roleName", SqlDbType.Int);
                cmd.Parameters["@roleName"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50);
                cmd.Parameters["@Username"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50);
                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                k = Convert.ToInt32(cmd.Parameters["@rolename"].Value);
                n = cmd.Parameters["@username"].Value.ToString();
                u = cmd.Parameters["@id"].Value.ToString();
                con.Close();
            }
            catch (Exception)
            {
                FailureText.Text = "Exception occured";
                ErrorMessage.Visible = true;
            }
            if (k > 0)
            {
                HttpContext.Current.Session["UserName"] = n;
                HttpContext.Current.Session["role"] = k;
                HttpContext.Current.Session["UserId"] = u;
                Response.Redirect("~/tempratureCharts.aspx");
            }
            else if (k == -9)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "alert('UserID is in pending state !! \nPlease try after some time!!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg", "alert('Wrong ID or Password!! Please try again!');", true);
            }                       
        }
        
    }
}
