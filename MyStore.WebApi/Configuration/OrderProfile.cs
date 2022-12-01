using AutoMapper;
using MyStore.Core.Entities;
using MyStore.WebApi.DTOs;

namespace MyStore.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<ResultOrderDto, Order>().ReverseMap();
        }
    }
}
