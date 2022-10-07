using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO postDAO;
    private readonly IUserDAO userDAO;

    public PostLogic(IPostDAO postDAO, IUserDAO userDAO)
    {
        this.postDAO = postDAO;
        this.userDAO = userDAO;
    }

    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        User? user = await userDAO.GetByIDAsync(dto.ownerID);
        if (user == null)
        {
            throw new Exception($"The given user with id: {dto.ownerID} was not found within the system");
        }
        
        ValidateTodo(dto);
        Post post = new Post(dto.title, dto.body, user);
        Post created = await postDAO.CreateAsync(post);
        return created;
    }
    
    private void ValidateTodo(PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.title))
            throw new Exception("Title cannot be empty.");
    }
}