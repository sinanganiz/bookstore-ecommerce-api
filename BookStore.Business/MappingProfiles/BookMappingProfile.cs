using AutoMapper;
using BookStore.Business.Dtos.Books.Requests;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Business.Dtos.Categories;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {

        // Her farklı nesne dönüşümü için ayrı mapping tanımı yapılır
        // Birebir aynı property isimleri otomatik eşleşir
        // Farklı isimli veya hesaplanması gereken propertiler için .ForMember() kullanılır


        //SourceClass, DestinationClass
        CreateMap<Book, BookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        // Farklı property isimlerini manuel eşleştirme
        CreateMap<Book, CreatedBookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        CreateMap<Book, UpdatedBookResponse>()
        .ForMember(dest => dest.CategoryResponse, opt => opt.MapFrom(src => src.Category));

        CreateMap<CreateBookRequest, Book>();


        // UpdateBookRequest'ten Book nesnesine mapping yaparken
        // Tüm property'ler için kontrol uygula
        // Sadece null olmayan property'leri map et

        // src: Kaynak nesne (UpdateBookRequest)
        // dest: Hedef nesne (Book)
        // sourceMember: İşlenen şu anki property'nin değeri

        // Kısmi güncellemelerde sadece gönderilen alanları günceller
        CreateMap<UpdateBookRequest, Book>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, sourceMember) => sourceMember != null)
            );


    }
}
