using System.Text.Json;
using Shared.DTOs;

namespace FileData;

public class FileContextLogin
{
    private const string filePath = "loginData.json";
    private LoginDataContainer? userLoginContainer;
    
    public ICollection<UserLoginDTO> Users
    {
        get
        {
            LoadData();
            return userLoginContainer!.UserLogins;
        }
    }
    
    private void LoadData()
    {
        if (userLoginContainer != null) return;

        if (!File.Exists(filePath))
        {
            userLoginContainer = new()
            {
                UserLogins = new List<UserLoginDTO>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        userLoginContainer = JsonSerializer.Deserialize<LoginDataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(userLoginContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        userLoginContainer = null;
    }
}