using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcUoWAutomNin.MVC.Startup))]
namespace MvcUoWAutomNin.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
