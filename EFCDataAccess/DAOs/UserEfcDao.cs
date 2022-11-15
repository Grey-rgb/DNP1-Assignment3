using System.Globalization;
using Application.DAOInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOs;

public class UserEfcDao : IUserDAO
{
    private readonly PostContext context;

    public UserEfcDao(PostContext context)
    {
        this.context = context;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsername(string userName)
    {
        if (String.IsNullOrEmpty(userName))
        {
            throw new Exception("Username field cannot be null");
        }
        
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<User?> GetByIDAsync(int id)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserID == id);
        return existing;
    }

    public async Task<IEnumerable<User>> getAllAsync()
    {
        var existingUsers = context.Users;
        IEnumerable<User> result = await existingUsers.ToListAsync();
        return result;
    }
}