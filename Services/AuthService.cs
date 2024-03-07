using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;
using identity_base_api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IMapper _mapper;
    
    public AuthService(IMapper mapper, IAuthRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<SignInResult> LoginAsync(LoginDto dto)
    {
        var login = _mapper.Map<Login>(dto);

        if(login != null)
            return await _repository.LoginAsync(login);
        else
            throw new Exception("Error when adding User");
    }
}