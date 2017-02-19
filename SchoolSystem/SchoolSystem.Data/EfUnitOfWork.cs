using System.Data.Entity;
using SchoolSystem.Data.Contracts;

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
            return this.context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            // Let ninject do it 
        }
    }
}
