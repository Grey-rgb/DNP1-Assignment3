using Application.DAOInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDAO : IPostDAO
{
    //Attributes
    private readonly FileContext context;

    //Constructor
    public PostFileDAO(FileContext fileContext)
    {
        this.context = fileContext;
    }

    //Method to add post to context file
    public Task<Post> CreateAsync(Post post)
    {
        int postID = 1;

        //validate that the id added to the post is unique
        if (context.Posts.Any())
        {
            postID = context.Posts.Max(p => p.id);
            postID++;
        }

        post.id = postID;
        
        //Add post to context file and save changes
        context.Posts.Add(post);
        context.SaveChanges();

        //Return a task from the post result
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsyncAll()
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(p => p.id == id);
        return Task.FromResult(existing);
    }
}