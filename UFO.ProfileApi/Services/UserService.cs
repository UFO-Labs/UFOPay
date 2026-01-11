using Microsoft.AspNetCore.Identity;
using UFO.ProfileApi.DAOs;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Models;
using UFO.ProfileApi.Repositories.Interfaces;
using UFO.ProfileApi.Services.Interfaces;
using UFO.ProfileApi.Shared;
using UFO.ProfileApi.Shared.Exceptions;

namespace UFO.ProfileApi.Services;

public class UserService(IUserRepository userRepository, PasswordHasher<UserNameDAO> passwordHasher)
    : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly PasswordHasher<UserNameDAO> _passwordHasher = passwordHasher;

    public async Task<bool> CreateAsync(UserDTO userDTO)
    {
        if (
            await _userRepository.CreateAsync(
                new UserDTO(
                    userDTO.Username,
                    _passwordHasher.HashPassword(
                        new UserNameDAO(userDTO.Username),
                        userDTO.Password
                    ),
                    userDTO.Email
                )
            )
        )
        {
            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        return Task.CompletedTask.IsFaulted;
    }

    public async Task<TokenResponse> LoginAsync(UserLoginDAO user)
    {
        UserModel? findUser = await _userRepository.GetByUsernameAsync(
            new UserNameDAO(user.Username)
        );

        if (findUser is not null)
        {
            if (
                _passwordHasher.VerifyHashedPassword(
                    new UserNameDAO(user.Username),
                    findUser.Password,
                    user.Password
                ) == PasswordVerificationResult.Success
            )
            {
                // TODO: Make the JWT
                return new TokenResponse("token.");
            }
        }

        throw new UserException("The user exists!");
    }
}
