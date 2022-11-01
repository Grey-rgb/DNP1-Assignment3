using Application.DAOInterfaces;
using Shared.DTOs;

namespace FileData.DAOs;

public class UserLoginDAO : ILoginDAO
{
    private readonly FileContextLogin context;

    public UserLoginDAO(FileContextLogin context)
    {
        this.context = context;
    }
    
    public Task<UserLoginDTO?> GetUser(string username, string password)
    {
        if (String.IsNullOrEmpty(username))
        {
            throw new Exception("Username field cannot be null");
        }

        if (String.IsNullOrEmpty(password))
        {
            throw new Exception("Password field cannot be null");
        }

        UserLoginDTO? existingUser = context.Users.FirstOrDefault(u =>
            u.username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.password.Equals(password));
        
        return Task.FromResult(existingUser);
    }

    public Task<UserLoginDTO> RegisterUser(UserLoginDTO user)
    {
        if (String.IsNullOrEmpty(user.username))
        {
            throw new Exception("Username cannot be null");
        }

        if (String.IsNullOrEmpty(user.password))
        {
            throw new Exception("Password cannot be null");
        }

        if (context.Users.Any(u => u.username.Equals(user.username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new Exception("Username already exists");
        }
        
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }
}