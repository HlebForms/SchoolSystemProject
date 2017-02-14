using Ninject.Modules;
using SchoolSystem.Web.Providers.Contracts;
using SchoolSystem.Web.Providers.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class ProvidersModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRandomProvider>().To<RandomProvider>();
        }
    }
}