using Newtonsoft.Json;

namespace todoRazor;

public class HttpClientFactoryService : IHttpClientServiceImplementation
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    internal static List<TodoItem> GetTodoItems(IHttpClientFactory httpClientFactory)
    {
        HttpClient client = httpClientFactory.CreateClient();
        HttpResponseMessage response = client.GetAsync("http://localhost:5197/todos").Result;

        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            List<TodoItem> todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(content);
        return todoItems;
        }
        else
        {
            throw new Exception("Error fetching data from API");
        }
    }
}

public interface IHttpClientServiceImplementation
{
}
