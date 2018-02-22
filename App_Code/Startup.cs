using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RCSP_Tree_Identification.Startup))]
namespace RCSP_Tree_Identification
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
