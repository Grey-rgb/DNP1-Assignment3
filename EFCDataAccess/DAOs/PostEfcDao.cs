using Application.DAOInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOs;

public class PostEfcDao : IPostDAO
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsyncAll()
    {
        IQueryable<Post> query = context.Posts
            .Include(todo => todo.user)
            .AsQueryable();
        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = await context.Posts
            .Include(post => post.user)
            .FirstOrDefaultAsync(post => post.id == id);
        return existing;
    }
}