using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartupAttribute(typeof(CGA_WEB.Startup))]
namespace CGA_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            
        }
    }
}
