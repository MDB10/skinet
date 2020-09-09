using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(Destination => Destination.ProductBrand, option => option.MapFrom(source => source.ProductBrand.Name))
                .ForMember(Destination => Destination.ProductType, option => option.MapFrom(source => source.ProductType.Name))
                .ForMember(destination => destination.PictureUrl, option => option.MapFrom<ProductUrlResolver>());

        }
    }
}