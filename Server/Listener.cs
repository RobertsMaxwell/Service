using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

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
            listener.Start(1);
        }

        public void BeginStart()
        {
            searching = true;
            while (searching)
            {
                TcpClient cl = listener.AcceptTcpClient();

                if (cl.Connected)
                {
                    client = cl;
                    return;
                }
            }
        }

        public void EndStart()
        {
            searching = false;
            client = null;
        }
    }
}
