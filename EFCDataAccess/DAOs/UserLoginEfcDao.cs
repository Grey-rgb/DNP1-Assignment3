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
        UserLoginDTO? existing = await context.Logins.FirstOrDefaultAsync(u =>
            u.username.Equals(username) && u.password.Equals(password));
        return existing;
    }

    public async Task<UserLoginDTO> RegisterUser(UserLoginDTO user)
    {
        EntityEntry<UserLoginDTO> newUser = await context.Logins.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }
}