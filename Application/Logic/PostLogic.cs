using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    //Attributes
    private readonly IPostDAO postDAO;
    private readonly IUserDAO userDAO;

    //Constructor
    public PostLogic(IPostDAO postDAO, IUserDAO userDAO)
    {
        this.postDAO = postDAO;
        this.userDAO = userDAO;
    }

    //CreateAsync method to create a new post using the PostCreation Data transfer object
    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        //Get user by the id provided in the dto
        User? user = await userDAO.GetByIDAsync(dto.ownerID);
        if (user == null)
        {
            //throw exception if no user was found
            throw new Exception($"The given user with id: {dto.ownerID} was not found within the system");
        }
        
        //Validate a post to make sure the post is valid
        ValidatePost(dto);
        
        //Post is then created using the parameters provided in the dto
        Post post = new Post(dto.title, dto.body, user);
        Post created = await postDAO.CreateAsync(post);
        return created;
    }

    //GetAsyncAll method to get all posts in the database
    public Task<IEnumerable<Post>> GetAsyncAll()
    {
        return postDAO.GetAsyncAll();
    }

    //GetByIdAsync method to get a post by it's id
    public async Task<Post> GetByIdAsync(int id)
    {
        //We get the post using the PostDAO method GetByIdAsync
        Post? post = await postDAO.GetByIdAsync(id);
        //If post in null, throw an exception
        if (post == null)
        {
            throw new Exception($"post with id: {id} does not exist within the system");
        }
        //Return the post2
        return post;
    }

    //ValidatePost method to make sure the post is valid
    private void ValidatePost(PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.title))
            throw new Exception("Title cannot be empty.");

        if (string.IsNullOrEmpty(dto.body))
            throw new Exception("Body cannot be empty");
    }
}