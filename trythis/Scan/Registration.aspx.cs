using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class Registration : BasePage
    {
        static string ip;
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.QueryString["ip"];
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
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Registration", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("userids", UserID.Text);
                cmd.Parameters.AddWithValue("UserName", User_Name.Text);
                cmd.Parameters.AddWithValue("Password", Password.Text);
                cmd.Parameters.AddWithValue("Phone_Number", phone);
                //cmd.Parameters.AddWithValue("Request_Status", "Pending");
                cmd.Parameters.Add("@k", MySqlDbType.Int32);
                cmd.Parameters["@k"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int k = Convert.ToInt32(cmd.Parameters["@k"].Value);
                con.Close();
                if (k > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", 
                    //    "alert('Registered Successfully')", true);
                    string message = Resources.Resource.ResourceManager.GetString("WaitingforAdmin");
                    string url = "../Scan/MobileLogin.aspx?ip="+ip;
                    string script = " alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Redirect", script, true);
                   
                }
                else
                {
                    string message = Resources.Resource.ResourceManager.GetString("PhoneUseridExists");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage",
                        "alert('"+message+"')", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);

            }

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["MobileUserId"] = "";
            Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip);
        }
    }
}