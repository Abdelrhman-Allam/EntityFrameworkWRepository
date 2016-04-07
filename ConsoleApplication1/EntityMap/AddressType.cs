using ConsoleApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.EntityMap
{
    public class AddressType : ComplexTypeConfiguration<Address>
    {
        public AddressType()
        {
            Property(p => p.Street)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("Street");
        }
    }
}
