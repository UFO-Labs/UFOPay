using UFO.ProfileApi.DTOs;

namespace UFO.ProfileApi.Services.Interfaces;

public interface IUserService
{
    Task<bool> CreateAsync(UserDTO userDTO);
}
