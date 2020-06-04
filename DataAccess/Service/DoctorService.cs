using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Service
{
    public class DoctorService : IDoctorService
    {
        IUnitOfWork _unitOfWork;
        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _unitOfWork.DoctorRepository.GetAll();
        }
    }
}
