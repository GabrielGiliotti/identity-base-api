using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;
using identity_base_api.Repositories;

namespace identity_base_api.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly ITokenService _tokenService;

    private readonly IMapper _mapper;
    
    public AuthService(IMapper mapper, IAuthRepository repository, ITokenService tokenService) 
    {
        _mapper = mapper;
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var login = _mapper.Map<Login>(dto);

        if(login is not null) 
        {
            var result = await _repository.LoginAsync(login);

            if(!result.Succeeded)
                throw new Exception("Error when attempting to login");

            var user = _repository.GetAuthenticatedUser(login);

            if(user is not null) 
                return _tokenService.GenerateToken(user);
                        
                        
            throw new Exception("Error during token generation");
        }
        else
            throw new Exception("Error serializing login data");

    }
}