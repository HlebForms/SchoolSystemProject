using System;

using SchoolSystem.Data;
using System.Data.Entity;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Repositories;

using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class DataConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<SchoolSystemDbContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();
        }
    }
}