using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.User.Username));
            CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price));
        }
    }
}
