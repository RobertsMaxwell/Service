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
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public partial class Service : ServiceBase
    {
        private int eventID = 0;
        private Listener listener;
        private Thread timerThread;
        System.Timers.Timer timer;

        public Service()
        {
            InitializeComponent();

            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("ServiceSource"))
            {
                EventLog.CreateEventSource("ServiceSource", "ServiceLog");
            }
            eventLog1.Source = "ServiceSource";
            eventLog1.Log = "ServiceLog";
        }

        protected override void OnStart(string[] args)
        {
            listener = new Listener(1738);

            timer = new System.Timers.Timer(10);
            timer.Elapsed += new ElapsedEventHandler(OnTimer);

            timerThread = new Thread(new ThreadStart(timer.Start)) { IsBackground = true };
            timerThread.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
            listener.Stop();
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            if (listener.client == null)
            {
                listener.BeginListening();
            }
            else if (listener.client != null)
            {
                Connection connection = new Connection(listener.client);
                listener.client = null;

                while (connection.client.Connected)
                {
                    SendMessage("READING");
                    string info = connection.ReadInfo();
                    
                    if (!string.IsNullOrEmpty(info))
                    {
                        SendMessage("Info:" + info);
                    }
                    //Manipulate.DoAction(info.Trim());
                    /*byte[] returnBytes = Encoding.ASCII.GetBytes(Manipulate.DoAction(info).ToString());
                    connection.client.GetStream().Write(returnBytes, 0, returnBytes.Length);*/
                    Thread.Sleep(100);
                }
            }
        }

        public void SendMessage(string mes)
        {
            eventLog1.WriteEntry(mes, EventLogEntryType.Information, eventID++);
        }
    }
}
