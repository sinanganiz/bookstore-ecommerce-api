using AutoMapper;
using BookStore.Business.Dtos.Reviews;
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
