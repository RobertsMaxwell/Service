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
        public TcpListener listener;

        public bool searching = false;

        public Listener(int port)
        {
            this.port = port;
            listener = new TcpListener(port);
        }

        public TcpClient BeginListening()
        {
            listener.Start();

            TcpClient client = listener.AcceptTcpClient();

            ServerMain.service.SendMessage("Connected!");
            return client;
        }
    }
}
