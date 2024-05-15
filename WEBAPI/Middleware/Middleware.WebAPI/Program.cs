using Middleware.WebAPI.Controllers;
using Middleware.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<Middlewares>();
builder.Services.AddMahmut();
builder.Services.AddCors();

builder.Services.AddExceptionHandler<MyExceptionHandler>().AddProblemDetails();


builder.Services.AddControllers(options =>
{
    //options.Filters.AddService<LogFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<LogMiddleware>(); //Dbcontext kullanýyosak addscoped kullanýlmalýdýr.
builder.Services.AddTransient<ExceptionMiddleware>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.UseCors();

//app.Use(async (contex, next) =>
//{
//    await next(contex);
//});

//app.UseMahmut();

app.UseMiddleware<LogMiddleware>();

//app.Use(async (context, next) =>
//{
//    context.Response.StatusCode = 409;
//    await next();
//});

app.Run();
