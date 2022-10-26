namespace Domain.Models;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }

    public override string ToString()
    {
        return $"UserId: {UserID}, Username {UserName}";
    }
}