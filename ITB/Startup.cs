using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITB.Startup))]
namespace ITB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
