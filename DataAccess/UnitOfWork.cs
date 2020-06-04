using DataAccess.Repositories;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork 
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IDoctorRepository _doctorRepository;
       

        private bool _disposed;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public UnitOfWork()
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        
        public IDoctorRepository DoctorRepository
        {
            get { return _doctorRepository ?? (_doctorRepository = new DoctorRepository(_transaction)); }
        }
        
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_transaction);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
    
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
            resetRepositories();           
        }


        private void resetRepositories()
        {
            _doctorRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}