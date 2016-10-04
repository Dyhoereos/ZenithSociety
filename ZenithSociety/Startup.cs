using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenithSociety.Startup))]
namespace ZenithSociety
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
