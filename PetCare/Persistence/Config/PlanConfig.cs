using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class PlanConfig
    {
        public PlanConfig(EntityTypeBuilder<Plan> entityBuilder)
        {
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Price).IsRequired();
            entityBuilder.Property(x => x.Duration).IsRequired();

           

        }
    }
}
