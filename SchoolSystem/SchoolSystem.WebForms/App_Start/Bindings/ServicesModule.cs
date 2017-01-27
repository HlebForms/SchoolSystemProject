using Ninject.Modules;
using SchoolSystem.Web.Services.Auth;
using SchoolSystem.Web.Services.Auth.Contracts;
using SchoolSystem.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthService>().To<AuthService>();
            this.Bind<Startup>().ToSelf();
        }
    }
}