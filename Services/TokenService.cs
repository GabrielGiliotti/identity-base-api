using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using identity_base_api.Infrastructure.System.Extensions;
using identity_base_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace identity_base_api.Services;

public class TokenService : ITokenService
{
    private readonly IMapper _mapper;
    
    public TokenService(IMapper mapper) 
    {
        _mapper = mapper;
    }

    public string GenerateToken(User obj)
    {
        
        var claims = new Claim[] 
        {
            new Claim("Username", !string.IsNullOrEmpty(obj.UserName) ? obj.UserName : "empty"),
            new Claim("Id", obj.Id),
            new Claim("BirthDate", obj.BirthDate.ToString()),
            new Claim("Email", !string.IsNullOrEmpty(obj.Email) ? obj.Email : "empty"),
            new Claim("IsAdmin", obj.IsAdmin.ToString().ToLower())
        };

        var signingCredentials = new SigningCredentials(ServiceExtension.key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken 
        (
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddMinutes(30)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}