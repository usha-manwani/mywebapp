using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;

namespace TimerSchedule
{
    public partial class TimerSchedule : ServiceBase
    {
        private static IHubProxy proxy;
        private static HubConnection con;
        // Create an instance of EventLog
        static EventLog eventLog = new EventLog();
        static int eventID = 8;
        private Timer intervalTime;
        public TimerSchedule()
        {
            InitializeComponent();
            // Check if the event source exists. If not create it.
            if (!EventLog.SourceExists("TestApplication"))
            {
                EventLog.CreateEventSource("TestApplication", "Application");
            }
            // Set the source name for writing log entries.
            eventLog.Source = "TestApplication";
            eventLog.WriteEntry("Application Started",EventLogEntryType.SuccessAudit,eventID);
            // Create an event ID to add to the event log
            intervalTime = new Timer();
        }
        protected override void OnStart(string[] args)
        {
            ConnectToHub();
            //Do IT HERE            
            intervalTime.Elapsed += new ElapsedEventHandler(intervalTime_Elapsed);
            intervalTime.Interval = 120000;
            intervalTime.Enabled = true;                                   
        }
        protected override void OnStop()
        {
            eventLog.WriteEntry("Timer Service closing", EventLogEntryType.Warning, eventID);
            // Close the Event Log
            eventLog.Close();
        }
        static void intervalTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerLogic timer1 = new TimerLogic();
            DataTable dt = timer1.StartTime();            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        if (con.State != ConnectionState.Connected)
                        {                            
                            con.Start().Wait();                            
                        }
                        proxy.Invoke("SendControlKeys", row[0].ToString(), "8B B9 00 04 02 04 18 22");                       
                    }
                    catch (Exception ex)
                    {
                        eventLog.WriteEntry("some error occured "+ ex.Message,EventLogEntryType.Error,eventID);                      
                        con.Start().Wait();                        
                    }
                }
            }
        }
        public static void ConnectToHub()
        {
            try
            {
                con = new HubConnection("http://localhost/trythis/");
                proxy = con.CreateHubProxy("myHub");
                eventLog.WriteEntry("connected to server",
                                              EventLogEntryType.Information,
                                              eventID);
                con.Start().Wait();
            }
            catch (Exception)
            {
                con.StateChanged += Con_StateChanged;
            }
        }
        private static void Con_StateChanged(StateChange obj)
        {
            if (obj.OldState == ConnectionState.Disconnected)
            {
                eventLog.WriteEntry("Connection state changed",
                                              EventLogEntryType.Information,
                                              eventID);                
            }
            else
            {
                eventLog.WriteEntry("state changed inside else",
                                              EventLogEntryType.Information,
                                              eventID);
            }
        }
        private static void Con_Closed()
        {
            eventLog.WriteEntry("connection closed",EventLogEntryType.Information,eventID);
            con.Start().Wait();
        }
    }  
}
