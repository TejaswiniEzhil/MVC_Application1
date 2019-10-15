using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Application1.Startup))]
namespace MVC_Application1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
