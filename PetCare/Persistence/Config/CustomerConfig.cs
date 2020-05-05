using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class CustomerConfig
    {
        public CustomerConfig(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(30);


        }

    }
}
