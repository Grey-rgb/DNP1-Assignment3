namespace Domain.Models;

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<Post> Posts = new List<Post>();

    public User(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
    }
}