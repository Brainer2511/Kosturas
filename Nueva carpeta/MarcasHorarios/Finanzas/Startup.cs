using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finanzas.Startup))]
namespace Finanzas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
