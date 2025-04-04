using AutoMapper;
using BookStore.Business.Dtos.Order;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        // Order -> OrderResponse
        CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
            
        // Order -> OrderSummaryResponse
        CreateMap<Order, OrderSummaryResponse>()
            .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.OrderItems.Count));
            
        // OrderItem -> OrderItemResponse
        CreateMap<OrderItem, OrderItemResponse>();
    }
} 