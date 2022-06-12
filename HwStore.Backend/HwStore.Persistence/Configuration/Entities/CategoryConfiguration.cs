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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Cpu", ParentCategoryId = 1 },
                new Category { Id = 2, Name = "Ram", ParentCategoryId = 1 },
                new Category { Id = 3, Name = "Vga", ParentCategoryId = 1 }

                );
        }
    }
}
