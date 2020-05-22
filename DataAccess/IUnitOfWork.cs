using DataAccess.Repositories;
using System;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository DoctorRepository { get; }
    
        void Commit();
        void Rollback();
    }

}
