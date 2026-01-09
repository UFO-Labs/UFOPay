using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UFO.ProfileApi.DAOs;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Exceptions;
using UFO.ProfileApi.Models;
using UFO.ProfileApi.Repositories.Interfaces;

namespace UFO.ProfileApi.Repositories;

public class UserRepository(ProfileDbContext context, PasswordHasher<UserDAO> passwordHasher)
    : IUserRepository
{
    private readonly ProfileDbContext _context = context;
    private readonly PasswordHasher<UserDAO> _passwordHasher = passwordHasher;

    public async Task<bool> CreateAsync(UserDTO userDTO)
    {
        if (await GetAsync(new UserDAO(userDTO.Email)) is null)
        {
            await _context.Users.AddAsync(
                new UserModel(
                    userDTO.Username,
                    _passwordHasher.HashPassword(new UserDAO(userDTO.Email), userDTO.Password),
                    userDTO.Email
                )
            );
            await _context.SaveChangesAsync();

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        throw new UserException("The user exists!");
    }

    public async Task<UserModel> GetAsync(UserDAO userDAO)
    {
        return await _context.Users.FirstOrDefaultAsync(i => i.Email == userDAO.Email);
    }

    public async Task<bool> RemoveAsync(UserDAO userDAO)
    {
        var findUser = await GetAsync(userDAO);

        if (findUser is not null)
        {
            _context.Users.Remove(findUser);
            await _context.SaveChangesAsync();

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        throw new UserException("User not found!");
    }

    public async Task<bool> UpdateAsync(UserDTO userDTO)
    {
        var findUser = await GetAsync(new UserDAO(userDTO.Email));

        if (findUser is not null)
        {
            findUser.Username = userDTO.Username;
            findUser.Email = userDTO.Email;

            await _context.SaveChangesAsync();

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        throw new UserException("User not found!");
    }
}
