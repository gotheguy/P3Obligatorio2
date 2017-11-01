using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProvEventos.Startup))]
namespace ProvEventos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
