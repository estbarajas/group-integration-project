using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaDelivery.Startup))]
namespace PizzaDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
