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
    public partial class Registration : BasePage
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
                    string message = "Registered Successfully!!";
                    string url = "../Mobile/Login.aspx";
                    string script = " alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Redirect", script, true);
                    //Response.Redirect("Index.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage",
                        "alert('UserID or phone Number already in use. Please try using different UserId and Number')", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);

            }

        }
    }
}