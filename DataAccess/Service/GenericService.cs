using DataAccess.Entities;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace DataAccess.Service
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query, object parameters)
        {
            using (_unitOfWork)
            {
                return await _unitOfWork.GenericRepository<TEntity>().GetAllAsync(query, parameters);
            }
        }

        public IEnumerable<TEntity> GetAll(string query, object parameters)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.GenericRepository<TEntity>().GetAll(query, parameters);
            }
        }

        public async Task<TEntity> FindAsync(string query, object parameters)
        {
            using (_unitOfWork)
            {
                return await _unitOfWork.GenericRepository<TEntity>().FindAsync(query, parameters);
            }
        }

        public TEntity Find(string query, object parameters)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.GenericRepository<TEntity>().Find(query, parameters);
            }
        }

        public async Task<TEntity> InsertOrUpdateAsync(string query, object parameters)
        {
            using (_unitOfWork)
            {
                var result = await _unitOfWork.GenericRepository<TEntity>().InsertOrUpdateAsync(query, parameters);
                _unitOfWork.Commit();
                return result;
            }
        }

        public TEntity InsertOrUpdate(string query, object parameters)
        {
            using (_unitOfWork)
            {
                var result = _unitOfWork.GenericRepository<TEntity>().InsertOrUpdate(query, parameters);
                _unitOfWork.Commit();
                return result;
            }
        }
    }
}
