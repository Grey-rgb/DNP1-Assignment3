using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDTO
{
    public int ownerID { get; set; }
    public string body { get; set; }
    public string title { get; set; }
    
    public User user { get; set; }
}