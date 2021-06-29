using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IceCreamShop.WebMVC.Startup))]
namespace IceCreamShop.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
