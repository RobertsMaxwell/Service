using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Listener
    {
        public int port;
        public TcpClient client;
        public TcpListener listener;

        public bool searching = true;

        public Listener(int port)
        {
            this.port = port;
            listener = new TcpListener(port);
        }

        public void BeginListening()
        {
            listener.Start();
            searching = true;
            while (searching)
            {
                Thread.Sleep(10);
                client = listener.AcceptTcpClient();
                ServerMain.service.SendMessage("Connected!");
                return;
            }
        }

        public void Stop()
        {
            searching = false;
            client = null;
        }
    }
}
