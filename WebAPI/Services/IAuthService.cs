using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<UserLoginDTO> GetUser(string username, string password);
    Task<UserLoginDTO> RegisterUser(UserLoginDTO user);
}