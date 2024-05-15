using Project.Bll.DependencyResolves;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityService();
builder.Services.AddDbContextService();
builder.Services.AddRepositoryManagerServices();

//Session 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(2);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

builder.Services.AddMapperService(); // AutoMapperService

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
