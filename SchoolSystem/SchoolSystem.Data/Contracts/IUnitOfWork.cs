using System;

namespace SchoolSystem.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
