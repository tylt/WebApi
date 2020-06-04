using DataAccess.Entities;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface IGenericService<TEntity> where TEntity : class  
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string query, object parameters);
        IEnumerable<TEntity> GetAll(string query, object parameters);
        Task<TEntity> FindAsync(string query, object parameters);
        TEntity Find(string query, object parameters);
        Task<TEntity> InsertOrUpdateAsync(string query, object parameters);
        TEntity InsertOrUpdate(string query, object parameters);
    }
}
