using Application.LogicInterfaces;
using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly ILoginLogic loginLogic;

    public AuthService(ILoginLogic loginLogic)
    {
        this.loginLogic = loginLogic;
    }
    
    public async Task<UserLoginDTO> GetUser(string username, string password)
    {
        UserLoginDTO user = await loginLogic.GetUser(username, password);
        return user;
    }

    public async Task<UserLoginDTO> RegisterUser(UserLoginDTO user)
    {
        UserLoginDTO created = await loginLogic.CreateAsync(user);
        return created;
    }
}