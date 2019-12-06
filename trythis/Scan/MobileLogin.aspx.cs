using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace WebCresij.Scan
{
    public partial class MobileLogin : BasePage
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
                        MySqlCommand cmd = new MySqlCommand("Sp_Login", con) {
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

                        if (k.ToString().Contains("1") || k.ToString().Contains("3"))
                        {
                            HttpContext.Current.Session["MobileUserId"] = u;
                            HttpContext.Current.Session["MobileUserName"] = n;
                            UserActivities.UserLogs.LoggedinUser(u);
                            UserActivities.UserLogs.Task1(u, n, 1);
                            string url = "../Scan/QrControlPage.aspx?ip=" + ip + "&username=" + n;
                            Response.Redirect(url, true);
                        }
                        else
                        {
                            //if (k == -9)
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "alert('UserID is in pending state !! \nPlease try after some time!!');", true);
                            //}
                            //else if (!k.ToString().Contains("3"))
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg2", "alert('You are not authorised to login here');", true);
                            //}
                            /*else*/
                            if (k==0)
                            {
                                int hour = DateTime.Now.Hour;
                                int min = DateTime.Now.Minute;
                                var time = hour.ToString("D2") + ":" + min.ToString();
                                Userdetails ud = new Userdetails();
                                List<object> r = ud.LoginTempuser(UserName.Text.Trim(), Password.Text.Trim(), time, ip);
                                if (Convert.ToInt32(r[0]) == 1)
                                {
                                    HttpContext.Current.Session["MobileUserId"] = UserName.Text.Trim();
                                    HttpContext.Current.Session["MobileUserName"] = r[1].ToString();
                                    UserActivities.UserLogs.Task1(UserName.Text.Trim(), r[1].ToString(), 1);
                                    UserActivities.UserLogs.LoggedinUser(UserName.Text.Trim());
                                    string url = "../Scan/SingleTimeControlPage.aspx?ip=" + ip+ "&username=" + UserName.Text.Trim();
                                    Response.Redirect(url, true);
                                }
                                else if (Convert.ToInt32(r[0]) == -1)
                                {
                                    string message = Resources.Resource.ResourceManager.GetString("NologinTime");
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertnotime", 
                                        "alert('"+message+"');", true);
                                }
                                else
                                {
                                    string message = Resources.Resource.ResourceManager.GetString("WrongIDPassword");
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg", "alert('" + message + "');", true);
                                }
                                    
                            }
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
        protected void gotoFault_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/FaultInfo1.aspx?ip=" + ip, true);
        }

        protected void linkregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/Registration.aspx?ip=" + ip, true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/OneTimeRegistration.aspx?ip=" + ip, true);
        }
    }
}