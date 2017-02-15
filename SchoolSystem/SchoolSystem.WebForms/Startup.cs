using Owin;
using Microsoft.Owin;
using SchoolSystem.Identity.Configurations;
using SchoolSystem.WebForms.App_Start;
using Ninject;

[assembly: OwinStartupAttribute(typeof(SchoolSystem.WebForms.Startup))]
namespace SchoolSystem.WebForms
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var identity = NinjectWebCommon.Kernel.Get<IdentityConfig>();
            identity.Config(app);
        }
    }
}
