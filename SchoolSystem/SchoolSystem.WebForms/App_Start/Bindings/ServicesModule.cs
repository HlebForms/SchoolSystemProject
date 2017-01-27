using Ninject.Modules;
using SchoolSystem.Web.Services.Auth;
using SchoolSystem.Web.Services.Auth.Contracts;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthService>().To<AuthService>();
        }
    }
}