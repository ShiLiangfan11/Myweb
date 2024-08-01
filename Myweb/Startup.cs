using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myweb.Startup))]
namespace Myweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
