using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace trythis.Hubsfile
{
    public class MyHub : Microsoft.AspNet.SignalR.Hub
    {
        DataTable ScoresTable = HttpContext.Current.Application["ScoresTable"] as DataTable;
        string constr= System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
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
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Notification = null;
                    dt = new DataTable();
                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed) connection.Open();

                    SqlDependency.Start(connection.ConnectionString);
                    var reader = command.ExecuteReader();
                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        HttpContext.Current.Application["ScoresTable"] = dt;
                    }
                    
                }
            }
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            //context.Clients.All.displayUsers(_lst);

            
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