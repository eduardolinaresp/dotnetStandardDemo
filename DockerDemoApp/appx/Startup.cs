using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DockerDemoApp.Startup))]
namespace DockerDemoApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
