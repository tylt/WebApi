using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Person
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonForId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string Identifier { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
