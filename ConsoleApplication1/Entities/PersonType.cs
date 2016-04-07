using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Entities
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
