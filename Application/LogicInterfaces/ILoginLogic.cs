using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface ILoginLogic
{
    Task<UserLoginDTO> CreateAsync(UserLoginDTO dto);

    Task<UserLoginDTO> GetUser(string username, string password);
}