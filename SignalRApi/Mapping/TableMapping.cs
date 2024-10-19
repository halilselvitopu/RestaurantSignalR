using AutoMapper;
using SignalR.DtoLayer.TableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TableMapping : Profile
    {
        public TableMapping()
        {
            CreateMap<Table, CreateTableDto>().ReverseMap();
            CreateMap<Table, GetTableDto>().ReverseMap();
            CreateMap<Table, ResultTableDto>().ReverseMap();
            CreateMap<Table, UpdateTableDto>().ReverseMap();
        }
    }
}
