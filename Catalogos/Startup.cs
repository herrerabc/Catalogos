using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catalogos.Startup))]
namespace Catalogos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
