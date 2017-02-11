using SchoolSystem.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SchoolSystem.Data.Contracts
{
    public interface ISchoolSystemDBContext
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Teacher> Teachers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
