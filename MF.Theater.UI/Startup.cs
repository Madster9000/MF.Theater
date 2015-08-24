using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MF.Theater.UI.Startup))]
namespace MF.Theater.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
