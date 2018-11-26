using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace trythis
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string no = PhoneNo.Text.ToString();

                var charsToRemove = new string[] { "+", "-", " " };
                foreach (var c in charsToRemove)
                {
                    no = no.Replace(c, string.Empty);
                }
                long phone = Convert.ToInt64(no);
                string connString = null;
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Registration", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("User_ID", UserID.Text);
                cmd.Parameters.AddWithValue("User_Name", User_Name.Text);
                cmd.Parameters.AddWithValue("Password", Password.Text);
                cmd.Parameters.AddWithValue("Phone_Number", phone);
                cmd.Parameters.AddWithValue("Request_Status", "Pending");
                int k = cmd.ExecuteNonQuery();
                con.Close();

                if (k > 0 )
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Registered Successfully')", true);

                    Response.Redirect("Login.aspx", false);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('UserID or phone Number already in use. Please try using different UserId and Number')", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);
            }
            //var manager = new UserManager();
            //var user = new ApplicationUser() { UserName = UserName.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    IdentityHelper.SignIn(manager, user, isPersistent: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            ////else 
            ////{
            ////    ErrorMessage.Text = result.Errors.FirstOrDefault();
            ////}
        }
    }
}
