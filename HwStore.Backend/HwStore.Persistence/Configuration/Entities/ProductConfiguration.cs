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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany<Image>(p => p.Images);
            builder.HasData(

                new Product
                {
                    Id = 1,
                    Name = "6800XT",
                    BrandId = 1,
                    CategoryId = 3,
                    Price = 800,
                    Quantity = 3,
                    Description = "Get the ultimate game changer. AMD Radeon™ RX 6800 XT" +
                    " graphics card features breakthrough AMD RDNA™ 2 architecture. "
                },
                new Product
                {
                    Id = 2,
                    Name = "6700XT",
                    BrandId = 1,
                    CategoryId = 3,
                    Price = 700,
                    Quantity = 2,
                    Description = "Get the ultimate game changer. AMD Radeon™ RX 6700 XT" +
                    " graphics card features breakthrough AMD RDNA™ 2 architecture. "
                },
                new Product
                {
                    Id = 3,
                    Name = "RTX 3070",
                    BrandId = 3,
                    CategoryId = 3,
                    Price = 850,
                    Quantity = 2,
                    Description = "The GeForce RTX™ 3070 is powered by Ampere—NVIDIA's " +
                    "2nd gen RTX architecture."
                },
                new Product
                {
                    Id = 4,
                    Name = "Ryzen 7 5800X",
                    BrandId = 2,
                    CategoryId = 1,
                    Price = 500,
                    Quantity = 4,
                    Description = "AMD Ryzen 7 5800X - Ryzen 7 5000 Series Vermeer (Zen 3)" +
                    " 8-Core 3.8 GHz Socket AM4 105W Desktop Processor "
                },
                new Product
                {
                    Id = 5,
                    Name = "Ryzen 7 5700X",
                    BrandId = 1,
                    CategoryId = 1,
                    Price = 400,
                    Quantity = 5,
                    Description = "AMD Ryzen 7 5700X - Ryzen 7 5000 Series Vermeer (Zen 3)" +
                    " 8-Core 3.4 GHz Socket AM4 105W Desktop Processor -"
                },
                new Product
                {
                    Id = 6,
                    Name = "12700K",
                    BrandId = 2,
                    CategoryId = 1,
                    Price = 450,
                    Quantity = 5,
                    Description = "Intel Core i7-12700K - Core i7 12th Gen Alder Lake" +
                    " 12-Core (8P+4E) 3.6 GHz LGA 1700 125W Intel UHD Graphics 770"
                },
                new Product
                {
                    Id = 7,
                    Name = "11900K",
                    BrandId = 2,
                    CategoryId = 1,
                    Price = 450,
                    Quantity = 2,
                    Description = "Intel Core i9-11900K - Core i9 11th Gen Rocket Lake" +
                    " 8-Core 3.5 GHz LGA 1200 125W Intel UHD Graphics 750 Desktop Processor "
                },
                new Product
                {
                    Id = 8,
                    Name = "Vengeance RGB Pro",
                    BrandId = 4,
                    CategoryId = 2,
                    Price = 100,
                    Quantity = 10,
                    Description = "Vengeance RGB Pro 16GB (2 x 8GB) Timing: 16-18-18-36  "
                }
                );
        }
    }
}
