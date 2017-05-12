using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project6.Startup))]
namespace Project6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
