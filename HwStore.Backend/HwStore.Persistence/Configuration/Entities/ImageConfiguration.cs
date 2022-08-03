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
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.Images).HasForeignKey(x => x.ProductId);
            builder.HasData(
                new Image { Id=1,Name= "6800XT" ,ProductId=1,Path=$"images/product/6800XT-1"},
                new Image { Id=2,Name= "6700XT", ProductId=2,Path=$"images/product/6700XT-1" },
                new Image { Id=3,Name= "RTX 3070", ProductId=3,Path=$"images/product/RTX-3070-1" },
                new Image 
                { Id=4,Name= "5800X", ProductId=4,Path=$"images/product/5800X-1" },
                new Image 
                { Id=5,Name= "5700X", ProductId=5,Path=$"images/product/5700X-1" },
                new Image { Id=6,Name= "12700K", ProductId=6,Path=$"images/product/12700K-1" },
                new Image { Id=7,Name= "11900K", ProductId=7,Path=$"images/product/11900K-1" },
                new Image { Id=8,Name= "Vengeance", ProductId=8,Path=$"images/product/Vengeance-1" }
                );
        }
    }
}
