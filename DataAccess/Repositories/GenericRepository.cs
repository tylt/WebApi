using System.Data;
using System.Collections.Generic;
using DataAccess.Entities;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DataAccess.Repositories
{
    internal class GenericRepository<TEntity> : RepositoryBase,IGenericRepository<TEntity> where TEntity : class  
    {
        public GenericRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query, object parameters= null)
        {
            return await Connection.QueryAsync<TEntity>(
                query,
                param:parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }

        public IEnumerable<TEntity> GetAll(string query, object parameters)
        {
            return Connection.Query<TEntity>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }
        public Task<TEntity> FindAsync(string query, object parameters)
        {
            return Connection.QueryFirstAsync<TEntity>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }
        public TEntity Find(string query, object parameters)
        {
            return Connection.QueryFirst<TEntity>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }
        public Task<TEntity> InsertOrUpdateAsync(string query, object parameters)
        {
            return Connection.QueryFirstAsync<TEntity>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }
        public TEntity InsertOrUpdate(string query, object parameters)
        {
            return Connection.QueryFirst<TEntity>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: Transaction
            );
        }
    }
}
