using System;
using System.Threading.Tasks;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebCresij.Hubsfile.Startup))]

namespace WebCresij.Hubsfile
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            app.MapSignalR();
        }
    }
}
