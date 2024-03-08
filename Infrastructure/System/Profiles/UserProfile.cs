using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;

namespace identity_base_api.Infrastructure.System.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, GetUserDto>();
    }
}