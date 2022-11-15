using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;

namespace EFCDataAccess.DAOs;

public class UserLoginEfcDao : ILoginDAO
{
    private readonly LoginContext context;

    public UserLoginEfcDao(LoginContext context)
    {
        this.context = context;
    }
    
    public async Task<UserLoginDTO> GetUser(string username, string password)
    {
        if (String.IsNullOrEmpty(username))
        {
            throw new Exception("Username field cannot be null");
        }

        if (String.IsNullOrEmpty(password))
        {
            throw new Exception("Password field cannot be null");
        }
        
        UserLoginDTO? existing = await context.Logins.FirstOrDefaultAsync(u =>
            u.username.Equals(username) && u.password.Equals(password));
        return existing;
    }

    public async Task<UserLoginDTO> RegisterUser(UserLoginDTO user)
    {
        if (String.IsNullOrEmpty(user.username))
        {
            throw new Exception("Username cannot be null");
        }

        if (String.IsNullOrEmpty(user.password))
        {
            throw new Exception("Password cannot be null");
        }

        if (context.Logins.Any(u => u.username.Equals(user.username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new Exception("Username already exists");
        }
        
        EntityEntry<UserLoginDTO> newUser = await context.Logins.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }
}