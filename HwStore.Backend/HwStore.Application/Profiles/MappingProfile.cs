using AutoMapper;

using HwStore.Domain;

namespace HwStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto_Base>().ReverseMap();
            CreateMap<Product, ProductDto_Details>().ReverseMap();
            CreateMap<Product, ProductDto_Create>().ReverseMap();
            //CreateMap<Product, PagedList<ProductDto_Base>>();

            CreateMap<Category, CategoryDto_Base>().ReverseMap();
            CreateMap<Category, CategoryDto_Details>().ReverseMap();
            CreateMap<Category, CategoryDto_Upsert>().ReverseMap();

            CreateMap<Brand, BrandDto_Base>().ReverseMap();
            CreateMap<Brand, BrandDto_Detail>().ReverseMap();
            CreateMap<Brand, BrandDto_Upsert>().ReverseMap();

            CreateMap<Image, ImageDto_Base>().ReverseMap();
            CreateMap<Image, ImageDto_Upsert>().ReverseMap();

            CreateMap<Specification, SpecificationDto_Base>().ReverseMap();
            CreateMap<Specification, SpecificationDto_Upsert>().ReverseMap();
        }
    }
}
