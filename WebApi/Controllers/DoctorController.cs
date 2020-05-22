using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Entities;
using DataAccess.Service;
using System.Threading.Tasks;
using WebApi;

namespace WebApi.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly IDoctorService doctorService;
      
        public DoctorController(IDoctorService _doctorService)
        {
            doctorService = _doctorService;
        }

        // GET: api/Doctor
        public async Task<IEnumerable<Doctor>> Get()
        {
            return await doctorService.GetAll();
        }
        
    }
}
