using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync(string query, object parameters);
        IEnumerable<TEntity> GetAll(string query, object parameters);
        Task<TEntity> FindAsync(string query, object parameters);
        TEntity Find(string query, object parameters);
        Task<TEntity> InsertOrUpdateAsync(string query, object parameters);
        TEntity InsertOrUpdate(string query, object parameters);
    }
}
