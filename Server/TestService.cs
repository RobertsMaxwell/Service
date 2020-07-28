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

namespace Server
{
    public partial class TestService : ServiceBase
    {
        public TestService()
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
            eventLog1.WriteEntry("Started.", EventLogEntryType.Information);
            Timer timer = new Timer(60000);
            timer.Elapsed += this.OnTimer;
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stopped.", EventLogEntryType.Information);
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog1.WriteEntry("Timer Elapsed", EventLogEntryType.Information);
        }
    }
}
