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
        UserLoginDTO newDto = new UserLoginDTO(dto.username, dto.password);
        UserLoginDTO created = await loginDao.RegisterUser(newDto);
        return created;
    }

    public Task<UserLoginDTO> GetUser(string username, string password)
    {
        return loginDao.GetUser(username, password);
    }
}