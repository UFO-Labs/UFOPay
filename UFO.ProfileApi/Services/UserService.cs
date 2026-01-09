using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Repositories.Interfaces;
using UFO.ProfileApi.Services.Interfaces;

namespace UFO.ProfileApi.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<bool> CreateAsync(UserDTO userDTO)
    {
        // TODO: Make the hashed password
        if (await _userRepository.CreateAsync(userDTO))
        {
            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        return Task.CompletedTask.IsFaulted;
    }
}
