using UFO.ProfileApi.DAOs;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Shared;

namespace UFO.ProfileApi.Services.Interfaces;

public interface IUserService
{
    Task<bool> CreateAsync(UserDTO userDTO);
    Task<TokenResponse> LoginAsync(UserLoginDAO userLoginDAO);
}
