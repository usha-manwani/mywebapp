using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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
            {
                Session.Clear();
                if (Request.Browser.IsMobileDevice && Request.QueryString["desktop"]!="true")
                {
                    Response.Redirect("~/Mobile/Login.aspx");
                }
                if (Request.Cookies["cresijuserid"] != null && Request.Cookies["cresijpwd"] != null)
                {
                    UserName.Text = Request.Cookies["cresijuserid"].Value;
                    Password.Text = Request.Cookies["cresijpwd"].Value;
                    RememberMe.Checked = true;
                }
            }
        }
        protected void LogIn(object sender, EventArgs e)
        {
            
            int k = 0;
            string n = "";
            string u = "";
            string id = UserName.Text.Trim();
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
                
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("userid", id);
                cmd.Parameters.AddWithValue("phone_no", phone);
                cmd.Parameters.AddWithValue("user_password", Password.Text.Trim());
                cmd.Parameters.Add("@rolename", MySqlDbType.Int32);
                cmd.Parameters["@rolename"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@usernametemp", MySqlDbType.VarChar, 50);
                cmd.Parameters["@usernametemp"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@userids", MySqlDbType.VarChar, 50);
                cmd.Parameters["@userids"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                k = Convert.ToInt32(cmd.Parameters["@rolename"].Value);
                n = cmd.Parameters["@usernametemp"].Value.ToString();
                u = cmd.Parameters["@userids"].Value.ToString();
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
                if (RememberMe.Checked == true)
                {
                    Response.Cookies["cresijuserid"].Value = UserName.Text;
                    Response.Cookies["cresijpwd"].Value = Password.Text.Trim();
                    Response.Cookies["cresijuserid"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["cresijpwd"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {                  
                    Response.Cookies["cresijuserid"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["cresijpwd"].Expires = DateTime.Now.AddDays(-1);
                }
                UserActivities.UserLogs.Task1(u,n,1); /// Saving login Task
                //bool sessionAdd =  AddSession(u);
                Response.Redirect("~/Home.aspx");
            }
            else if (k == -9)
            {
                string message = Resources.Resource.ResourceManager.GetString("PendingAlert");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "alert('"+message+"'); ", true);
            }
            else
            {
                string message = Resources.Resource.ResourceManager.GetString("WrongIDPassword");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg", "alert('" + message + "');", true);
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

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    if (Request.Browser.IsMobileDevice)
        //        Response.Redirect("~/Mobile/Login.aspx");
        //}
    }
}
