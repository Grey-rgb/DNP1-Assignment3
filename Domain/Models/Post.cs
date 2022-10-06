namespace Domain.Models;

public class Post
{
    public string title { get; }
    public string body { get; }
    public string user { get; }

    public Post(string title, string body, string user)
    {
        this.title = title;
        this.body = body;
        this.user = user;
    }
}