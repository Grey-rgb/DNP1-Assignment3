using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<Post>> GetAsyncAll();
    Task<PostViewDTO> GetByIdAsync(int id);
}