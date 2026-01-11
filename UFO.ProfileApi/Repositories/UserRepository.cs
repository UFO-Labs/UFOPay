using Microsoft.EntityFrameworkCore;
using UFO.ProfileApi.DAOs;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Models;
using UFO.ProfileApi.Repositories.Interfaces;
using UFO.ProfileApi.Shared.Exceptions;

namespace UFO.ProfileApi.Repositories;

public class UserRepository(ProfileDbContext context) : IUserRepository
{
    private readonly ProfileDbContext _context = context;

    public async Task<bool> CreateAsync(UserDTO userDTO)
    {
        if (await GetByEmailAsync(new UserEmailDAO(userDTO.Email)) is null)
        {
            await _context.Users.AddAsync(
                new UserModel(userDTO.Username, userDTO.Password, userDTO.Email)
            );
            await _context.SaveChangesAsync();

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

        throw new UserException("The user exists!");
    }

    public async Task<UserModel> GetByEmailAsync(UserEmailDAO userDAO)
    {
        return await _context.Users.FirstOrDefaultAsync(i => i.Email == userDAO.Email);
    }

    public async Task<UserModel> GetByUsernameAsync(UserNameDAO userDAO)
    {
        return await _context.Users.FirstOrDefaultAsync(i => i.Username == userDAO.Username);
    }

    public async Task<bool> RemoveAsync(UserEmailDAO userDAO)
    {
        var findUser = await GetByEmailAsync(userDAO);

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
        var findUser = await GetByEmailAsync(new UserEmailDAO(userDTO.Email));

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
