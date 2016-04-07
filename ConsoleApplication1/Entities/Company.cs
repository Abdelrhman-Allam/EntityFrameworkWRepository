using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
        public Address Address { get; set; }

        public Company()
        {
            Persons = new HashSet<Person>();
            Address = new Address();            
        }
    }
}
