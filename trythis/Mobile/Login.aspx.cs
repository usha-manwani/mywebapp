using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            int k = 0;
            string n = "";
            string u = "";
            string id = UserName.Text;
            MySqlConnection con;
            string connString = null;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
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
            using (con = new MySqlConnection(connString))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Sp_Login", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("Userid", id);
                    cmd.Parameters.AddWithValue("Phone_No", phone);
                    cmd.Parameters.AddWithValue("User_Password", Password.Text);
                    cmd.Parameters.Add("@roleName", MySqlDbType.Int32);
                    cmd.Parameters["@roleName"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Usernametemp", MySqlDbType.VarChar, 50);
                    cmd.Parameters["@Usernametemp"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@userids", MySqlDbType.VarChar, 50);
                    cmd.Parameters["@userids"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    k = Convert.ToInt32(cmd.Parameters["@rolename"].Value);
                    n = cmd.Parameters["@usernametemp"].Value.ToString();
                    u = cmd.Parameters["@userids"].Value.ToString();

                    if (k > 0)
                    {
                        UserActivities.UserLogs.LoggedinUser(u);
                        HttpContext.Current.Session["UserName"] = n;
                        HttpContext.Current.Session["role"] = k;
                        HttpContext.Current.Session["UserId"] = u;
                        HttpContext.Current.Session["LocToDisplay"] = "";
                        
                            Response.Cookies["cresijuserid"].Value = UserName.Text;
                            Response.Cookies["cresijpwd"].Value = Password.Text.Trim();
                            Response.Cookies["cresijuserid"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["cresijpwd"].Expires = DateTime.Now.AddDays(30);
                        
                        UserActivities.UserLogs.Task1(u, n, 1); /// Saving login Task
                        string url = "../Mobile/Home.aspx" ;
                        Response.Redirect(url, false);
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
                catch (Exception ex)
                {
                    FailureText.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}