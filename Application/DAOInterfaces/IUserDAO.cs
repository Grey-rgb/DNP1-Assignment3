using Domain.Models;

namespace Application.DAOInterfaces;

public interface IUserDAO
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsername(string userName);
    Task<User?> GetByIDAsync(int id);
    Task<IEnumerable<User>> getAllAsync();
}