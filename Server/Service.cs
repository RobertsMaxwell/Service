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
            Listener listener = new Listener(1738);
            Thread thread = new Thread(new ThreadStart(listener.BeginStart)) { IsBackground = true };
            thread.Start();

            SendMessage("Started Listening...");
            while (listener.client == null)
            {
                Thread.Sleep(100);
            }

            SendMessage("Connected");
            Connection connection = new Connection(listener.client);
            connection.ReadInfo();

            /*Timer timer = new Timer(60000);
            timer.Elapsed += this.OnTimer;*/
        }

        protected override void OnStop()
        {
            SendMessage("Stopped.");
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            SendMessage("Timer Elapsed");
        }

        public void SendMessage(string mes)
        {
            eventLog1.WriteEntry(mes, EventLogEntryType.Information, eventID++);
        }
    }
}
