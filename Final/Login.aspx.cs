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


namespace final
{
    public partial class Login : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void LogIn(object sender, EventArgs e)
        {
            

                string id = UserName.Text;
                var charsToRemove = new string[] { "+", "-", " " };
                foreach (var c in charsToRemove)
                {
                    id = id.Replace(c, string.Empty);

                }
                Int64 phone = 0;

                if (Int64.TryParse(id, out phone))
                {
                    phone = Convert.ToInt64(id);

                    id = "phone";
                }


                String connString = null;
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
            cmd.ExecuteNonQuery();
            int k = Convert.ToInt32(cmd.Parameters["@rolename"].Value);
            string n = cmd.Parameters["@username"].Value.ToString();
                con.Close();
                if (k >0)
                {
                    
                    
                    HttpContext.Current.Session["UserName"] = n;
                    HttpContext.Current.Session["role"] = k;
                    Response.Redirect("~/AddUser.aspx");
            }
                else
                {
                    FailureText.Text = " id  " + id + "   phone " + phone + "  return value " + k;
                    ErrorMessage.Visible = true;
                }
            }
    }
        
}
