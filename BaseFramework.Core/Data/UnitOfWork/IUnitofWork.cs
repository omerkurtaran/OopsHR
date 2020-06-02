using BaseFramework.Core.Data.Repository;
using System;

namespace BaseFramework.Core.Data.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
