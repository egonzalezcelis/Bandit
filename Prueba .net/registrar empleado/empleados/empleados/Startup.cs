using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(empleados.Startup))]
namespace empleados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
