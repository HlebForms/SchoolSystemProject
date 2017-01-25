using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolSystem.WebForms.Startup))]
namespace SchoolSystem.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
