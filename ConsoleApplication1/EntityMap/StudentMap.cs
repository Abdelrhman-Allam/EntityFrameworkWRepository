using ConsoleApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.EntityMap
{
    class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasRequired(s => s.Person)
                .WithOptional(p => p.Student);

            HasKey(s => s.PersonId);
            Property(s => s.CollageName)
                .HasMaxLength(50)
                .IsRequired();



        }
    }
}
