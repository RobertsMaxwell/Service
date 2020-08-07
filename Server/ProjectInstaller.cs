using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.Management;

namespace Server
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_Committed(object sender, InstallEventArgs e)
        {
            /*ConnectionOptions co = new ConnectionOptions();
            co.Impersonation = ImpersonationLevel.Impersonate;

            ManagementScope ms = new ManagementScope(@"root\cimv2", co);
            ms.Connect();

            ManagementObject wmi = new ManagementObject("Win32_Service.Name='" + serviceInstaller1.ServiceName + "'");

            ManagementBaseObject wmiParams = wmi.GetMethodParameters("Change");
            wmiParams["DesktopInteract"] = true;
            ManagementBaseObject wmiInvoke = wmi.InvokeMethod("Change", wmiParams, null);*/
        }
    }
}
