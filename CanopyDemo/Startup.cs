using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CanopyDemo.Startup))]
namespace CanopyDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
