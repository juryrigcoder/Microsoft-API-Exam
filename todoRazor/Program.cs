using todoRazor;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddSingleton(config);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5078");
                      });

});

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService>();

var app = builder.Build();
app.UseCors();
app.UseStaticFiles();


app.MapGet("/todos", (IHttpClientFactory httpClientFactory) => new HtmlContentResult(Components.TodoList(HttpClientFactoryService.GetTodoItems(httpClientFactory))));


app.Run();
