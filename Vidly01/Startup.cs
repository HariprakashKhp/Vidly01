using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly01.Startup))]
namespace Vidly01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
