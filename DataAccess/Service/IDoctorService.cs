using DataAccess.Entities;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAll();
    }
}
