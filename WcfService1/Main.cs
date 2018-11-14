using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public class Main
    {
        private TcpListener tcpServer;
        private TcpClient tcpClient;
        private Thread th;
        private ChatDialog ctd;
        private ArrayList formArray = new ArrayList();
        private ArrayList threadArray = new ArrayList();
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;
        public delegate void SetListBoxItem(String str, String type);
        List<Tuple< TcpClient, Thread>> clients = new List<Tuple<TcpClient, Thread>>();
        public Main()
        {
            // Add Event to handle when a client is connected
            Changed += new ChangedEventHandler(ClientAdded);
        }

        #region Server Start/Stop

        /// <summary>
        /// This function spawns new thread for TCP communication
        /// </summary>
        public void StartServer()
        {

            th = new Thread(new ThreadStart(StartListen));
            th.Start();

        }

        public void StartListen()
        {

            IPAddress localAddr = IPAddress.Any;

            tcpServer = new TcpListener(localAddr, 1200);
            tcpServer.Start(200);

            // Keep on accepting Client Connection
            while (true)
            {

                // New Client connected, call Event to handle it.
                Thread t = new Thread(new ParameterizedThreadStart(NewClient));
                tcpClient = tcpServer.AcceptTcpClient();
                t.Start(tcpClient);

            }

        }
        /// <summary>
        /// Function to stop the TCP communication. It kills the thread and closes client connection
        /// </summary>
        public void StopServer()
        {

            if (tcpServer != null)
            {

                // Close all Socket connection
                foreach (ChatDialog c in formArray)
                {
                    c.connectedClient.Client.Close();
                }

                // Abort All Running Threads
                foreach (Thread t in threadArray)
                {
                    t.Abort();
                }

                // Clear all ArrayList
                threadArray.Clear();
                formArray.Clear();


                // Abort Listening Thread and Stop listening
                th.Abort();
                tcpServer.Stop();
            }

        }
        #endregion

        #region Add/remove Clients
        /// <summary>
        /// 
        /// </summary>
        public void NewClient(Object obj)
        {
            ClientAdded(this, new MyEventArgs((TcpClient)obj));
        }

        /// <summary>
        /// Event Fired when a Client gets connected. Following actions are performed
        /// 1. Update Tree view
        /// 2. Open a chat box to chat with client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClientAdded(object sender, EventArgs e)
        {
            tcpClient = ((MyEventArgs)e).clientSock;
            String remoteIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            String remotePort = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString();

            // Call Delegate Function to update Tree View
           // UpdateClientList(remoteIP + " : " + remotePort, "Add");

            // Show Dialog Box for Chatting



            // Add Dialog Box Object to Array List
            formArray.Add(ctd);
            threadArray.Add(Thread.CurrentThread);
            clients.Add(new Tuple<TcpClient, Thread>(tcpClient, Thread.CurrentThread));
            //ctd.ShowDialog();
        }

        /// <summary>
        /// Delegate Function to update List box.
        /// If type parameter is "Add", then client information is added in Tree View
        /// else the entry is delete from Tree View.
        /// </summary>
        /// <param name="str"></param>
        //private void UpdateClientList(string str, string type)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.tvClientList.InvokeRequired)
        //    {
        //        SetListBoxItem d = new SetListBoxItem(UpdateClientList);
        //        this.Invoke(d, new object[] { str, type });
        //    }
        //    else
        //    {
        //        // If type is Add, the add Client info in Tree View
        //        if (type.Equals("Add"))
        //        {
        //            this.tvClientList.Nodes[0].Nodes.Add(str);
        //        }
        //        // Else delete Client information from Tree View 
        //        else
        //        {
        //            foreach (TreeNode n in this.tvClientList.Nodes[0].Nodes)
        //            {
        //                if (n.Text.Equals(str))
        //                    this.tvClientList.Nodes.Remove(n);
        //            }
        //        }

        //    }
        //}

        public void DisconnectClient(String remoteIP, String remotePort)
        {
            // Delete Client from Tree View
           // UpdateClientList(remoteIP + " : " + remotePort, "Delete");

            // Find Client Chat Dialog box corresponding to this Socket
            int counter = 0;
            foreach (ChatDialog c in formArray)
            {
                String remoteIP1 = ((IPEndPoint)c.connectedClient.Client.RemoteEndPoint).Address.ToString();
                String remotePort1 = ((IPEndPoint)c.connectedClient.Client.RemoteEndPoint).Port.ToString();

                if (remoteIP1.Equals(remoteIP) && remotePort1.Equals(remotePort))
                {
                    break;
                }
                counter++;

            }

            // Terminate Chat Dialog Box
            ChatDialog cd = (ChatDialog)formArray[counter];
            formArray.RemoveAt(counter);

            ((Thread)(threadArray[counter])).Abort();
            threadArray.RemoveAt(counter);

        }
        #endregion

        public void send(byte[] bytes, string ip)
        {
            string IPadd = (((IPEndPoint)ctd.connectedClient.Client.RemoteEndPoint)).Address.ToString();
            if(ip== IPadd)
            {

            }
        }
    }
}