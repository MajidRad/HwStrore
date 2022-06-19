using AutoMapper;
using HwStore.Application.DTOs.Brand;
using HwStore.Application.DTOs.Category;
using HwStore.Application.DTOs.Product;
using HwStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto_Base>().ReverseMap();
            CreateMap<Product, ProductDto_Details>().ReverseMap();

            CreateMap<Category, CategoryDto_Base>().ReverseMap();
            CreateMap<Category, CategoryDto_Details>().ReverseMap();

            CreateMap<Brand, BrandDto_Base>().ReverseMap();
            CreateMap<Brand, BrandDto_Detail>().ReverseMap();
        }
    }
}
