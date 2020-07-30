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
            SendMessage("Started.");
            listener = new Listener(1738);
            Thread thread = new Thread(new ThreadStart(listener.BeginListening)) { IsBackground = true };
            thread.Start();

            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            SendMessage("Stopped.");
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            if (listener.client != null)
            {
                Connection connection = new Connection(listener.client);
                connection.ReadInfo();
            }
        }

        public void SendMessage(string mes)
        {
            eventLog1.WriteEntry(mes, EventLogEntryType.Information, eventID++);
        }
    }
}
