using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Entities
{
    public class Student
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public string CollageName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
