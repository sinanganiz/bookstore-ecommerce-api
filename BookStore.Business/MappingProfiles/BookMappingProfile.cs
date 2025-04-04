using AutoMapper;
using BookStore.Business.Dtos.Books.Requests;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        //SourceClass, DestinationClass
        CreateMap<Book, BookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        CreateMap<Book, CreatedBookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        CreateMap<Book, UpdatedBookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        CreateMap<CreateBookRequest, Book>();


        // Updates only submitted fields in partial updates
        CreateMap<UpdateBookRequest, Book>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, sourceMember) => sourceMember != null)
            );


    }
}
