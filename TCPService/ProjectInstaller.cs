using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace TCPService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            serviceInstaller1.Parent = this;
            serviceProcessInstaller1.Parent = this;
            this.AfterInstall += new InstallEventHandler(serviceInstaller1_AfterInstall);
        }

       void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController serviceController = new ServiceController(serviceInstaller1.ServiceName);
        }
    }
}
