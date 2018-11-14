using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace WcfService1
{
    public class MyEventArgs : EventArgs
    {
#pragma warning disable IDE1006 // Naming Styles
        public TcpClient clientSock { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public MyEventArgs(TcpClient tcpClient)
        {
            clientSock = tcpClient;
        }
    }
}