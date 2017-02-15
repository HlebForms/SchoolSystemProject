using Ninject.Modules;
using SchoolSystem.Identity.Configurations;
using SchoolSystem.Web.Providers.Contracts;
using SchoolSystem.Web.Providers.Providers;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class ProvidersModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IdentityConfig>().ToSelf();
            this.Bind<IRandomProvider>().To<RandomProvider>();
        }
    }
}