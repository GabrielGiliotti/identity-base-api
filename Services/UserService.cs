using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;
using identity_base_api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper, IUserRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IdentityResult> AddUserAsync(CreateUserDto dto)
    {
        var user = _mapper.Map<User>(dto);

        if(user != null)
            return await _repository.AddUserAsync(user, dto.Password);
        else
            throw new Exception("Error when adding User");
    }
}