using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(net_shop_luismiguel_ortiz.Startup))]
namespace net_shop_luismiguel_ortiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
