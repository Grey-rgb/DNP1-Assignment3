using Shared.DTOs;

namespace Application.DAOInterfaces;

public interface ILoginDAO
{
    Task<UserLoginDTO> GetUser(string username, string password);
    
    Task<UserLoginDTO> RegisterUser(UserLoginDTO user);
}