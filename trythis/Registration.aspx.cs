using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using MySql.Data.MySqlClient;

namespace WebCresij
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
                cmd.Parameters.AddWithValue("userid", UserID.Text);
                cmd.Parameters.AddWithValue("UserName", User_Name.Text);
                cmd.Parameters.AddWithValue("Password", Password.Text);
                cmd.Parameters.AddWithValue("Phone_Number", phone);
                //cmd.Parameters.AddWithValue("Request_Status", "Pending");
                cmd.Parameters.Add("@k", MySqlDbType.Int32);
                cmd.Parameters["@k"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int k = Convert.ToInt32( cmd.Parameters["@k"].Value);
                con.Close();
                if (k > 0 )
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", 
                        "alert('Registered Successfully')", true);
                    Response.Redirect("Index.aspx", false);
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
