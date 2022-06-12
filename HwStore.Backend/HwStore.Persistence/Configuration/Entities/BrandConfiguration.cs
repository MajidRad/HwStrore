using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Configuration.Entities
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = 1, Name = "Amd" },
                new Brand { Id = 2, Name = "Intel" },
                new Brand { Id = 3, Name = "Nvidia" },
                new Brand { Id = 4, Name = "CorsAir" }
                );
        }
    }
}
