using AutoMapper;
using BookStore.Business.Dtos.Books.Requests;
using BookStore.Business.Dtos.Books.Responses;
using BookStore.Business.Dtos.Categories;
using BookStore.Business.Dtos.Reviews;
using BookStore.Business.Dtos.Users;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        //SourceClass, DestinationClass
        CreateMap<Review, ReviewResponse>();
        CreateMap<Review, CreatedReviewResponse>();
        CreateMap<Review, UpdatedReviewResponse>();

        CreateMap<UpdateReviewRequest, Review>();
        CreateMap<CreateReviewRequest, Review>();



    }
}
