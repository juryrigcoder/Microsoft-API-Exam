using FluentValidation;
using Microsoft.OpenApi.Models;
using todoApi;

// Create a new web application builder
var builder = WebApplication.CreateBuilder(args);
// Add a singleton cache service to the builder
builder.Services.AddKeyedSingleton<ICacheService, MemoryCacheService>("cached");
// Add a scoped validator to the builder
builder.Services.AddScoped<IValidator<TodoModel>, TodoFluentValidator>();
// Add endpoints explorer to the builder
builder.Services.AddEndpointsApiExplorer();
// Add swaggerGen to the builder
builder.Services.AddSwaggerGen(options =>
{
    // Set the swagger document version and title
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Todo API",
        Description = "API for managing a list of todos and their status.",
    });
});
// Create the web application
var app = builder.Build();

// If the application is in development mode, add swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect all requests to HTTPS
app.UseHttpsRedirection();

// Add a GET request to return all cached todos

app.MapGet("/todos", async ([FromKeyedServices("cached")] ICacheService MemoryCacheService) =>
{
    // Return all cached todos
    return Results.Ok(MemoryCacheService.GetAll());
})
.WithOpenApi();

// Add a POST request to add a new todo
app.MapPost("/add", async ([FromKeyedServices("cached")] ICacheService MemoryCacheService, IValidator<TodoModel> validator, TodoModel todo) =>
{
    // Validate the todo model
    var validationResult = await validator.ValidateAsync(todo);
    // If the validation is not valid, return a validation problem
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    // If the todo Id is already in the cache, return a conflict
    if (MemoryCacheService.Get(todo.Id) != null)
    {
        // Handle duplicate Id, e.g., return an error response or update the existing entry in the cache
        return Results.Conflict();
    }

    // Add the todo to the cache
    MemoryCacheService.Set(todo.Id, todo);
    return Results.Ok();
})
.WithOpenApi();

// Add a PUT request to update an existing todo

app.MapPut("/update", async ([FromKeyedServices("cached")] ICacheService MemoryCacheService, int Id, string Title, bool Completed) =>
{
    // Update the todo in the cache
    MemoryCacheService.UpDate(Id, Title, Completed);
    return Results.Ok();
})
.WithOpenApi();

// Run the application
app.Run();