using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrashTest.Startup))]
namespace CrashTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
