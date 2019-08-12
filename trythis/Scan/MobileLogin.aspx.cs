using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class MobileLogin : Page
    {
        static string ip;
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.QueryString["ip"];
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ip))
            {
                string url = "../Scan/Error.aspx";
                Response.Redirect(url, true);
            }
            else
            {
                int k = 0;
                string n = "";
                string u = "";
                string id = UserName.Text;
                SqlConnection con;
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
                using (con = new SqlConnection(connString))
                {
                    try
                    {
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

                        if (k.ToString().Contains("1"))
                        {
                            HttpContext.Current.Session["MobileUserId"] = u;
                            string url = "../Scan/QrControlPage.aspx?ip=" + ip + "&username=" + n;
                            Response.Redirect(url, true);
                        }
                        else if (k == -9)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "alert('UserID is in pending state !! \nPlease try after some time!!');", true);
                        }
                        else if (!k.ToString().Contains("3"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg2", "alert('You are not authorised to login here');", true);
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
}