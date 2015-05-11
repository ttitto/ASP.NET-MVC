using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TtitterMvc.Startup))]
namespace TtitterMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
