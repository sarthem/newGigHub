using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newGigHub.Startup))]
namespace newGigHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
