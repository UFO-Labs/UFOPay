using UFO.ProfileApi.DAOs;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Models;

namespace UFO.ProfileApi.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> CreateAsync(UserDTO userDTO);
    Task<bool> RemoveAsync(UserDAO userDAO);
    Task<bool> UpdateAsync(UserDTO userDTO);
    Task<UserModel> GetAsync(UserDAO userDAO);
}
