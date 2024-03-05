using AutoMapper;
using identity_base_api.DTOs;
using identity_base_api.Models;
using identity_base_api.Repositories;

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

    public async Task AddUserAsync(CreateUserDto dto)
    {
        var user = _mapper.Map<User>(dto);

        if(user != null)
            await _repository.AddAsync(user);
        else
            throw new Exception("Error when adding User");
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(int skip, int take)
    {
        var users = await _repository.GetAllAsync(skip, take);
        
        var list = _mapper.Map<IEnumerable<UserDto>>(users);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping User List");
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<UserDto>(user);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping UserDto");
    }

    public async Task UpdateUserAsync(UpdateUserDto obj, int id)
    {
        var toUpdate = await _repository.GetByIdAsync(id) ?? throw new Exception("User not found");
        
        // if (!string.IsNullOrEmpty(obj.Title) && toUpdate.Title != obj.Title) 
        // {
        //     toUpdate.Title = obj.Title;
        // }

        // if(!string.IsNullOrEmpty(obj.Genre) && toUpdate.Genre != obj.Genre) 
        // {
        //     toUpdate.Genre = obj.Genre;
        // }

        // if(!string.IsNullOrEmpty(obj.Director) && toUpdate.Director != obj.Director) 
        // {
        //     toUpdate.Director = obj.Director;
        // }

        // if(obj.Duration != null && toUpdate.Duration != obj.Duration) 
        // {
        //     toUpdate.Duration = (int)obj.Duration;
        // }

        await _repository.UpdateAsync(toUpdate, id);
    }

    public async Task DeleteUserAsync(int id) 
    {
        var movie = await _repository.GetByIdAsync(id);

        if(movie == null)
            throw new Exception("User not found");

        await _repository.RemoveAsync(id);
    }
}