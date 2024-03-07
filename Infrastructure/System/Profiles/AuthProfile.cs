using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;

namespace identity_base_api.Infrastructure.System.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile() 
    {
        CreateMap<LoginDto, Login>();
    }
}