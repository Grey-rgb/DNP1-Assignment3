namespace Domain.DTOs;

public class UserBasicDTO
{
    public int UserId { get; set; }
    
    public string Username { get; set; }

    public UserBasicDTO(int userId, string username)
    {
        this.UserId = userId;
        this.Username = username;
    }
}