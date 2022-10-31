using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;

namespace Application.Logic;

public class LoginLogic : ILoginLogic
{
    private readonly ILoginDAO loginDao;

    public LoginLogic(ILoginDAO loginDao)
    {
        this.loginDao = loginDao;
    }

    public async Task<UserLoginDTO> CreateAsync(UserLoginDTO dto)
    {
        UserLoginDTO? user = await loginDao.GetUser(dto.username, dto.password);
        if (user != null)
        {
            if (user.username.Equals(dto.username))
            {
                throw new Exception("Username taken");
            }
        }

        UserLoginDTO newDto = new UserLoginDTO()
        {
            username = dto.username,
            password = dto.password
        };
        UserLoginDTO created = await loginDao.RegisterUser(newDto);
        return created;
    }

    public Task<UserLoginDTO> GetUser(string username, string password)
    {
        return loginDao.GetUser(username, password);
    }
}