using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(action =>   // CORS
{
    action.AddPolicy("policy1", policy =>
    {
        policy
        .WithOrigins("http://www.google.com")
        .WithHeaders("Authorization")
        .WithMethods("GET", "POST", "PUT", "DELETE");
    });
});

builder.Services.AddRateLimiter(options =>   // Rate limit
{
    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.QueueLimit = 5;
        options.PermitLimit = 10;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.Window = TimeSpan.FromSeconds(1);
    });
});

builder.Services.AddHealthChecks().AddCheck("healthcheck", () => HealthCheckResult.Healthy());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // app.Environment.IsProduction() (canlý uygulamalarda swagger görüntüsü için eklenecek method
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("policy1"); // CORS POLITIKASI

app.UseRateLimiter(); // rate limit add methodu

app.UseAuthorization();

app.MapControllers().RequireRateLimiting("fixed"); // tüm endpointler rate limite tabi tutulmasý için

app.MapHealthChecks("healthcheck");

app.Run();
