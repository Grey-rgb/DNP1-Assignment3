using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDTO dto);
    
    Task<IEnumerable<User>> GetUsersAsync();
    
    Task<UserBasicDTO> GetUserById(int id);
    Task<UserBasicDTO> GetUserByName(string userName);
}