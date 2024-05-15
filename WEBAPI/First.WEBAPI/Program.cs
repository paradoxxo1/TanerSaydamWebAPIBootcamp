var builder = WebApplication.CreateBuilder(args);

// Cross-origin resource sharing (CORS)
builder.Services.AddCors(action =>
action.AddPolicy("First", policy =>
{
    policy.WithOrigins();
})
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("First");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
