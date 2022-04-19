using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Licenta.Startup))]
namespace Licenta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
