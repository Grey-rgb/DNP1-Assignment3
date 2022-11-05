using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess;

public class PostContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EFCDataAccess/Post.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.id);
        modelBuilder.Entity<User>().HasKey(user => user.UserID);
    }
}