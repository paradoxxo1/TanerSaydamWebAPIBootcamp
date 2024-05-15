using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

var provider = builder.Services.BuildServiceProvider();

var userService = provider.GetService<IUserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/GetAllUsers", async  (IUserService userservice, int age, string name) =>
{
    await userservice.CreateUserAsync();
    await Task.CompletedTask;
    //return "API is working";
    return Results.Ok();
}).WithName("Test");

app.MapGet("api/GetAllUsers2", async (IUserService userservice, int age, string name) =>
{
    await userservice.CreateUserAsync();
    await Task.CompletedTask;
    return "API is working";
});




app.Run();
