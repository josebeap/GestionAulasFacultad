using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionAulasFacultad.Startup))]
namespace GestionAulasFacultad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
