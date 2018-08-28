using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FinalProject.Hubsfile
{
    public class MyHub : Hub
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public void Hello()
        {
            Clients.All.hello();
        }
        public void GetUsers()
        {
            DataTable dt;
            using (var connection = new SqlConnection(constr))
            {
                String query = "SELECT * from dbo.[updateData]";
                try
                {
                    connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Notification = null;

                        dt = new DataTable();
                        DataSet ds = new DataSet();
                        SqlDependency dependency = new SqlDependency(command);

                        dependency.OnChange += dependency_OnChange;

                        if (connection.State == ConnectionState.Closed)
                            connection.OpenAsync();

                        SqlDependency.Start(connection.ConnectionString);
                        var reader = command.ExecuteReader();
                        dt.Load(reader);

                    }
                }
                finally
                {
                    connection.Close();
                }

                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Application.Lock();
                    HttpContext.Current.Application["ScoreTable"] = dt;
                    HttpContext.Current.Application.UnLock();

                }

            }
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.recieveNotification(dt);
        }

        void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MyHub _dataHub = new MyHub();
                _dataHub.GetUsers();
            }
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.updateMessages();
        }
    }
}