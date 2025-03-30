using ServicesInMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ICounter, RandomCounter>();
builder.Services.AddScoped<CounterService>();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
