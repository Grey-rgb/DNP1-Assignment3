using Domain.Models;

namespace Application.DAOInterfaces;

public interface IPostDAO
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsyncAll();
    Task<Post?> GetByIdAsync(int id);
}