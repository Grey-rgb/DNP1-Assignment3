using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    //Attributes
    private readonly IUserDAO UserDao;

    //Constructor
    public UserLogic(IUserDAO userDao)
    {
        this.UserDao = userDao;
    }

    //CreateAsync method to create a user
    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? existing = await UserDao.GetByUsername(dto.UserName);
        if (existing != null)
        {
            throw new Exception("Username already taken");
        }

        ValidateData(dto);
        {
            User toCreate = new User
            {
                UserName = dto.UserName
            };

            User created = await UserDao.CreateAsync(toCreate);

            return created;
        }

    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await UserDao.getAllAsync();
    }

    public async Task<User> GetByName(string userName)
    {
        try
        {
            User? user = await UserDao.GetByUsername(userName);
            return user!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void ValidateData(UserCreationDTO userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters long");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters");
    }
}