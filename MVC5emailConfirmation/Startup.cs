using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5emailConfirmation.Startup))]
namespace MVC5emailConfirmation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
