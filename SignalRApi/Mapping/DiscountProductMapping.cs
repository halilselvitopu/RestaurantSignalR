using AutoMapper;
using SignalR.DtoLayer.DiscountProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountProductMapping : Profile
    {
        public DiscountProductMapping()
        {
               CreateMap<DiscountProduct, ResultDiscountProductDto>().ReverseMap();
               CreateMap<DiscountProduct, GetDiscountProductDto>().ReverseMap();
               CreateMap<DiscountProduct, UpdateDiscountProductDto>().ReverseMap();
               CreateMap<DiscountProduct, CreateDiscountProductDto>().ReverseMap();
        }
    }
}
