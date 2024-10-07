using AutoMapper;
using SignalR.DtoLayer.FeatureProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureProductMapping : Profile
    {
        public FeatureProductMapping()
        {
               CreateMap<FeatureProduct, ResultFeatureProductDto>().ReverseMap();
               CreateMap<FeatureProduct, GetFeatureProductDto>().ReverseMap();
               CreateMap<FeatureProduct, UpdateFeatureProductDto>().ReverseMap();
               CreateMap<FeatureProduct, CreateFeatureProductDto>().ReverseMap();
        }
    }
}
