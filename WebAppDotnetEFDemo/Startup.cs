using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppDotnetEFDemo.Startup))]
namespace WebAppDotnetEFDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
