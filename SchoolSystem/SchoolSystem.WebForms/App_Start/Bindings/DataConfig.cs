using System;

using Ninject.Modules;
using SchoolSystem.Data;
using System.Data.Entity;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Repositories;
using Ninject;

namespace SchoolSystem.WebForms.App_Start.Bindings
{
    public class DataConfig : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<DbContext>().To<SchoolSystemDbContext>().InSingletonScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<EfUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>().InSingletonScope();
        }
    }
}