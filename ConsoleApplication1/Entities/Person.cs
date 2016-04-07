using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApplication1.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal HeighInFeet { get; set; }
        public bool IsActive { get; set; }
        public int NumberOfCars { get; set; }
        public HashSet<Phone> Phones { get; set; }
        public int? PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual Student Student { get; set; }
        public Address Address { get; set; }
        public PersonState PersonState { get; set; }
        public byte[] Photo { get; set; }
        public byte[] FamilyPicture { get; set; }

        public string FullName {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set
            {
                var name = value.Split(new String[] { " " },
                    StringSplitOptions.RemoveEmptyEntries);
                FirstName = name[0];
                LastName = name[1];
            }
        }
        public Person()
        {
            Phones = new HashSet<Phone>();
            Address = new Address();
        }

        
    }
}
