using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(action =>
{
    action.AddPolicy("PolicyFirst", policy =>
    {
        policy
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithHeaders("Authorization")
        .WithOrigins("https://www.personel.com");
    });
});

builder.Services.AddRateLimiter(options =>      // siteye atýlacak isteklerin RATE LÝMÝT Konfigürasyon ayarlarý
{
    options.AddFixedWindowLimiter("fixed", configure =>
    {
        configure.PermitLimit = 100;
        configure.Window = TimeSpan.FromSeconds(1); //1 saniyede 100 istek kabul et
        configure.QueueLimit = 100; // +100 kuyruða al
        configure.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

builder.Services.AddHealthChecks();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

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

app.UseCors("PolicyFirst");

app.UseHealthChecks("/healtcheck", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers().RequireRateLimiting("fixed");

app.Run();
