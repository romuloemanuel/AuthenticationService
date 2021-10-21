using System;

namespace AuthenticationService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Commit();
        void Rollback();
    }
}
