using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication1
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
        // public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        //[HubMethodName("updateData")]
        //public DataTable updateData()
        //{
        //    DataTable dt = new DataTable();
        //    using (var conn = new SqlConnection(constr))
        //    {
        //        string query = "select * from dbo.[CentralControl]";
        //        conn.OpenAsync();
        //        using(SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Notification = null;
        //            SqlDependency dependency = new SqlDependency(cmd);
        //            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
        //            if (conn.State == ConnectionState.Closed)
        //                conn.OpenAsync();
        //            var reader = cmd.ExecuteReader();
        //            dt.Load(reader);
        //            if (dt.Rows.Count > 0)
        //            {

        //            }
        //        }
        //    }
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    context.Clients.All.recieveNotification(dt);
        //        return dt;
        //}
        //private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    if(e.Type == SqlNotificationType.Change)
        //    {
        //        MyHub myHub = new MyHub();
        //        myHub.updateData();
        //    }
        //}
    }
}