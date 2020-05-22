using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Service;

namespace WebApi.Models
{
    public class DoctorSingletonTest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public List<DoctorSingletonTest> DoctorList { get; set; } = new List<DoctorSingletonTest>();

        private DoctorSingletonTest()
        {
        }

        public static DoctorSingletonTest obj;
        public static DoctorSingletonTest GetInstance()
        {
            if (obj == null)
            {
                obj = new DoctorSingletonTest();

            }
            return obj;
        }

    }
}