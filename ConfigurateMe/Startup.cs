using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfigurateMe.Startup))]
namespace ConfigurateMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
