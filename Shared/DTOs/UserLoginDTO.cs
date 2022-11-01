namespace Shared.DTOs;

public class UserLoginDTO
{
    public string username { get; set; }
    public string password { get; set; }
    public UserLoginDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}