using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(musicWebApplication.Startup))]
namespace musicWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
