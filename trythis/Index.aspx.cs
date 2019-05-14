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
using System.Threading;
using System.Globalization;

namespace WebCresij
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            Session.Clear();
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
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
            if (k > 0)
            {
                UserActivities.UserLogs.LoggedinUser(u);
                HttpContext.Current.Session["UserName"] = n;
                HttpContext.Current.Session["role"] = k;
                HttpContext.Current.Session["UserId"] = u;
                HttpContext.Current.Session["LocToDisplay"] = "";
                UserActivities.UserLogs.Task1(u,n,1); /// Saving login Task
                //bool sessionAdd =  AddSession(u);
                Response.Redirect("~/home.aspx");
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

        protected bool AddSession(string user_id)
        {
            List<string> d = Application["UsersLoggedIn"] as List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(user_id))
                    {
                        // User is already logged in!!!
                        string userLoggedIn = Session["UserId"] == null ? string.Empty : (string)Session["UserId"];
                        if (userLoggedIn == user_id)
                        {
                            Session["UserId"] = user_id;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        string userLoggedIn = Session["UserId"] == null ? string.Empty : (string)Session["UserId"];

                        if (userLoggedIn != user_id)
                        {
                            d.Add(user_id);
                        }
                    }
                }
            }
            return true;
        }
    }
}
