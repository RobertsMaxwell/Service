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

        private bool searching = true;

        public Listener(int port)
        {
            this.port = port;
            listener = new TcpListener(port);
        }

        public void BeginListening()
        {
            listener.Start();
            while (true)
            {
                Thread.Sleep(10);
                ServerMain.service.SendMessage("Listening...");
                client = listener.AcceptTcpClient();
                ServerMain.service.SendMessage("Connected!");
            }
        }

        public void EndStart()
        {
            searching = false;
            client = null;
        }
    }
}
