using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LemonadeStand.Web.Startup))]
namespace LemonadeStand.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
