using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    class Connection
    {
        TcpClient client;
        bool reading;

        public Connection(TcpClient cl)
        {
            client = cl;
            Thread readThread = new Thread(new ThreadStart(ReadInfo)) { IsBackground = true };
            readThread.Start();
        }

        public void ReadInfo()
        {
            reading = true;
            while (reading)
            {
                using (NetworkStream str = client.GetStream())
                {
                    string streamData = "";
                    while (str.DataAvailable)
                    {
                        byte[] info = new byte[1];
                        str.Read(info, 0, info.Length);
                        streamData += info;
                    }

                    ServerMain.service.SendMessage(streamData);

                    str.Flush();
                }
            }
        }
    }
}
