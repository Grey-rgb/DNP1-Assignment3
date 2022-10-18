using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostsService
{
    //Attributes
    private readonly HttpClient client;

    //Constructor to receive and set a HttpClient object
    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    //Create asynchronously method to create a post and pass that post as a JSON object to the URI
    public async Task CreateAsync(PostCreationDTO dto)
    {
        //HttpResponseMessage object to communicate with a HTTP URL
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts", dto);
        if (!response.IsSuccessStatusCode)
        {
            string context = await response.Content.ReadAsStringAsync();
            throw new Exception(context);
        }
    }

    //Get asynchronously all posts from the data JSON file, no parameters, filters aren't necessary for this scope
    public async Task<ICollection<Post>> GetAllAsync()
    {
        //HttpResponseMessage object to communicate with a HTTP URL
        HttpResponseMessage response = await client.GetAsync("/posts");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}