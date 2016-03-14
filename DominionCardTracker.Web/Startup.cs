using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DominionCardTracker.Web.Startup))]
namespace DominionCardTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
