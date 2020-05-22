using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IDoctorRepository
    {
        void Add(Doctor entity);
        Task<IEnumerable<Doctor>> GetAll();
        void Delete(int id);
        Doctor Find(int id);
        Doctor FindByName(string name);
        void Update(Doctor entity);
    }
}
