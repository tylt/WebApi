using DataAccess.Repositories;
using System;

namespace DataAccess
{
    public interface IUnitOfWork :IDisposable 
    {
        IDoctorRepository DoctorRepository { get; }
        IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;

        void Commit();
        void Rollback();
    }

}
