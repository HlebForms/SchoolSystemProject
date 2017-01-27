using Microsoft.Owin;
using Ninject;
using Owin;
using SchoolSystem.Web.Services.Auth.Contracts;
using SchoolSystem.WebForms.App_Start;

[assembly: OwinStartupAttribute(typeof(SchoolSystem.WebForms.Startup))]
namespace SchoolSystem.WebForms
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var auth = NinjectWebCommon.Kernel.Get<IAuthService>();
            auth.AuthConfig(app);
        }
    }
}
