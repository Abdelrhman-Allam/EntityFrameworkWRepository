using ConsoleApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.EntityMap
{
    public class PersonTypeMap : EntityTypeConfiguration<PersonType>
    {
        public PersonTypeMap()
        {
            ToTable("TypeOfPerson");
            HasMany(pt => pt.Persons)
                .WithOptional(p => p.PersonType)
                .HasForeignKey(p => p.PersonTypeId)
                .WillCascadeOnDelete(false);

            
        }
    }
}
