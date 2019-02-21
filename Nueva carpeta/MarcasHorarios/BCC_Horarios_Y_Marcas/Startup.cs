using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCC_Horarios_Y_Marcas.Startup))]
namespace BCC_Horarios_Y_Marcas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
