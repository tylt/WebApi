using System.Data;
using System.Collections.Generic;
using DataAccess.Entities;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DataAccess.Repositories
{
    internal class DoctorRepository : RepositoryBase, IDoctorRepository
    {
        public DoctorRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await Connection.QueryAsync<Doctor>(
                "SELECT employee_id Id, employee_name FullName, employee_email Email FROM js.Contract",
                transaction: Transaction
            );
        }
    
        public void Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Doctor Find(int id)
        {
            return Connection.Query<Doctor>(
                "SELECT employee_id Id, employee_name FullName, employee_email Email FROM Js.Contract WHERE employee_id = @Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }


        public Doctor FindByName(string name)
        {
            return Connection.Query<Doctor>(
                "SELECT employee_id Id, employee_name FullName, employee_email Email FROM js.contract WHERE employee_name = @Name",
                param: new { Name = name },
                transaction: Transaction
            ).FirstOrDefault();
        }

    }
}
