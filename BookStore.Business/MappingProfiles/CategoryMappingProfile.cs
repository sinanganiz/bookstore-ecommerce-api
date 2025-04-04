using AutoMapper;
using BookStore.Business.Dtos.Categories;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {

        //SourceClass, DestinationClass
        CreateMap<Category, CategoryResponse>();
        CreateMap<Category, CreatedCategoryResponse>();
        CreateMap<Category, UpdatedCategoryResponse>();

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();



    }
}
