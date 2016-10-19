using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCustomAttributeExample.Startup))]
namespace MvcCustomAttributeExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
