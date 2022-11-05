using Domain.Models;

namespace Domain.DTOs;

public class PostViewDTO
{
    public int Id { get; set; }
    public string title { get; set; }
    
    public string body { get; set; }
    
    public string userName { get; set; }

    public PostViewDTO(int id)
    {
        this.Id = id;
    }
}