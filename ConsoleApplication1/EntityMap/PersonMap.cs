using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Entities;

namespace ConsoleApplication1.EntityMap
{
    class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            Map(p =>
            {
                p.Properties(ph =>
                    new {
                        ph.Photo,
                        ph.FamilyPicture
                    });

                p.ToTable("PersonBlob");
            });

            Map(p => {
                p.Properties(ph => new
                {
                    ph.Address,
                    ph.BirthDate,
                    ph.FirstName,
                    ph.HeighInFeet,
                    ph.IsActive,
                    ph.LastName,
                    ph.MiddleName,
                    ph.PersonState,
                    ph.PersonTypeId,
                    ph.NumberOfCars
                });
                p.ToTable("Person");
            });
            
            Property(p => p.FirstName)
                .HasMaxLength(30);
            Property(p => p.LastName)
                .HasMaxLength(30);
            Property(p => p.MiddleName)
                .HasMaxLength(1)
                .IsFixedLength()
                .IsUnicode(false);
            Property(p => p.HeighInFeet)
                .HasPrecision(4, 2);
            Property(p => p.Photo)
                .IsVariableLength()
                .HasMaxLength(4000);

            HasMany(p => p.Phones)
                .WithRequired();
                //.HasForeignKey(ph => ph.PersonId);

            HasMany(p => p.Companies)
                .WithMany(c => c.Persons)
                .Map(m =>
                {
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("CompanyId");
                });

            Ignore(p => p.FullName);
        }
    }
}
