using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZMWA.Startup))]
namespace ZMWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
