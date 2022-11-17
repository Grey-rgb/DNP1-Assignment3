using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;

namespace Application.Logic;

public class LoginLogic : ILoginLogic
{
    //Attributes
    private readonly ILoginDAO loginDao;

    //Constructor
    public LoginLogic(ILoginDAO loginDao)
    {
        this.loginDao = loginDao;
    }

    //CreateAsync method which registers a user login in the login database table
    public async Task<UserLoginDTO> CreateAsync(UserLoginDTO dto)
    {
        UserLoginDTO newDto = new UserLoginDTO(dto.username, dto.password);
        UserLoginDTO created = await loginDao.RegisterUser(newDto);
        return created;
    }

    //GetUser method to get user login information from login database
    public Task<UserLoginDTO> GetUser(string username, string password)
    {
        return loginDao.GetUser(username, password);
    }
}