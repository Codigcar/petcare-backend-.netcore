using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class ProviderRepresentativeConfig
    {
        public ProviderRepresentativeConfig(EntityTypeBuilder<ProviderRepresentative> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Position).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Phone1).IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Phone2).IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Direction).IsRequired();


        }
    }
}
