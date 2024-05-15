using Project.Bll.DependencyResolves;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


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


WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
