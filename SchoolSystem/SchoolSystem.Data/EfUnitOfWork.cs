using SchoolSystem.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public EfUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return this.context.SaveChanges() == 1;
        }

        public void Dispose()
        {
            //TODO: ASK VIKTOR!!!
            //this.context.Dispose(); ??
        }
    }
}
