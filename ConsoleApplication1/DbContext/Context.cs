using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ConsoleApplication1
{
    public class Context : DbContext
    {
        public Context()
            : base("name=chapter2")
        { 
            
        }

        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityMap.PersonMap());
            modelBuilder.Configurations.Add(new EntityMap.PersonTypeMap());
            modelBuilder.Configurations.Add(new EntityMap.StudentMap());
            modelBuilder.Configurations.Add(new EntityMap.AddressType());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        
    }
}
