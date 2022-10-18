using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostsService
{
    Task CreateAsync(PostCreationDTO dto);

    Task<ICollection<Post>> GetAllAsync();
}