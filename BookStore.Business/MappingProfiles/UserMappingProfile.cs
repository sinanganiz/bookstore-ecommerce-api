using AutoMapper;
using BookStore.Business.Dtos.Users;
using BookStore.Data.Entities;

namespace BookStore.Business.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        //SourceClass, DestinationClass
        CreateMap<AppUser, UserResponse>();
        CreateMap<AppUser, CreatedUserResponse>();
        CreateMap<AppUser, UpdatedUserResponse>();
       
        CreateMap<UpdateUserRequest, AppUser>();
        CreateMap<CreateUserRequestWithPassword, AppUser>()
        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

    }
}
