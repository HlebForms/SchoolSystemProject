using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using SchoolSystem.Data.Models;

namespace SchoolSystem.Data.Contracts
{
    public interface ISchoolSystemDBContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Teacher> Teachers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
