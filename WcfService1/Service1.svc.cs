using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CalculatorService : ICalculator
    {
        private readonly IHubProxy messageHub;
        
        public CalculatorService()
        {
            var connection = new HubConnection("http://localhost:yourport/~/");
            messageHub = connection.CreateHubProxy("MessageHub");
            connection.Start().Wait();
        }
        public void SendMessage(string sender, string message)
        {
            messageHub.Invoke("Hello", sender, message);
        }
       
    }
    public class ChangeData
    {
        public byte[] MindIt { get; set; } = new byte[20];
    }
}
