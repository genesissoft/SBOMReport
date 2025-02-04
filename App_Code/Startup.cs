using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBOMReport.Startup))]
namespace SBOMReport
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
