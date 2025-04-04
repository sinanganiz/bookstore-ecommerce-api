using AutoMapper;
using BookStore.Business.Dtos.Cart;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        //SourceClass, DestinationClass
        CreateMap<Cart, CartResponse>()
            .ForMember(dest => dest.TotalAmount,
            opt => opt.MapFrom(src => src.CartItems.Sum(ci => ci.Quantity * ci.UnitPrice)));

        CreateMap<CartItem, CartItemResponse>()
        .ForMember(dest => dest.TotalPrice,
        opt => opt.MapFrom(src => src.Quantity * src.UnitPrice));
    }
}
