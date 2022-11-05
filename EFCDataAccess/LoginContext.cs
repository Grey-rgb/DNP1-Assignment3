using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace EFCDataAccess;

public class LoginContext : DbContext
{
    public DbSet<UserLoginDTO> Logins { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EFCDataAccess/Logins.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLoginDTO>().HasKey(login => login.username);
    }
}