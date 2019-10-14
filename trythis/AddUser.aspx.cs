using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebCresij
{
    public partial class AddUser : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)  
        {
            MySqlConnection con;
            string connString = null;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
            con = new MySqlConnection(connString);
            string i = "";
            if (UserID.Text != null)
            {                
                System.Collections.IList list = CheckBoxList1.Items;
                for (int i1 = 0; i1 < list.Count; i1++)
                {
                    ListItem item = (ListItem)list[i1];
                    if (item.Selected)
                    {
                        i = i + item.Value;
                    }
                }
            }
            try
            {
                string no = PhoneNo.Text.ToString();
                var charsToRemove = new string[] { "+", "-", " " };
                foreach (var c in charsToRemove)
                {
                    no = no.Replace(c, string.Empty);
                }
                long phone = Convert.ToInt64(no);
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
                con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("sp_addNewUser", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@userid", UserID.Text);
                cmd.Parameters.AddWithValue("@username", User_Name.Text);
                cmd.Parameters.AddWithValue("@Pass", Password.Text);
                cmd.Parameters.AddWithValue("@roleid", i);
                cmd.Parameters.AddWithValue("@ph", phone);
                cmd.Parameters.Add("@result", MySqlDbType.Int32);
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int k = Convert.ToInt16(cmd.Parameters["@result"].Value);
                if (k == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Registered Successfully')", true);
                    UserID.Text = "";
                    User_Name.Text = "";
                    PhoneNo.Text = "";
                    //  Response.Redirect("AddUser.aspx", false);
                }
                else if (k == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('UserID or phone Number already in use. Please try using different UserId and Number')", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);
                Response.Redirect("AddUser.aspx", false);
            }
            finally
            {
                con.Close();
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 4);
            }
            
        }
    }
}