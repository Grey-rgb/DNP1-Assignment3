namespace Domain.Models;

public class Post
{
    public int id { set; get; }
    public string title { get; }
    public string body { get; }
    public User user { get; }

    public Post(string title, string body, User user)
    {
        this.title = title;
        this.body = body;
        this.user = user;
    }
}