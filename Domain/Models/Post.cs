using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public int id { get; set; }
    public string title { get; private set; }
    public string body { get; private set; }
    public User user { get; private set; }

    public Post(string title, string body, User user)
    {
        this.title = title;
        this.body = body;
        this.user = user;
    }
    
    private Post(){}
}