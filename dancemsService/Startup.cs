using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DanceMS.Startup))]

namespace DanceMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}