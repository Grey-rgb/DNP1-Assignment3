using Application.DAOInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDAO : IUserDAO
{
    private readonly FileContext context;

    public UserFileDAO(FileContext fileContext)
    {
        this.context = fileContext;
    }
    
    public Task<User> CreateAsync(User user)
    {
        int userID = 1;
        
        if (context.Users.Any())
        {
            userID = context.Users.Max(u => u.UserID);
            userID++;
        }

        user.UserID = userID;
        
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsername(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<User?> GetByIDAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(u => u.UserID == id);
        Console.WriteLine($"User fetched: {existing}");
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<User>> getAllAsync()
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        return Task.FromResult(users);
    }
}