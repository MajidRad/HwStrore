using AutoMapper;
using HwStore.Application.DTOs.Basket;

namespace HwStore.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto_Base>().ReverseMap();
        CreateMap<Product, ProductDto_Details>().ReverseMap();
        CreateMap<Product, ProductDto_Create>().ReverseMap();



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

        CreateMap<Basket, BasketDto_Base>().ReverseMap();
        CreateMap<BasketItem, BasketItemDto>()
            .ForMember(p => p.Quantity, opt => opt.MapFrom(src => src.Product.Quantity))
            .ForMember(p => p.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(p => p.ImageUrl, opt => opt.MapFrom(src => src.Product.Images.First().Path)).ReverseMap();

    }
}
